using Grpc.Net.Client;
using System.Threading.Tasks;
using WebAPI.GrpcServices;

public class ProductSearchClientService
{
    private readonly ProductSearchService.ProductSearchServiceClient _client;

    public ProductSearchClientService()
    {
        var channel = GrpcChannel.ForAddress("https://localhost:7184");
        _client = new ProductSearchService.ProductSearchServiceClient(channel);
    }

    public async Task<ProductResponse> GetProductLocationAsync(string productName)
    {
        var request = new ProductRequest { ProductName = productName };
        return await _client.GetProductLocationAsync(request);
    }
}
