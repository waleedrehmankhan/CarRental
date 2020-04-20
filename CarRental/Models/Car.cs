using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }
        public string Image { get; set; }
        
        [Required]
        public int Year { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public long Mileage { get; set; }
        public bool isAvailable { get; set; }
        public bool isActive { get; set; }

        public CarClassification CarClassification { get; set; }

        [Display(Name = "Car Classification")]
        public int CarClassificationId { get; set; }
        
    }
}