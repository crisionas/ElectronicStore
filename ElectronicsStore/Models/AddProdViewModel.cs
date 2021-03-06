﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Models
{
    public class AddProdViewModel
    {
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Mark { get; set; }
        public string Details { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public byte[] Images { get; set; }
        public string Type { get; set; }
    }
}
