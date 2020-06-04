using CarRental.Persistence.Interfaces;
using System;

namespace CarRental.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IMembershipRepository MembershipTypes { get; }
        IBranchRepository Branchs { get; }
        IBranchStaffRepository BranchStaff { get; }
        ICarRepository Cars { get; }
        IBookingRepository Bookings { get; }
        IExtraRepository Extras { get; }
        IBookingExtraRepository BookingExtras { get; }
        IInvoiceRepository Invoices { get; }
        IPaymentRepository Payments { get; }
        ICarClassificationRepository CarClassification { get; }
        IServiceRepository ServiceHistory { get; }
        int Complete();
    }
}