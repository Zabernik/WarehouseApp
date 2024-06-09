using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AdminPanel.Models;

namespace AdminPanel.Pages
{
    public class AddProductModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AddProductModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Product Product { get; set; }
        public List<Shelf> Shelves { get; set; }

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            Shelves = await client.GetFromJsonAsync<List<Shelf>>("api/shelves");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            await client.PostAsJsonAsync("api/products", Product);
            return RedirectToPage("Products");
        }
    }
}
