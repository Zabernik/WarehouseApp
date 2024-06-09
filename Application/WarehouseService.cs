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
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _warehouseRepository.GetAllAsync();
        }

        public async Task<Warehouse> GetByIdAsync(int id)
        {
            return await _warehouseRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(CreateWarehouseDto dto)
        {
            var warehouse = new Warehouse
            {
                Capacity = dto.Capacity,
                TypeOfMicroclimate = dto.TypeOfMicroclimate,
                TypeOfProduct = dto.TypeOfProduct
            };
            await _warehouseRepository.AddAsync(warehouse);
        }

        public async Task UpdateAsync(int id, UpdateWarehouseDto dto)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(id);
            if (warehouse == null) throw new Exception("Warehouse not found");

            warehouse.Capacity = dto.Capacity;
            warehouse.TypeOfMicroclimate = dto.TypeOfMicroclimate;
            warehouse.TypeOfProduct = dto.TypeOfProduct;
            await _warehouseRepository.UpdateAsync(warehouse);
        }

        public async Task DeleteAsync(int id)
        {
            await _warehouseRepository.DeleteAsync(id);
        }
    }

}
