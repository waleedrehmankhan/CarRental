using System;
using System.Linq;
using CarRental.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using CarRental.Models;
using AutoMapper;
using CarRental.Dtos;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using CarRental.Persistence;
using CarRental.Helpers;
using CarRental.Persistence.Repositories.Customer;
using Newtonsoft.Json;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomersController(ILogger<CustomersController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

 
        [HttpPost("getCustomerDetails")]
        public async Task<ContentResult> GetCustomers(GetCustomerInput input)
        {
            try
            {
                ReturnMessage rm = new ReturnMessage(1,"Success");
                var customers = await Task.Run(() => _unitOfWork.Customers.GetAsync(filter: w => input.CustomerID!=0? (w.CustomerID == input.CustomerID):true )) ;
                var customersToReturn = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                return this.Content(rm.returnMessage(new PagedResultDto<CustomerDto>
                    (customersToReturn.AsQueryable(), input.pagenumber, input.pagesize)),
                    "application/json");
            }
            catch(Exception ex) {
                return this.Content(JsonConvert.SerializeObject(new
                {
                    msgCode = 0,
                    msg = ex.Message
                }), "application/json");
            }
        }
         [HttpPost("getCustomerDetailById")]
        public async Task<ContentResult> GetCustomerById(GetCustomerInput input)
        {
            return await GetCustomers(input);
        }

         

        [HttpPost("createOrUpdateCustomer")]
        public async Task<ContentResult> CreateOrUpdateCustomer(CustomerDto customerDto)
        {

            ReturnMessage returnmessage = new ReturnMessage(1, "Customer Saved Succesfully");
            try
            {
                var customer = await Task.Run(() => _unitOfWork.Customers.GetAsync(filter: w => w.CustomerID == customerDto.CustomerID));
                var customerToAdd = _mapper.Map<Customer>(customerDto);
                if (customer.Count() == 0)
                {
                    _unitOfWork.Customers.Add(customerToAdd);

                }
                else
                {
                    _unitOfWork.Customers.Update(customerToAdd);
                }
                var status = _unitOfWork.Complete();
                _logger.LogInformation("Log:Add Customer for ID: {Id}", customerToAdd.CustomerID);
                return this.Content(returnmessage.returnMessage(null),
                         "application/json");
            }
            catch(Exception ex)
            {
                returnmessage.msg = ex.Message.ToString();
                returnmessage.msgCode = -3;
                return this.Content(returnmessage.returnMessage(null));
            }

        }




       
        [HttpPost("deleteCustomer")]
        public async Task<ContentResult> DeleteCustomer(GetCustomerInput input)
        {
            
            ReturnMessage returnmessage = new ReturnMessage(1, "Customer Deleted Succesfully");
            try
            {

                var customer = await Task.Run(() => _unitOfWork.Customers.GetAsync(filter: w => w.CustomerID == input.CustomerID));

                if (customer.Count() == 0)
                {
                    returnmessage.msgCode = -2;
                    returnmessage.msg = "Customer Not Found";
                }
                else
                    _unitOfWork.Customers.Remove(customer.First());
                _unitOfWork.Complete();
                _logger.LogInformation("Log:Delete Customer for ID: {Id}", input.CustomerID);

                return this.Content(returnmessage.returnMessage(null),
                            "application/json");
            }
            catch(Exception ex)
            {
                returnmessage.msg = ex.Message.ToString();
                returnmessage.msgCode = -3;
                return this.Content(returnmessage.returnMessage(null));
            }
        }
    }
}