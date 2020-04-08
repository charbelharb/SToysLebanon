using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class ProductModel
    {
        [JsonProperty(PropertyName = "Id", Required = Required.AllowNull)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Description", Required = Required.Always)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Price", Required = Required.Always)]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "Quantity", Required = Required.Always)]
        public short Quantity { get; set; }

        [JsonProperty(PropertyName = "ImagePath", Required = Required.Always)]
        public string ImagePath { get; set; }

        [JsonProperty(PropertyName = "ResizedImagePath", Required = Required.Always)]
        public string ResizedImagePath { get; set; }

        [JsonProperty(PropertyName = "Gender", Required = Required.Always)]
        public Gender Gender { get; set; }

        [JsonProperty(PropertyName = "Age", Required = Required.Always)]
        public Age Age { get; set; }

        [JsonProperty(PropertyName = "Category", Required = Required.Always)]
        public Category Category { get; set; }
    }
}
