using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Domain.Models.Shop
{
    public class ProductsModel
    {
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Mark { get; set; }
        public string Details { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public List<byte[]> Images { get; set; }
        public string Type { get; set; }
    }
}
