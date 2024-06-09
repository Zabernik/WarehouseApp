using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ShelfService : IShelfService
    {
        private readonly IShelfRepository _shelfRepository;

        public ShelfService(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }

        public async Task<IEnumerable<Shelf>> GetAllAsync()
        {
            return await _shelfRepository.GetAllAsync();
        }

        public async Task<Shelf> GetByIdAsync(int id)
        {
            return await _shelfRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(CreateShelfDto dto)
        {
            var shelf = new Shelf
            {
                Capacity = dto.Capacity,
                WarehouseId = dto.WarehouseId
            };
            await _shelfRepository.AddAsync(shelf);
        }

        public async Task UpdateAsync(int id, UpdateShelfDto dto)
        {
            var shelf = await _shelfRepository.GetByIdAsync(id);
            if (shelf == null) throw new Exception("Shelf not found");

            shelf.Capacity = dto.Capacity;
            await _shelfRepository.UpdateAsync(shelf);
        }

        public async Task DeleteAsync(int id)
        {
            await _shelfRepository.DeleteAsync(id);
        }
    }

}
