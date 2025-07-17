using Microsoft.AspNetCore.Mvc;
using PracticeProject.Models;
using PracticeProject.Services.Interfaces;

namespace PracticeProject.Controllers
{
    public class EntitiesController : Controller
    {
        private IEntityService service;
        public EntitiesController(IEntityService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new EntityViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(EntityViewModel model)
        {
            if (ModelState.IsValid == false) 
            {
                return View(model);
            }

            await service.Create(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("View")]
        public async Task<IActionResult> ViewPage(string entityId)
        {
            var model = await service.GetById(entityId);

            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
