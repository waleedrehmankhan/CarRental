using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Helpers
{
    public class PagedAndSortedInputDto
    {
        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }
        public string Sorting { get; set; }
        public int pagenumber { get; set; }
        public int pagesize { get; set; }
        public PagedAndSortedInputDto()
        {
            MaxResultCount = 10;
            Normalize();
        }
        public virtual void Normalize()
        {

        }
    }
}
