using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class UserBranch
    {
        public int Id { get; set; }
        public ApplicationUser Staff { get; set; }
        public Branch Branch { get; set; }

        [Display(Name = "Staff")]
        public string StaffId { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }
    }
}