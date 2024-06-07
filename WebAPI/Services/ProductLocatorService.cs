using Grpc.Core;
using Infrastructure.Data;
using System.Threading.Tasks;
using WebAPI.GrpcServices;

public class ProductLocatorService : ProductSearchService.ProductSearchServiceBase
{
    private readonly ApplicationDbContext _context;

    public ProductLocatorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public override Task<ProductResponse> GetProductLocation(ProductRequest request, ServerCallContext context)
    {
        var product = _context.Products.FirstOrDefault(p => p.Name == request.ProductName);
        var shelf = product != null ? _context.Shelves.FirstOrDefault(s => s.Id == product.ShelfId) : null;
        var warehouse = shelf != null ? _context.Warehouses.FirstOrDefault(w => w.Id == shelf.WarehouseId) : null;

        var response = new ProductResponse
        {
            WarehouseId = warehouse?.Id.ToString() ?? string.Empty,
            ShelfId = shelf?.Id.ToString() ?? string.Empty
        };

        return Task.FromResult(response);
    }
}
