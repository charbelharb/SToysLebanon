using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class PaginatorModel
    {
        [JsonProperty(PropertyName = "pageSize", Required = Required.Always)]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "pageIndex", Required = Required.Always)]
        public int PageIndex { get; set; }
    }
}
