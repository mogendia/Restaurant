

namespace Restaurant.Domain.Entities
{
    public class PaginationResult<T> where T : class
    {
        public List<T> Result{ get; set; }
        public int TotalCount { get; set; }
    }
}
