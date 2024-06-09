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
    public class EditShelfModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditShelfModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Models.Shelf Shelf { get; set; }

        public List<Models.Warehouse> Warehouses { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            Shelf = await client.GetFromJsonAsync<Models.Shelf>($"api/shelves/{id}");
            Warehouses = await client.GetFromJsonAsync<List<Models.Warehouse>>("api/warehouses");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            await client.PutAsJsonAsync($"api/shelves/{Shelf.Id}", Shelf);
            return RedirectToPage("Shelves");
        }
    }
}
