﻿using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
   public interface IInvoiceRepository: IRepository<Invoice>
    {
        public long GetMaxBookingId();
    }
}
