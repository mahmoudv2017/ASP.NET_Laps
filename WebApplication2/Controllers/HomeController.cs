using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TryingOut.Lab1Entities;
using WebApplication2.Models;


namespace WebApplication2.Controllers
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
            List<Car> cars = Car.GetCars();
            return View(cars);
        }

        public IActionResult carDetails(string image , string? type)
        {
            Car car = Car.GetCars().FirstOrDefault(c => c.Image == image);

            Console.WriteLine("asd");

            var CarSData = new 
            {
                car,
                type
            };

            return View("CarDetail", CarSData);
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