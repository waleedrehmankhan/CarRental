using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class CarClassification
    {
        public int Id { get; set; }
        public int PassengerCount { get; set; }
        public float CostPerHour { get; set; }
        public float CostPerDay { get; set; }
        public float LateFeePerHour { get; set; }
    }
}