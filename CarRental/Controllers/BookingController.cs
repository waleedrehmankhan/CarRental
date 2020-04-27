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

            ReturnMessage returnmessage = new ReturnMessage(1, "Booking Added ");
            try
            {
                var booking = await Task.Run(() => _unitOfWork.Bookings.GetAsync(filter: w => w.Id == bookingDto.Id));
                var bookingToAdd = _mapper.Map<Booking>(bookingDto);
                if (booking.Count() == 0)
                {
                    _unitOfWork.Bookings.Add(bookingToAdd);

                }
                else
                {
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




    }
}