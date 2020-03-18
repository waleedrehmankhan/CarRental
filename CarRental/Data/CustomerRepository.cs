using System.Collections.Generic;
using System.Threading.Tasks;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using CarRental.Data;

namespace CarRental.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _context
            .Customers
            .Include(m => m.MembershipType)
            .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context
            .Customers
            .Include(m => m.MembershipType)
            .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context
            .SaveChangesAsync() > 0;
        }
    }
}