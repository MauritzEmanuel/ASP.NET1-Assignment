using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers;

public class SubscribeController(HttpClient htpp) : Controller
{
    private readonly HttpClient _htpp = htpp;

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeForm form)
    {
        if (ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(form), Encoding.UTF8, "application/json");
            var response = await _htpp.PostAsync("https://localhost:7134/api/Subscribe", content);
            if (response.IsSuccessStatusCode)
            {
                TempData["Status"] = "You are now subscribed";
                return RedirectToAction("Home", "Default", "subscribe");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                TempData["Status"] = "You are already subscribed";
                return RedirectToAction("Home", "Default", "subscribe");
            }
        }
        TempData["Status"] = "Something went wrong";
        return RedirectToAction("Home", "Default");

    }
}
