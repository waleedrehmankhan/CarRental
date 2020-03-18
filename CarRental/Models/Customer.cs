using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(12)]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [StringLength(10)]
        public string LicenseNumber { get; set; }
        
        public bool isSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

    }
}