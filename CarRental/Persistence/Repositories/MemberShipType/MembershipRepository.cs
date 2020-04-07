using CarRental.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Data;

namespace CarRental.Persistence.Repositories.MemberShipType
{
    public class MembershipRepository: Repository<MembershipType>, IMembershipRepository
    {

        public MembershipRepository(ApplicationDbContext context)
          : base(context)
        {
        }
    }
}
