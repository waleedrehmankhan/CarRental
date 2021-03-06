﻿using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence.Interfaces
{
   public interface IServiceRepository : IRepository<ServiceHistory>
    {
        public dynamic GetTotalExpenseByTypeMonthly();
        public float GetTotalExpense();

    }
}
