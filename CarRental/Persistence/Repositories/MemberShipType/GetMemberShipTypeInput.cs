using CarRental.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.MemberShipType
{
    public class GetMemberShipTypeInput: PagedAndSortedInputDto
    {
       public byte Id;
    }
}
