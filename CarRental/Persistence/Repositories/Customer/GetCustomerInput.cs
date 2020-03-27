using CarRental.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.Customer
{
    public class GetCustomerInput: PagedAndSortedInputDto
    {

        public long CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
      

    }
}
