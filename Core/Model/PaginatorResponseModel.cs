using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class PaginatorResponseModel<T>
    {
        [JsonProperty(PropertyName = "total", Required = Required.DisallowNull)]
        public int Total { get; set; }

        [JsonProperty(PropertyName = "data", Required = Required.AllowNull)]
        public IList<T> Data { get; set; }
    }
}
