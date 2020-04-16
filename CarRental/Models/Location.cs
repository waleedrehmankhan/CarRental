using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Location
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public Branch Branch { get; set; }
        public bool isAtLocation { get; set; }

        [Display(Name = "Car")]
        public int CarId { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }
    }
}