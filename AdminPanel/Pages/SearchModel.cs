using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebAPI.GrpcServices;

namespace AdminPanel.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ProductSearchClientService _clientService;

        public SearchModel(ProductSearchClientService clientService)
        {
            _clientService = clientService;
        }

        [BindProperty]
        public string? ProductName { get; set; }

        public ProductResponse? ProductLocation { get; private set; }

        public async Task OnPostAsync()
        {
            if (!string.IsNullOrWhiteSpace(ProductName))
            {
                ProductLocation = await _clientService.GetProductLocationAsync(ProductName);
            }
        }
    }
}
