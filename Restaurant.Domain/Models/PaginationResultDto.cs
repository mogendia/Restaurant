using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Models
{
    public class PaginationResultDto<T>
    {
        
            public List<T> Result { get; set; }
            public int TotalCount { get; set; }
        
    }
}
