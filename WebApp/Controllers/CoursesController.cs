﻿using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{

    [Authorize]
    public class CoursesController(HttpClient http) : Controller
    {
        private readonly HttpClient _http = http;
        private string _categoryApiUrl = "https://localhost:7134/api/Categories";
        private string _courseApiUrl = "https://localhost:7134/api/Courses";

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

            var courseResponse = await _http.GetAsync(_courseApiUrl);
            if (courseResponse.IsSuccessStatusCode)
            {
                var courses = JsonConvert.DeserializeObject<IEnumerable<Course>>(await courseResponse.Content.ReadAsStringAsync());
                if (courses != null)
                    viewModel.Courses = courses;
            }

            return View(viewModel);
        }
    }
}
