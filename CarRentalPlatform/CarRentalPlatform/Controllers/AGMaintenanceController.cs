using CarRentalPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text.Json;

namespace CarRental.MVC.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MaintenanceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult History()
        {
            return View(new List<RepairHistoryViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> History(int vehicleId)
        {
            var client = _httpClientFactory.CreateClient("MaintenanceApi");

            var repairs = await client.GetFromJsonAsync<List<RepairHistoryViewModel>>(
                $"api/maintenance/vehicles/{vehicleId}/repairs");

            return View(repairs ?? new List<RepairHistoryViewModel>());
        }


        //public async Task<IActionResult> Usage()
        //{
        //    var client = _httpClientFactory.CreateClient("MaintenanceApi");

        //    var response = await client.GetAsync("api/AGMaintenance/usage");
        //    var body = await response.Content.ReadAsStringAsync();

        //    ViewBag.Raw = body;
        //    ViewBag.Status = (int)response.StatusCode;

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        ViewBag.Error = body;
        //        return View();
        //    }

        //    var json = JsonSerializer.Deserialize<JsonElement>(body);
        //    return View(json);
        //}
       

        public async Task<IActionResult> Usage()
        {
            var client = _httpClientFactory.CreateClient("MaintenanceApi");
            var result = await client.GetAsync("api/maintenance/usage");
            return View(result);
        }

        [HttpGet]
        public IActionResult Transfer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(int fromId, int toId, decimal amount)
        {
            var client = _httpClientFactory.CreateClient("MaintenanceApi");
            var response = await client.PostAsync(
            $"api/maintenance/transfer?fromId={fromId}&toId={toId}&amount={amount}",
            null);
            var content = await response.Content.ReadAsStringAsync();
            ViewBag.Result = content;
            return View();
        }

    }
}