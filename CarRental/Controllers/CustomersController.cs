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

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        private readonly ICustomerRepository _repo;

        public CustomersController(ILogger<CustomersController> logger, ICustomerRepository repo)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET /api/customers
        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            var customers = await _repo.GetCustomersAsync();
            return Ok(customers);
        }

        // GET /api/customer/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer(int id)
        {
            var customer = await _repo.GetCustomerAsync(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST /api/customers
        [HttpPost]
        public async Task<ActionResult> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _repo.Add(customer);
            _logger.LogInformation("Add Customer for ID: {Id}", customer.Id);
           
            await _repo.SaveAllAsync();
            return Created(new Uri(Request.GetDisplayUrl() + "/" + customer.Id), customer);
        }

        // DELETE /api/customers/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var customerInDb = await _repo.GetCustomerAsync(id);

            if (customerInDb == null)
                return NotFound();

            _repo.Delete(customerInDb);
            await _repo.SaveAllAsync();
            _logger.LogInformation("Delete Customer for ID: {Id}", id);
            
            return Ok();
        }
    }
}