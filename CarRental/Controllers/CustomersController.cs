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

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public CustomersController(ILogger<CustomersController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        // GET /api/customers
        [HttpGet]
        public ActionResult GetCustomers()
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType).ToList();

            var customerDtos = _mapper.Map<CustomerDto>(customersQuery);

            return Ok(customerDtos);  
        }

        // GET /api/customer/1
        public ActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return NotFound();
            
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public ActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            _logger.LogInformation("Add Customer for ID: {Id}", customer.Id);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.GetDisplayUrl() + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public ActionResult UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDb == null)
                return NotFound();

            _logger.LogInformation("Update Customer for ID: {Id}", customerInDb.Id);
            customerInDb = _mapper.Map<Customer>(customerDto);
            
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
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