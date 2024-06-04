﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rack
    {
        public int Id { get; set; }
        public int capacity { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
