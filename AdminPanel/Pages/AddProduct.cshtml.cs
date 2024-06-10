using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using AdminPanel.Models;

namespace AdminPanel.Pages
{
    public class AddProductModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AddProductModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            Shelves = new List<Shelf>();
        }

        [BindProperty]
        public Product Product { get; set; }

        public List<Shelf> Shelves { get; set; }

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            Shelves = await client.GetFromJsonAsync<List<Shelf>>("api/shelves");

            if (Shelves == null)
            {
                Shelves = new List<Shelf>();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = _httpClientFactory.CreateClient("WebApiClient");
            var response = await client.PostAsJsonAsync("api/products", Product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Products");
            }

            return Page();
        }
    }
}
