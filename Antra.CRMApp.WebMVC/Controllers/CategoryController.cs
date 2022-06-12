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
            if(collection != null) return View(collection);
            return View(new List<CategoryModel>());
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var model = await categoryService.GetCategoryForEditAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await categoryService.UpdateCategoryAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }

    }
}

