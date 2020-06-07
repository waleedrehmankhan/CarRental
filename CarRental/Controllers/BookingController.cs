using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Dtos;
using CarRental.Helpers;
using CarRental.Models;
using CarRental.Persistence;
using CarRental.Persistence.Repositories.Booking;
using CarRental.Persistence.Repositories.BookingExtra;
using CarRental.Persistence.Repositories.Extra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly ILogger<BookingController> _logger;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public BookingController(ILogger<BookingController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost("getBookings")]
        public async Task<ContentResult> GetBooking(GetBookingInput input)
        {
            try
            {
                IEnumerable<Booking> bookings;
                ReturnMessage rm = new ReturnMessage(1, "Success");
                var current_user = HttpContext.Session.GetObjectFromJson<RegisterUserDto>("current_user");
                if(current_user.BranchId!=3||current_user.UserRole=="Staff")
                {
                    var users = await Task.Run(() => _unitOfWork.BranchStaff.GetAsync(filter: w =>w.BranchId==current_user.BranchId, includeProperties: "Staff"));
                    List<string> usersinbranch = new List<string>();
                    foreach (var item in users)
                    {
                        usersinbranch.Add(item.Staff.UserName);
                    }
                    bookings = await Task.Run(() => _unitOfWork.Bookings.GetAsync(filter: w => (input.Id != 0 ? (w.Id == input.Id) : true)&& usersinbranch.Contains(w.CreatedBy), includeProperties: "FromBranch,ToBranch,Car,Customer"));
                }
                else 
                    bookings=  await Task.Run(() => _unitOfWork.Bookings.GetAsync(filter: w => input.Id != 0 ? (w.Id == input.Id) : true,includeProperties:"FromBranch,ToBranch,Car,Customer"));
                var bookingdToReturn = _mapper.Map<IEnumerable<BookingDto>>(bookings);
                foreach (var item in bookingdToReturn)
                {
                    item.bookingextras = GetBookingExtras(new GetBookingExtraInput() { BookingId = item.Id });
                   
                }
                
                return this.Content(rm.returnMessage(new PagedResultDto<BookingDto>
                    (bookingdToReturn.AsQueryable(), input.pagenumber, input.pagesize)),
                    "application/json");
            }
            catch (Exception ex)
            {
                return this.Content(JsonConvert.SerializeObject(new
                {
                    msgCode = -3,
                    msg = ex.Message
                }), "application/json");
            }
        }




        [HttpPost("createOrUpdateBooking")]
        [ValidateFilter]
        public async Task<ContentResult> CreateOrUpdateBooking(BookingDto bookingDto)
        {
            var current_user =  HttpContext.Session.GetObjectFromJson<RegisterUserDto>("current_user");
            float totalinvoiceamount = 0;
            Booking bookingToAdd = null;
            Invoice invoicetoadd = null;
            Customer customer = null;
            ReturnMessage returnmessage = new ReturnMessage(1, "Booking Added ");
            try
            {
                int totaldays = (int)(Convert.ToDateTime(bookingDto.ReturnDate) - Convert.ToDateTime(bookingDto.FromDate)).TotalDays;
                var booking = await Task.Run(() => _unitOfWork.Bookings.GetAsync(filter: w => w.Id == bookingDto.Id, includeProperties:( bookingDto.IsNewCustomer? "Customer":"")));
                bookingToAdd = _mapper.Map<Booking>(bookingDto);
                var est = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
                bookingToAdd.FromDate = TimeZoneInfo.ConvertTime(bookingToAdd.FromDate, est);
                bookingToAdd.ReturnDate = TimeZoneInfo.ConvertTime(bookingToAdd.ReturnDate, est);
                var cars = await Task.Run(() => _unitOfWork.Cars.GetAsync(filter: w => w.Id == bookingDto.CarId, includeProperties: "CarClassification"));
                totalinvoiceamount = totalinvoiceamount + ((cars.First().CarClassification.CostPerDay * totaldays));
                bookingToAdd.CreatedOn = DateTime.Now;
                bookingToAdd.CreatedBy = current_user.Username;
                if (booking.Count() == 0)
                {
                   
                    if (!bookingDto.IsNewCustomer&& bookingDto.CustomerId !=0)
                    {
                        bookingToAdd.Customer = null;
                       customer= _unitOfWork.Customers.Find(x => x.Id == bookingDto.CustomerId).First();
                    }
                    
                    _unitOfWork.Bookings.Add(bookingToAdd);
 
                }
                else
                {
                    if(bookingDto.IsNewCustomer)
                    {
                        bookingToAdd.Customer.Id = booking.First().Customer.Id;
                        _unitOfWork.Customers.Update(bookingToAdd.Customer);
                    }
                    _unitOfWork.Bookings.Update(bookingToAdd);
       
                }
                foreach (var item in bookingDto.bookingextras)
                {
                    if (item.PriceType==2 )
                    {
                        item.Count = totaldays;
                    }
                    var itemtoadd = _mapper.Map<BookingExtra>(item);
                    itemtoadd.Booking = bookingToAdd;
                    var extra = _unitOfWork.BookingExtras.Find(x => x.BookingId == itemtoadd.Booking.Id && x.ExtraId == itemtoadd.ExtraId);
                   if (extra.Count()>0)
                    {
                        itemtoadd.Id = extra.First().Id;
                        _unitOfWork.BookingExtras.Update(itemtoadd);
                    }
                   else
                    _unitOfWork.BookingExtras.Add(itemtoadd);
                    float itemprice =( itemtoadd.Count * item.Price)??0;
                    totalinvoiceamount = totalinvoiceamount += itemprice;
                }
          
                if(bookingDto.Id==0)
                {
                    long maxbookingid = _unitOfWork.Invoices.GetMaxBookingId();

                    InvoiceDto invoiceDto = new InvoiceDto()
                    {
                        InvoiceNumber = "INV-" + ((int)maxbookingid + 1).ToString(),
                        //  InvoiceNumber = "INV-" + bookingToAdd.Id.ToString(),
                        CustomerId = bookingToAdd.CustomerId,
                        IssueDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm"),
                        DueDate = bookingToAdd.FromDate.ToString("yyyy/MM/dd HH:mm"),
                        Description = "Invoice Created For the Booking by " + customer.FirstName,
                        Amount = totalinvoiceamount,
                        CreatedBy = current_user.Username,
                        CreatedOn = DateTime.Now


                    };

                    invoicetoadd = _mapper.Map<Invoice>(invoiceDto);
                    invoicetoadd.Booking = bookingToAdd;
                    _unitOfWork.Invoices.Add(invoicetoadd);

                }

                var status = _unitOfWork.Complete();
                _logger.LogInformation("Log:Add Booking for ID: {Id}", bookingToAdd.Id);
                return this.Content(returnmessage.returnMessage(null),
                         "application/json");
            }
            catch (Exception ex)
            {
                returnmessage.msg = ex.Message.ToString();
                returnmessage.msgCode = -3;
                return this.Content(returnmessage.returnMessage(null));
            }

        }


        [HttpPost("deleteBooking")]
        public async Task<ContentResult> DeleteBooking(GetBookingInput input)
        {

            ReturnMessage returnmessage = new ReturnMessage(1, "Booking Cancelled");
            try
            {

                var booking = await Task.Run(() => _unitOfWork.Bookings.GetAsync(filter: w => w.Id == input.Id));

                if (booking.Count() == 0)
                {
                    returnmessage.msgCode = -2;
                    returnmessage.msg = "Booking Not Found";
                }
                else
                    _unitOfWork.Bookings.Remove(booking.First());
                _unitOfWork.Complete();
                _logger.LogInformation("Log:Delete Booking for ID: {Id}", input.Id);

                return this.Content(returnmessage.returnMessage(null),
                            "application/json");
            }
            catch (Exception ex)
            {
                returnmessage.msg = ex.Message.ToString();
                returnmessage.msgCode = -3;
                return this.Content(returnmessage.returnMessage(null));
            }
        }


        #region Extras
        [HttpPost("getExtras")]
        public async Task<ContentResult> GetExtras(GetExtraInput input)
        {
            try
            {
                ReturnMessage rm = new ReturnMessage(1, "Success");
                IList<BookingExtraDto> bookingextralist = null;
                if (input.BookingId>0)
                { 
                    bookingextralist= GetBookingExtras(new GetBookingExtraInput() { BookingId = input.BookingId });

                }

                var extras = await Task.Run(() => _unitOfWork.Extras.GetAsync(filter: w => input.Id != 0 ? (w.Id == input.Id) : true));
                var extrasToReturn = _mapper.Map<IEnumerable<ExtraDto>>(extras);
                if(bookingextralist!=null)
                {
                    var result = extrasToReturn.Join(bookingextralist, d => d.ExtraId, s => s.ExtraId, (d, s) =>
                    {
                        d.Count = s.Count;
                        return d;
                    }).ToList();

                }

                return this.Content(rm.returnMessage(new PagedResultDto<ExtraDto>
                    (extrasToReturn.AsQueryable(), input.pagenumber, input.pagesize)),
                    "application/json");
            }
            catch (Exception ex)
            {
                return this.Content(JsonConvert.SerializeObject(new
                {
                    msgCode = -3,
                    msg = ex.Message
                }), "application/json");
            }
        }


 
        public  IList<BookingExtraDto>  GetBookingExtras(GetBookingExtraInput input)
        {
      
                ReturnMessage rm = new ReturnMessage(1, "Success");
            var extras = _unitOfWork.BookingExtras.Find(x => x.BookingId == input.BookingId);
             var extrasToReturn = _mapper.Map<IList<BookingExtraDto>>(extras.ToList());
            return extrasToReturn;


        }

        #endregion

    }
}