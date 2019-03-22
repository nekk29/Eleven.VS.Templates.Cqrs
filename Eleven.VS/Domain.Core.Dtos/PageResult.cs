using System.Collections.Generic;

namespace $ext_safesolutionname$.Domain.Core.Dtos
{
    public class PageResult<T> where T : class
    {
        public PageResult()
        {

        }

        public long CurrentPage { get; set; }
        public long TotalPages { get; set; }
        public long TotalItems { get; set; }
        public long ItemsPerPage { get; set; }
        public List<T> Items { get; set; }
    }
}
