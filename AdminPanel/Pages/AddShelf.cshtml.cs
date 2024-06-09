using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AdminPanel.Models;
using System.Collections.Generic;
using Domain.Entities;

namespace AdminPanel.Pages
{
    public class AddShelfModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AddShelfModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Models.Shelf Shelf { get; set; }

        public List<Models.Warehouse> Warehouses { get; set; }

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            Warehouses = await client.GetFromJsonAsync<List<Models.Warehouse>>("api/warehouses");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            await client.PostAsJsonAsync("api/shelves", Shelf);
            return RedirectToPage("Shelves");
        }
    }
}
