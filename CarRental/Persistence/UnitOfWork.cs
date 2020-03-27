using CarRental.Data;

namespace CarRental.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
        }

        public ICustomerRepository Customers { get; private set; }

        public int Complete()

        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}