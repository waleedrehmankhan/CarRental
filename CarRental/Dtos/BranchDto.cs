using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarRental.Dtos;

namespace CarRental.Dtos
{
    public class BranchDto : AddressDto
    {
        public int BranchID { get; set; }

        [Required]
        [StringLength(255)]
        public string BranchName { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public bool isActive { get; set; }
    }
}