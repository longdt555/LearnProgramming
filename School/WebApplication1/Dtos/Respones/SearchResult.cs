using System.Collections.Generic;

namespace StoreManagement.Dtos.Respones
{
    public class SearchResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
