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
                ReturnMessage rm = new ReturnMessage(1, "Success");
                var bookings = await Task.Run(() => _unitOfWork.Bookings.GetAsync(filter: w => input.Id != 0 ? (w.Id == input.Id) : true,includeProperties:"FromBranch,ToBranch,Car,Customer"));
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
             
            Booking bookingToAdd = null;
            ReturnMessage returnmessage = new ReturnMessage(1, "Booking Added ");
            try
            {
                var booking = await Task.Run(() => _unitOfWork.Bookings.GetAsync(filter: w => w.Id == bookingDto.Id, includeProperties:( bookingDto.IsNewCustomer? "Customer":"")));
                bookingToAdd = _mapper.Map<Booking>(bookingDto);
                 if (booking.Count() == 0)
                {
                    if(!bookingDto.IsNewCustomer&& bookingDto.CustomerId !=0)
                    {
                        bookingToAdd.Customer = null;
                    }
                    bookingToAdd.FromDate = Utility.ConvertToDatetime(bookingDto.FromDate);
                    bookingToAdd.ReturnDate = Utility.ConvertToDatetime(bookingDto.ReturnDate);
                    _unitOfWork.Bookings.Add(bookingToAdd);
                 
                    foreach (var item in bookingDto.bookingextras)
                    {
                        var itemtoadd = _mapper.Map<BookingExtra>(item);
                        itemtoadd.Booking = bookingToAdd;
                        _unitOfWork.BookingExtras.Add(itemtoadd);
                    }
                    
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

                var result = extrasToReturn.Join(bookingextralist, d => d.ExtraId, s => s.ExtraId, (d, s) =>
                {
                    d.Count = s.Count;
                    return d;
                }).ToList();

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