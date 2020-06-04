using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Dtos;
using CarRental.Helpers;
using CarRental.Models;
using CarRental.Persistence;
using CarRental.Persistence.Repositories.Car;
using CarRental.Persistence.Repositories.ServiceHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CarController(ILogger<CarController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost("getCarDetails")]
        public async Task<ContentResult> GetCar(GetCarInput input)
        {


            var est = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
            input.AvailableDateCheck= TimeZoneInfo.ConvertTime(input.AvailableDateCheck, est);

            try
            {
                ReturnMessage rm = new ReturnMessage(1, "Success");
                var cars = await Task.Run(() => _unitOfWork.Cars.GetAsync(filter: w => input.Id != 0 ? (w.Id == input.Id) : true, includeProperties: "CarClassification"));
                var carsToReturn = _mapper.Map<IEnumerable<CarDto>>(cars);
                foreach (var item in carsToReturn)
                {
                    item.CarAvailability = GetavailableTime(new GetCarInput() { Id=item.Id,AvailableDateCheck=input.AvailableDateCheck});
                }
                return this.Content(rm.returnMessage(new PagedResultDto<CarDto>
                    (carsToReturn.AsQueryable(), input.pagenumber, input.pagesize)),
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

        [HttpPost("createOrUpdateCar")]
        [ValidateFilter]
        public async Task<ContentResult> CreateOrUpdateCar(CarDto carDto)
        {
 
            ReturnMessage returnmessage = new ReturnMessage(1, "Car Saved Succesfully");
            try
            {
                carDto.CarClassification = new CarClassificationDto() { 
                
                PassengerCount=carDto.PassengerCount,
                CostPerDay=carDto.CostPerDay,
                CostPerHour=carDto.CostPerHour,
                LateFeePerHour=carDto.LateFeePerHour
                };
                var car = await Task.Run(() => _unitOfWork.Cars.GetAsync(filter: w => w.Id == carDto.Id));
                var carToAdd = _mapper.Map<Car>(carDto);
                var carClassificationToAdd = _mapper.Map<CarClassification>(carDto.CarClassification);

                if (car.Count() == 0)
                {
                    carToAdd.Id = 0;
                    carToAdd.CarClassification = carClassificationToAdd;
                    _unitOfWork.CarClassification.Add(carClassificationToAdd);
                    _unitOfWork.Cars.Add(carToAdd);

                }
                else
                {
                    _unitOfWork.CarClassification.Update(carClassificationToAdd);
                    _unitOfWork.Cars.Update(carToAdd);
                }
                var status = _unitOfWork.Complete();
                _logger.LogInformation("Log:Add Car for ID: {Id}", carToAdd.Id);
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


        [HttpPost("deleteCar")]
        public async Task<ContentResult> DeleteCar(GetCarInput input)
        {

            ReturnMessage returnmessage = new ReturnMessage(1, "Car Deleted Succesfully");
            try
            {

                var car = await Task.Run(() => _unitOfWork.Cars.GetAsync(filter: w => w.Id == input.Id));

                if (car.Count() == 0)
                {
                    returnmessage.msgCode = -2;
                    returnmessage.msg = "Car Not Found";
                }
                else
                    _unitOfWork.Cars.Remove(car.First());
                _unitOfWork.Complete();
                _logger.LogInformation("Log:Delete Car for ID: {Id}", input.Id);

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




        public List<CarAvailbilityTimeDto> GetavailableTime(GetCarInput input)
        {
            try
            {


                IEnumerable<int> notin = new List<int>();
                List<string> test = new List<string>();
                List<CarAvailbilityTimeDto> caravailabilitytimelist = new List<CarAvailbilityTimeDto>();
                var bookings = _unitOfWork.Bookings.Find(x => x.CarId == input.Id && x.isActive == true && input.AvailableDateCheck.Date >= x.FromDate.Date && input.AvailableDateCheck.Date <= x.ReturnDate.Date);
                List<int> totalhours = new List<int>();
                for (int i = 0; i < 24; i++)
                {
                    totalhours.Add(i);

                }
                IList<int> hoursBetween = new List<int>();
                foreach (var item in bookings)
                {

                    if(input.AvailableDateCheck>item.FromDate)
                    {
                        input.AvailableDateCheck = input.AvailableDateCheck.Date;
                    }
                    if (input.AvailableDateCheck.Date == item.FromDate.Date)
                    {
                        TimeSpan time = item.FromDate.TimeOfDay;
                        input.AvailableDateCheck = input.AvailableDateCheck.Date+ time;
                    }

                    if (item.ReturnDate> input.AvailableDateCheck)
                    {

                    
                    TimeSpan ts = item.ReturnDate - input.AvailableDateCheck;
                      hoursBetween = Enumerable.Range(0, ((int)ts.TotalHours)+1)
                        .Select(i => input.AvailableDateCheck.AddHours(i).Hour).ToList();
                    }
                    for (int i = 0; i < hoursBetween.Count(); i++)
                    {


                        var date = input.AvailableDateCheck;
                        if (i != 0 && hoursBetween[i] == 0)
                        {
                            break;
                            //date = input.AvailableDateCheck.AddDays(1);
                        }
                        CarAvailbilityTimeDto carAvailbility = new CarAvailbilityTimeDto()
                        {
                            BookingId = item.Id,
                            CarId = item.CarId,
                            Date = date,
                            time = string.Format("{0}:00", hoursBetween[i].ToString()),
                            IsAvailable = false,
                            Hour = hoursBetween[i]

                        };
                        caravailabilitytimelist.Add(carAvailbility);
                    }
                    notin = totalhours.Where(p => caravailabilitytimelist.All(p2 => p2.Hour != p));
                    foreach (var item1 in notin)
                    {
                        CarAvailbilityTimeDto carAvailbility = new CarAvailbilityTimeDto()
                        {
                            BookingId = item.Id,
                            CarId = item.CarId,
                            Date = input.AvailableDateCheck,
                            time = string.Format("{0}:00", item1.ToString()),
                            IsAvailable = true,
                            Hour = item1

                        };
                        caravailabilitytimelist.Add(carAvailbility);
                    }


                }
                notin = totalhours.Where(p => caravailabilitytimelist.All(p2 => p2.Hour != p));
                foreach (var item1 in notin)
                {
                    CarAvailbilityTimeDto carAvailbility = new CarAvailbilityTimeDto()
                    {
                        BookingId = 0,
                        CarId = input.Id,
                        Date = input.AvailableDateCheck,
                        time = string.Format("{0}:00", item1.ToString()),
                        IsAvailable = true,
                        Hour = item1

                    };
                    caravailabilitytimelist.Add(carAvailbility);
                }
                _unitOfWork.Complete();
                return caravailabilitytimelist.OrderBy(x => x.Hour).ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
            }



        [HttpPost("createOrUpdateCarService")]
        [ValidateFilter]
        public async Task<ContentResult> createOrUpdateCarService(ServiceHistoryDto carserviceDto)
        {

            ReturnMessage returnmessage = new ReturnMessage(1, "Car Service History Saved Succesfully");
            try
            {
                
                var service = await Task.Run(() => _unitOfWork.ServiceHistory.GetAsync(filter: w => w.Id == carserviceDto.Id));
                var serviceToAdd = _mapper.Map<ServiceHistory>(carserviceDto);
             

                if (service.Count() == 0)
                {
                    
                    _unitOfWork.ServiceHistory.Add(serviceToAdd);

                }
                else
                {
                   
                    _unitOfWork.ServiceHistory.Update(serviceToAdd);
                }
                var status = _unitOfWork.Complete();
                _logger.LogInformation("Log:Add Car Service for ID: {Id}", serviceToAdd.Id);
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


        [HttpPost("getCarServiceDetails")]
        public async Task<ContentResult> GetCarServiceDetails( GetServiceInput input)
        {
            try
            {
                ReturnMessage rm = new ReturnMessage(1, "Success");
                var services = await Task.Run(() => _unitOfWork.ServiceHistory.GetAsync(filter: w => input.Id != 0 ? (w.Id == input.Id) : true));
                var servicestoReturn = _mapper.Map<IEnumerable<ServiceHistoryDto>>(services);
                return this.Content(rm.returnMessage(new PagedResultDto<ServiceHistoryDto>
                    (servicestoReturn.AsQueryable(), input.pagenumber, input.pagesize)),
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
    }


   
}