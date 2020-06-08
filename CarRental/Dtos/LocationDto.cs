using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class LocationDto
    {

        public int Id { get; set; }
        public CarDto Car { get; set; }
        public BranchDto Branch { get; set; }
        public bool isAtLocation { get; set; }
        public int CarId { get; set; }
        public int BranchId { get; set; }
    }
}
