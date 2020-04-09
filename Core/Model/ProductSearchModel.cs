using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class ProductSearchModel : PaginatorModel
    {
        public int Gender { get; set; }

        public int Age { get; set; }

        public int Category { get; set; }

        public int SortBy { get; set; }

        public int Direction { get; set; }

        public string SearchText { get;set; }

    }
}
