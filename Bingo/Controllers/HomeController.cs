using Bingo.Models;
using Bingo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Bingo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IBingoService _bingoService;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IBingoService bingoService)
        {
            _logger = logger;
            _configuration = configuration;
            _bingoService = bingoService;
        }


        public IActionResult Index()
        {
            var carton = _bingoService.CrearCarton();
            return View(carton);
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