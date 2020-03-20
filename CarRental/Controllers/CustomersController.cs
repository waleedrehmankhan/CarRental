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

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomersController(ILogger<CustomersController> logger, ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        // GET /api/customers
        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            var customers = await _repo.GetCustomersAsync();
            var customersToReturn = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customersToReturn);
        }

        // GET /api/customer/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer(int id)
        {
            var customer = await _repo.GetCustomerAsync(id);

            if (customer == null)
                return NotFound();

            var customerToReturn = _mapper.Map<CustomerDto>(customer);

            return Ok(customerToReturn);
        }

        // POST /api/customers
        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerToAdd = _mapper.Map<Customer>(customerDto);

            _repo.Add(customerToAdd);
           
            bool status = await _repo.SaveAllAsync();
            if (!status)
                return Forbid();

            _logger.LogInformation("Add Customer for ID: {Id}", customerToAdd.Id);
            return Created(new Uri(Request.GetDisplayUrl() + "/" + customerToAdd.Id), customerDto);
        }

        // DELETE /api/customers/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var customerInDb = await _repo.GetCustomerAsync(id);

            if (customerInDb == null)
                return NotFound();

            _repo.Delete(customerInDb);
            bool status = await _repo.SaveAllAsync();

            if (!status)
                return Forbid();
                
            _logger.LogInformation("Delete Customer for ID: {Id}", id);
            
            return Ok();
        }
    }
}