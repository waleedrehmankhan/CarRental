using CarRental.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.Car
{
    public class GetCarInput : PagedAndSortedInputDto
    {
        public int Id;
        public int Model;
        public bool IsAvailable;
        public int  CarClassificationId;

    }
}
