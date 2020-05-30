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
            Cars = new CarRepository(_context);
            Bookings = new BookingRepository(_context);
            Branchs = new BranchRepository(_context);
            Extras = new ExtraRepository(_context);
            BookingExtras = new BookingExtraRepository(_context);
            Invoices = new InvoiceRepository(_context);
            Payments = new PaymentRepository(_context);
        }

        public ICustomerRepository Customers { get; private set; }
        public IMembershipRepository MembershipTypes { get; private set; }
        public IBranchRepository Branchs {get; private set; }

        public ICarRepository Cars { get; private set; }
        public IBookingRepository Bookings { get; private set; }
        public IExtraRepository Extras { get; private set; }

        public IBookingExtraRepository BookingExtras { get; private set; }

        public IInvoiceRepository Invoices { get; private set; }
        public IPaymentRepository Payments { get; private set; }

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