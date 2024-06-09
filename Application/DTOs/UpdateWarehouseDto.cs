using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateWarehouseDto
    {
        public int Capacity { get; set; }
        public TypesOfMicroclimate TypeOfMicroclimate { get; set; }
        public TypesOfProduct TypeOfProduct { get; set; }
    }

}
