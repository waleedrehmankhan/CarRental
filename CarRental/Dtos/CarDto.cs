using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class CarDto
    {

        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long Mileage { get; set; }
        public bool isAvailable { get; set; }
        public bool isActive { get; set; }
        public int CarClassificationId { get; set; }
    }
}
