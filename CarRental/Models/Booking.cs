using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public Branch FromBranch { get; set; }
        public Branch ToBranch { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        public bool isActive { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Car")]
        public int CarId { get; set; }

        [Display(Name = "From Branch")]
        public int FromBranchId { get; set; }

        [Display(Name = "To Branch")]
        public int ToBranchId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }
}