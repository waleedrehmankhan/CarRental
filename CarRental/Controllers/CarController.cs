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
            try
            {
                ReturnMessage rm = new ReturnMessage(1, "Success");
                var cars = await Task.Run(() => _unitOfWork.Cars.GetAsync(filter: w => input.Id != 0 ? (w.Id == input.Id) : true, includeProperties: "CarClassification"));
                var carsToReturn = _mapper.Map<IEnumerable<CarDto>>(cars);
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
                var car = await Task.Run(() => _unitOfWork.Cars.GetAsync(filter: w => w.Id == carDto.Id));
                var carToAdd = _mapper.Map<Car>(carDto);
                if (car.Count() == 0)
                {
                    carToAdd.Id = 0;
                    _unitOfWork.Cars.Add(carToAdd);

                }
                else
                {
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

    }



}