using Microsoft.AspNetCore.Mvc;
using PracticeProject.Models;
using PracticeProject.Services.Interfaces;
using System.Diagnostics;

namespace PracticeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEntityService service;
        public HomeController(ILogger<HomeController> logger, IEntityService service)
        {
            this._logger = logger;
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var models = await service.GetAll();
            return View(models);
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
