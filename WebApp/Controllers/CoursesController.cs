using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CoursesController(HttpClient http) : Controller
    {
        private readonly HttpClient _http = http;
        private string _categoryApiUrl = "https://localhost:7134/api/Categories";

        public async Task<IActionResult> Index()
        {
            var viewModel = new CoursesViewModel();

            var categoryResponse = await _http.GetAsync(_categoryApiUrl);
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(await categoryResponse.Content.ReadAsStringAsync());
                if (categories != null)
                    viewModel.Categories = categories;
            }



            return View(viewModel);
        }
    }
}
