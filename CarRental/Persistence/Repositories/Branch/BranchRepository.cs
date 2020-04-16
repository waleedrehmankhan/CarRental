using CarRental.Data;
using CarRental.Models;
using CarRental.Persistence.Interfaces;

namespace CarRental.Persistence
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}