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
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }
        public string Type { get; set; }
    }
}
