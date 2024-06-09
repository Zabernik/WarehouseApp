using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AdminPanel.Models;
using Domain.Entities;

namespace AdminPanel.Pages
{
    public class AddWarehouseModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AddWarehouseModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Models.Warehouse Warehouse { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            await client.PostAsJsonAsync("api/warehouses", Warehouse);
            return RedirectToPage("Warehouses");
        }
    }
}
