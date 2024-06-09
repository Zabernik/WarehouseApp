using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AdminPanel.Models;
using Domain.Entities;

namespace AdminPanel.Pages
{
    public class DeleteWarehouseModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteWarehouseModel(IHttpClientFactory httpClientFactory)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            await client.DeleteAsync($"api/warehouses/{id}");
            return RedirectToPage("Warehouses");
        }
    }
}
