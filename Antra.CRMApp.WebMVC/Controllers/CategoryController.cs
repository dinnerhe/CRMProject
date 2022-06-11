using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServiceAsync categoryService;

        public CategoryController(ICategoryServiceAsync service) {
            categoryService = service;
        }

        public async Task<IActionResult> Index()
        {
            var collection = await categoryService.GetAllAsync();
            return View(collection);
        }
        [HttpGet]
        public IActionResult Create() {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel model) {
            if (ModelState.IsValid) {

                await categoryService.AddCategoeyAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}

