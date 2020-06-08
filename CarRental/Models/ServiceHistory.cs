using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class ServiceHistory
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }
        public int ServicingType { get; set; }
        public double Amoune { get; set; }
        public string Description { get; set; }

        [Display(Name = "Car")]
        public int CarId { get; set; }

    }
}