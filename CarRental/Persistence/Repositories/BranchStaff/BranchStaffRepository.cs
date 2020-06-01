using CarRental.Data;
using CarRental.Models;
using CarRental.Persistence.Interfaces;

namespace CarRental.Persistence
{
    public class BranchStaffRepository : Repository<BranchStaff>, IBranchStaffRepository
    {
        public BranchStaffRepository(ApplicationDbContext context) : base(context)
        {


        }
    }
}