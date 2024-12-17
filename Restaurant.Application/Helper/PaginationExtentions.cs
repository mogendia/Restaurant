using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Helper
{
    public static class PaginationExtentions
    {
     public static PaginationResult<T> Pagination<T>(this IEnumerable<T> source, int pageNumber = 1, int pageSize = 10) where T : class
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;
            var count = source.Count();
            var totalCount = (int)Math.Ceiling((double)count / pageSize);
            var result = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            PaginationResult<T> results = new PaginationResult<T> {Result = result, TotalCount = totalCount };
            return results;
                
        }
    }
}
