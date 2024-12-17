using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class PaginationResult<T> where T : class
    {
        public List<T> Result{ get; set; }
        public int TotalCount { get; set; }
    }
}
