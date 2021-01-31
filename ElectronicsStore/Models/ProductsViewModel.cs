using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Models
{
    public class ProductsViewModel
    {
        public int id { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Mark { get; set; }
        public string Details { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
    }
}
