using System.Collections.Generic;

namespace Core.Model
{
    public class PaginatorResponseModel<T>
    {
        public int Total { get; set; }

        public IList<T> Data { get; set; }
    }
}
