using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class BookingDto : AddressDto
    {
        public int Id { get; set; }

        public CustomerDto Customer { get; set; }
        public BranchDto FromBranch { get; set; }
        public BranchDto ToBranch { get; set; }
        public IList<BookingExtraDto> bookingextras { get; set; }
        public CarDto Car { get; set; }
        public string FromDate { get; set; }
        public string ReturnDate { get; set; }
      //  public DateTime ActualReturnDate { get; set; }
        public bool isActive { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int FromBranchID { get; set; }
        public int ToBranchID { get; set; }
        public bool IsNewCustomer { get; set; }
    }
}
