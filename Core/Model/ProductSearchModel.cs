using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class ProductSearchModel : PaginatorModel
    {
        [JsonProperty(PropertyName = "selectedGender", Required = Required.Always)]
        public int Gender { get; set; }

        [JsonProperty(PropertyName = "selectedAge", Required = Required.Always)]
        public int Age { get; set; }

        [JsonProperty(PropertyName = "selectedCategory", Required = Required.Always)]
        public int Category { get; set; }

        [JsonProperty(PropertyName = "selectedSortBy", Required = Required.Always)]
        public int SortBy { get; set; }

        [JsonProperty(PropertyName = "selectedDirection", Required = Required.Always)]
        public int Direction { get; set; }

        [JsonProperty(PropertyName = "textSearch", Required = Required.AllowNull)]
        public string SearchText { get;set; }

    }
}
