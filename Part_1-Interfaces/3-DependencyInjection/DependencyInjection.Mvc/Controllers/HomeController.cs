using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Mvc.Models;
using DependencyInjection.WeatherProvider;

namespace DependencyInjection.Mvc.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(IWeatherClient weatherClient)
        {
            WeatherClient = weatherClient;
        }


        private IWeatherClient WeatherClient { get; set; }

        public IActionResult Index(String zipCode = "60605")
        {
            var response = WeatherClient.GetWeather(zipCode);

            var model = new HomeIndexViewModel() { ZipCode = zipCode, WeatherData = response };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
