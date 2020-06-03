using CarRental.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.ServiceHistory
{
    public class GetServiceInput: PagedAndSortedInputDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
    }
}
