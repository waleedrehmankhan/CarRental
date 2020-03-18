using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Data;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using CarRental.Models;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ApplicationDbContext _context;

        public CustomersController(ILogger<CustomersController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET /api/customers
        [HttpGet]
        public ActionResult GetCustomers()
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType).ToList();

            return Ok(customersQuery);  
        }

        // GET /api/customer/1
        public ActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return NotFound();
            
            return Ok(customer);
        }

        // POST /api/customer
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _logger.LogInformation("Add Customer for ID: {Id}", customer.Id);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Created(new Uri(Request.GetDisplayUrl() + "/" + customer.Id), customer);
        }

        // PUT /api/customer/1
        [HttpPut]
        public ActionResult UpdateCustomer(int Id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDb == null)
                return NotFound();

            _logger.LogInformation("Update Customer for ID: {Id}", customer.Id);
            customerInDb = customer;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customer/1
        [HttpDelete]
        public ActionResult DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            
            if (customerInDb == null)
                return NotFound();

            _logger.LogInformation("Delete Customer for ID: {Id}", Id);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}