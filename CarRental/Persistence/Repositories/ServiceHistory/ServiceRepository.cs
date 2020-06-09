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

        public float GetTotalExpense()
        {
            
            throw new NotImplementedException();
        }

        public dynamic GetTotalExpenseByTypeMonthly()
        {
            //var data = this.dbSet.ToList().GroupBy(x => x.ServicingType.ToString(), x.DueDate.Month.ToString());
            //foreach (var group in data)
            //{
            //    //group.Key.SupplierId is the SupplierId value
            //    //group.Key.Country is the CountryId value
            //}


            var list = from d in dbSet.ToList()

                       group (d.Amoune) by new { d.ServicingType, d.DueDate.Month } into g

                       select new
                       {
                           ServicingType = g.Key.ServicingType,
                           Month=g.Key.Month  ,
                           Amount=g.Sum()
                       };
            return list;

        }
    }
}
