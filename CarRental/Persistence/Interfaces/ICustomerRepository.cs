using System.Collections.Generic;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.Persistence
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}