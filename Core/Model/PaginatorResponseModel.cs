using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class PaginatorResponseModel<T>
    {
        public int Total { get; set; }

        public IList<T> Data { get; set; }
    }
}
