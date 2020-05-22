using CarRental.Persistence.Interfaces;
using System;

namespace CarRental.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IMembershipRepository MembershipTypes { get; }
        IBranchRepository Branchs { get; }
        ICarRepository Cars { get; }
        IBookingRepository Bookings { get; }
        IExtraRepository Extras { get; }
        IBookingExtraRepository BookingExtras { get; }
        IInvoiceRepository Invoices { get; }
        int Complete();
    }
}