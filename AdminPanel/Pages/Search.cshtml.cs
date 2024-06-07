using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAPI.GrpcServices;

public class SearchModel : PageModel
{
    private readonly ProductSearchClientService _clientService;

    public SearchModel(ProductSearchClientService clientService)
    {
        _clientService = clientService;
    }

    public ProductResponse? ProductLocation { get; private set; }

    public async Task OnPostAsync(string productName)
    {
        ProductLocation = await _clientService.GetProductLocationAsync(productName);
    }
}
