using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using WebAPI.Protos;
using static WebAPI.Protos.WarehouseService;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7184");
            var client = new WarehouseServiceClient(channel);

            var productRequest = new ProductRequest { Id = 1 };

            try
            {
                var productResponse = await client.GetProductAsync(productRequest);
                Console.WriteLine($"Product Name: {productResponse.Name}");
            }
            catch (RpcException ex)
            {
                Console.WriteLine($"Error: {ex.Status.Detail}");
            }
            Console.ReadLine();
        }
    }
}
