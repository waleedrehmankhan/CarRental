using CarRental.Data;
using CarRental.Models;
using CarRental.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context)
           : base(context)
        {
        }

        public bool IsCarAvailable(int Carid, DateTime fromdate, DateTime todate, int branchid)
        {
            return false;
        }
    }
}
