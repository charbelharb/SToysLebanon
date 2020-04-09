using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class SelectModel
    {
        [JsonProperty(PropertyName = "value", Required = Required.Always)]
        public int Value { get; set; }

        [JsonProperty(PropertyName = "viewValue", Required = Required.Always)]
        public string ViewValue { get; set; }
    }
}
