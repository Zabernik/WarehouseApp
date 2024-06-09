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
    public class EditProductModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditProductModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Models.Product Product { get; set; }

        public List<Models.Shelf> Shelves { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            Product = await client.GetFromJsonAsync<Models.Product>($"api/products/{id}");
            Shelves = await client.GetFromJsonAsync<List<Models.Shelf>>("api/shelves");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            await client.PutAsJsonAsync($"api/products/{Product.Id}", Product);
            return RedirectToPage("Products");
        }
    }
}

