﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public IList<ProductProperties> ProductProperties { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public IList<Review> Reviews { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
        public int Count { get; set; }

        public string Category { get; set; }
    }
}
