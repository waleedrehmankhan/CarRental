using CarRental.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.Extra
{
    public class GetExtraInput: PagedAndSortedInputDto
    {
        public int Id { get; set; }
    }
}
