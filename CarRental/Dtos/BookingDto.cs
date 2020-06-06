using CarRental.Helpers;
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

        private string _fromDate;
        private string _returnDate;
        public string FromDate
        {
            get
            {
                return        
                    Utility.ConvertToDatetime(_fromDate);

            }
            set { _fromDate= Utility.ConvertToDatetime(value); }
       
        }
        public string ReturnDate
        {
            get
            {
                return Utility.ConvertToDatetime(_returnDate);

            }
            set
            {

                _returnDate= Utility.ConvertToDatetime(value);
            }
        }
        //  public DateTime ActualReturnDate { get; set; }
        public string isActive { get; set; }
        public string Status {
            get
            {
                return isActive == "True" ? "Active" : "Completed";
                     

            }
            

        }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int FromBranchID { get; set; }
        public int ToBranchID { get; set; }
        public bool IsNewCustomer { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
