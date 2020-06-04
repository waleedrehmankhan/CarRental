using CarRental.Data;
using CarRental.Models;
using CarRental.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence 
{
    public class ServiceRepository : Repository<ServiceHistory>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
