using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Entities;

public class ProductsModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductsModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public List<Product> Products { get; set; }

    public async Task OnGetAsync()
    {
        var client = _httpClientFactory.CreateClient("WebApiClient");
        Products = await client.GetFromJsonAsync<List<Product>>("api/products");
    }
}
