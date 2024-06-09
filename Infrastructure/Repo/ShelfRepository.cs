using Domain.Entities;
using Domain.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly ApplicationDbContext _context;

        public ShelfRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shelf>> GetAllAsync()
        {
            return await _context.Shelves.ToListAsync();
        }

        public async Task<Shelf> GetByIdAsync(int id)
        {
            return await _context.Shelves.FindAsync(id);
        }

        public async Task AddAsync(Shelf shelf)
        {
            _context.Shelves.Add(shelf);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shelf shelf)
        {
            _context.Shelves.Update(shelf);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var shelf = await _context.Shelves.FindAsync(id);
            if (shelf != null)
            {
                _context.Shelves.Remove(shelf);
                await _context.SaveChangesAsync();
            }
        }
    }

}
