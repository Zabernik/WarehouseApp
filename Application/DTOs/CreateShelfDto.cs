using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateShelfDto
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int WarehouseId { get; set; }
    }

}
