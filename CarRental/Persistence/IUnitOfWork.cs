using CarRental.Persistence.Interfaces;
using System;

namespace CarRental.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IMembershipRepository MembershipTypes { get; }
        IBranchRepository Branchs { get; }
        int Complete();
    }
}