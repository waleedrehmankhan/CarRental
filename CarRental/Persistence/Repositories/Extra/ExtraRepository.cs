using CarRental.Data;
using CarRental.Models;
using CarRental.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence 
{
    public class ExtraRepository:Repository<Extra>, IExtraRepository

    {
        public ExtraRepository(ApplicationDbContext context)
          : base(context)
        {
        }
    }
}
