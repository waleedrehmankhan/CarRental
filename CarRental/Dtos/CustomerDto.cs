using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Dtos
{
    public class CustomerDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerID { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerCode { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
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

        public MembershipTypeDto MembershipType { get; set; }
        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

    }
}