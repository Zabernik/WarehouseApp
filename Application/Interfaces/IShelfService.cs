using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IShelfService
    {
        Task<IEnumerable<Shelf>> GetAllAsync();
        Task<Shelf> GetByIdAsync(int id);
        Task CreateAsync(CreateShelfDto dto);
        Task UpdateAsync(int id, UpdateShelfDto dto);
        Task DeleteAsync(int id);
    }

}
