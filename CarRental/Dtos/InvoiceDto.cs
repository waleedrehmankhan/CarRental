using CarRental.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public BookingDto Booking { get; set; }
        public string InvoiceNumber { get; set; }
        private string _issueDate { get; set; }

        public string IssueDate
        {
            get
            {
                return
                    Utility.ConvertToDatetime(_issueDate);

            }
            set { _issueDate = Utility.ConvertToDatetime(value); }

        }

        private string _dueDate { get; set; }

        public string DueDate
        {
            get
            {
                return
                    Utility.ConvertToDatetime(_dueDate);

            }
            set { _dueDate = Utility.ConvertToDatetime(value); }

        }
      
        public double Amount { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int BookingId { get; set; }
        public bool status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
