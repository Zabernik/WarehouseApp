using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AdminPanel.Models;
using Domain.Entities;

namespace AdminPanel.Pages
{
    public class DeleteProductModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteProductModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Models.Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            Product = await client.GetFromJsonAsync<Models.Product>($"api/products/{id}");
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            await client.DeleteAsync($"api/products/{id}");
            return RedirectToPage("Products");
        }
    }
}
