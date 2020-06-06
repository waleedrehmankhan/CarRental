using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class ServiceHistoryDto
    {
        public int Id { get; set; }
        public CarDto Car { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
 
        public int CarId { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
