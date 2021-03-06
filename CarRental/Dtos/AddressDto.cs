namespace CarRental.Dtos
{
    public class AddressDto
    {
        public string Unit { get; set; }	
        public string Street { get; set; }	
        public string City { get; set; }	
        public string State { get; set; }	
        public string Suburb { get; set; }
        public int? ZipCode { get; set; }	
        public string Country { get; set; }	
    }
}