using CarRental.Data;
using CarRental.Models;
using CarRental.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public class CarClassificationRepository : Repository<CarClassification>, ICarClassificationRepository
    {
        public CarClassificationRepository(ApplicationDbContext context)
           : base(context)
        {
        }
    }
}
