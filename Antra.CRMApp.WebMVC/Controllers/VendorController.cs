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
    public class VendorController : Controller
    {
        private readonly IVendorServiceAsync vendorService;

        public VendorController(IVendorServiceAsync vendor) {
            vendorService = vendor;
        }

        public async Task<IActionResult> Index()
        {
            var collection = await vendorService.GetAllAsync();
            if(collection != null) return View(collection);
            return View(new List<VendorResponseModel>());
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VendorRequestModel model) {
            if (ModelState.IsValid) {
                await vendorService.AddVendorAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            ViewBag.IsEdit = false;
            var model = await vendorService.GetVendorForEditAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VendorRequestModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid) {
                await vendorService.UpdateVendorAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id) {
            await vendorService.DeleteVendorAsync(id);
            return RedirectToAction("Index");
        }
    }
}

