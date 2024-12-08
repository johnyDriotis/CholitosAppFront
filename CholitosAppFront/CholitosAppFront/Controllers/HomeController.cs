using CholitosAppFront.Models;
using CholitosAppFront.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CholitosAppFront.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly ITestConnection _connection;

        public HomeController(/*ILogger<HomeController> logger*/ ITestConnection connection)
        {
            //_logger = logger;
            this._connection = connection;
        }

        public IActionResult Index()
        {
            string conexionExitosa = "";

            conexionExitosa = _connection.ConnectToDatabase();

            ViewData["MsjConexion"] = conexionExitosa; 

            return View();
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
