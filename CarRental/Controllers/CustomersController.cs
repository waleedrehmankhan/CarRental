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

        // GET /api/customers
        [HttpGet]
        public ActionResult GetCustomers()
        {
            var customers = _unitOfWork.Customers.GetAll();
            var customersToReturn = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customersToReturn);
        }

        // GET /api/customer/1
        [HttpGet("{id}")]
        public ActionResult GetCustomer(int id)
        {
            var customer = _unitOfWork.Customers.Get(id);

            if (customer == null)
                return NotFound();

            var customerToReturn = _mapper.Map<CustomerDto>(customer);

            return Ok(customerToReturn);
        }

        // POST /api/customers
        [HttpPost]
        public ActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerToAdd = _mapper.Map<Customer>(customerDto);

            _unitOfWork.Customers.Add(customerToAdd);
            var status = _unitOfWork.Complete();
            if (status == 0)
                return Forbid();

            _logger.LogInformation("Log:Add Customer for ID: {Id}", customerToAdd.Id);
            return Created(new Uri(Request.GetDisplayUrl() + "/" + customerToAdd.Id), customerDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var customerInDb = _unitOfWork.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
            
            // manual mapping TODO: Auto Mapper not working.
            customerInDb.Name = customerDto.Name;
            customerInDb.EmailAddress = customerDto.EmailAddress;
            customerInDb.BirthDate = customerDto.BirthDate;
            customerInDb.LicenseNumber = customerDto.LicenseNumber;
            customerInDb.PhoneNumber = customerDto.PhoneNumber;   
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId; 
            customerInDb.isSubscribedToNewsLetter = customerDto.isSubscribedToNewsLetter;

            var status = _unitOfWork.Complete();
            if (status == 0)
                return Forbid();

            _logger.LogInformation("Log:Update Customer for ID: {Id}", customerInDb.Id);
            
            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customerInDb = _unitOfWork.Customers.Get(id);

            if (customerInDb == null)
                return NotFound();

            _unitOfWork.Customers.Remove(customerInDb);
            var status = _unitOfWork.Complete();

            if (status == 0)
                return Forbid();
                
            _logger.LogInformation("Log:Delete Customer for ID: {Id}", id);
            
            return Ok();
        }
    }
}