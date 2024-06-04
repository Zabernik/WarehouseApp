using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Value { get; set; }
        public int Weight { get; set; }
        public DateOnly ExpireDate { get; set; }
        public TypesOfMicroclimate TypeOfDetention { get; set; }
        public TypesOfProduct TypeOfProduct { get; set; }
    }
}
