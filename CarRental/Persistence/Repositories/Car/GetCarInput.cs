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
        public string Model;
        public bool IsAvailable;
        public int  CarClassificationId;
        public DateTime  AvailableDateCheck;
        public DateTime  FromDate;
        public DateTime  ReturnDate;
        public string  RegistrationNumber;
        public bool  issearch;
        public int  Year;

    }
}
