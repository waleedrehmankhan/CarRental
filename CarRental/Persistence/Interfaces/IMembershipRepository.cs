﻿using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence.Interfaces
{
    public interface IMembershipRepository: IRepository<MembershipType>
    {
    }
}
