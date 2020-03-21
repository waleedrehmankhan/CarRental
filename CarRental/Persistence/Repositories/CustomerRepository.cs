using System.Collections.Generic;
using System.Threading.Tasks;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using CarRental.Data;

namespace CarRental.Persistence
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

    }
}