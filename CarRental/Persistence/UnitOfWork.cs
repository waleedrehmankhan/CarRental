using CarRental.Data;
using CarRental.Persistence.Interfaces;
using CarRental.Persistence.Repositories.MemberShipType;

namespace CarRental.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            MembershipTypes = new MembershipRepository(_context);
        }

        public ICustomerRepository Customers { get; private set; }
        public IMembershipRepository MembershipTypes { get; private set; }
        public IBranchRepository Branchs {get; private set; }

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