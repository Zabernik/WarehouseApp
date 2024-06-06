using Grpc.Core;
using WebAPI.Protos;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using static WebAPI.Protos.WarehouseService;
using Microsoft.Extensions.Logging;

public class WarehouseService : WarehouseServiceBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<WarehouseService> _logger;

    public WarehouseService(ApplicationDbContext context, ILogger<WarehouseService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public override async Task<ProductResponse> GetProduct(ProductRequest request, ServerCallContext context)
    {
        try
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Product not found"));
            }

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Weight = product.Weight,
                Value = (double)product.Value,
                ExpireDate = product.ExpireDate.ToString("yyyy-MM-dd"),
                TypeOfDetention = product.TypeOfDetention.ToString(),
                TypeOfProduct = product.TypeOfProduct.ToString(),
                ShelfId = product.ShelfId
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetProduct");
            throw new RpcException(new Status(StatusCode.Unknown, "An error occurred while processing the request"));
        }
    }

    public override async Task<ProductResponse> CreateProduct(ProductCreateRequest request, ServerCallContext context)
    {
        try
        {
            var product = new Product
            {
                Name = request.Name,
                Weight = request.Weight,
                Value = (decimal)request.Value,
                ExpireDate = DateTime.Parse(request.ExpireDate),
                TypeOfDetention = Enum.Parse<TypesOfMicroclimate>(request.TypeOfDetention),
                TypeOfProduct = Enum.Parse<TypesOfProduct>(request.TypeOfProduct),
                ShelfId = request.ShelfId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Weight = product.Weight,
                Value = (double)product.Value,
                ExpireDate = product.ExpireDate.ToString("yyyy-MM-dd"),
                TypeOfDetention = product.TypeOfDetention.ToString(),
                TypeOfProduct = product.TypeOfProduct.ToString(),
                ShelfId = product.ShelfId
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in CreateProduct");
            throw new RpcException(new Status(StatusCode.Unknown, "An error occurred while processing the request"));
        }
    }
}
