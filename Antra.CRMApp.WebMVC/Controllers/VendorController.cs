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
            return View(collection);
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
    }
}

