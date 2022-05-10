using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherApp.Models;
using System.Net;
using Newtonsoft.Json;


namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Results(string city)
        {
            if( city != null)
            {
                using (WebClient web = new WebClient())
                {
                    string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&units=imperial&appid={1}", city, "700502a66a4f346702277feff64c0462");
                    try
                    {
                        var json = web.DownloadString(url);
                        WeatherData.root data = JsonConvert.DeserializeObject<WeatherData.root>(json);
                        city = char.ToUpper(city[0]) + city.Substring(1);
                        data.name = city;

                        return View(data);
                    }
                    catch(WebException e)
                    {
                        // Generally used if a city is misspelled.
                        Debug.WriteLine("There was an exception. Message: " + e.Message);
                        return View("Index");
                    }

                }
            }
            return View("Index");
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