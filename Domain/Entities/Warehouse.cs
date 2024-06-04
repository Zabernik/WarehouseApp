using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public TypesOfMicroclimate TypeOfMicroclimate { get; set; }
        public TypesOfProduct TypeOfProduct { get; set; }
    }
}
