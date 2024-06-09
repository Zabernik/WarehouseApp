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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Value = dto.Value,
                Weight = dto.Weight,
                ExpireDate = dto.ExpireDate,
                TypeOfDetention = dto.TypeOfDetention,
                TypeOfProduct = dto.TypeOfProduct,
                ShelfId = dto.ShelfId
            };
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new Exception("Product not found");

            product.Name = dto.Name;
            product.Value = dto.Value;
            product.Weight = dto.Weight;
            product.ExpireDate = dto.ExpireDate;
            product.TypeOfDetention = dto.TypeOfDetention;
            product.TypeOfProduct = dto.TypeOfProduct;

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }

}
