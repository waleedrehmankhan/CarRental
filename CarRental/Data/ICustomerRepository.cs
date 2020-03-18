using System.Collections.Generic;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.Data
{
    public interface ICustomerRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
    }
}