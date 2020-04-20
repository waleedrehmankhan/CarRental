using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class Branch : Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string BranchName { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public bool isActive { get; set; }
    }
}