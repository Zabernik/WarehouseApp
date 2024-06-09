using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IShelfRepository
    {
        Task<IEnumerable<Shelf>> GetAllAsync();
        Task<Shelf> GetByIdAsync(int id);
        Task AddAsync(Shelf shelf);
        Task UpdateAsync(Shelf shelf);
        Task DeleteAsync(int id);
    }

}
