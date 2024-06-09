using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AdminPanel.Models;
using Domain.Entities;

namespace AdminPanel.Pages
{
    public class EditWarehouseModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditWarehouseModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Models.Warehouse Warehouse { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            Warehouse = await client.GetFromJsonAsync<Models.Warehouse>($"api/warehouses/{id}");
            if (Warehouse == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            await client.PutAsJsonAsync($"api/warehouses/{Warehouse.Id}", Warehouse);
            return RedirectToPage("Warehouses");
        }
    }
}
