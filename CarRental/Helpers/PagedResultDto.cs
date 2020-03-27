using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Helpers
{
    public class PagedResultDto<T>
    {
        public IQueryable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResultDto() { }
        public PagedResultDto(IQueryable<T> source, int pageNumber, int pageSize)
        {
            this.TotalCount = source.Count();
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Items = pageSize == 0 && pageNumber == 0 ? source : (source
                            .Skip(pageSize * (pageNumber - 1))
                            .Take(pageSize));


        }
    }
}
