using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarRental.Dtos;

namespace CarRental.Dtos
{
    public class BranchDto : AddressDto
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string PhoneNumber { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool isActive { get; set; }
    }
}