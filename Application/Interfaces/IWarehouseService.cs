using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task<Warehouse> GetByIdAsync(int id);
        Task CreateAsync(CreateWarehouseDto dto);
        Task UpdateAsync(int id, UpdateWarehouseDto dto);
        Task DeleteAsync(int id);
    }

}
