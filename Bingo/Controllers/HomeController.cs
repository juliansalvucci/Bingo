using Bingo.Models;
using Bingo.Services;
using Bingo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bingo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBingoService _bingoService;

        public HomeController(IBingoService bingoService)
        {
            _bingoService = bingoService;
        }

        public IActionResult Index()
        {
            var viewModel = new CartonViewModel();
            viewModel.Carton1 = _bingoService.CrearCarton();
            viewModel.Carton2 = _bingoService.CrearCarton();
            viewModel.Carton3 = _bingoService.CrearCarton();
            viewModel.Carton4 = _bingoService.CrearCarton();
            return View(viewModel);
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