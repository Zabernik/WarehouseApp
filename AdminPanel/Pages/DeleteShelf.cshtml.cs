using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AdminPanel.Models;
using Domain.Entities;

namespace AdminPanel.Pages
{
    public class DeleteShelfModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteShelfModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Models.Shelf Shelf { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            Shelf = await client.GetFromJsonAsync<Models.Shelf>($"api/shelves/{id}");
            if (Shelf == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("WebApiClient");
            await client.DeleteAsync($"api/shelves/{id}");
            return RedirectToPage("Shelves");
        }
    }
}
