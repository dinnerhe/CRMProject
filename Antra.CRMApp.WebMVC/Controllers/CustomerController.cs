using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServiceAsync customerServiceAsync;
        private readonly IRegionServiceAsync regionServiceAsync;

        public CustomerController(ICustomerServiceAsync cus, IRegionServiceAsync reg) {
            customerServiceAsync = cus;
            regionServiceAsync = reg;
        }

        public async Task<IActionResult> Index()
        {
            var collection = await customerServiceAsync.GetAllAsync();
            if(collection != null) return View(collection);
            List<CustomerResponseModel> model = new List<CustomerResponseModel>();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create() {
            var regionCollection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(regionCollection, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequestModel model)
        {
            if (ModelState.IsValid) {
                await customerServiceAsync.AddCustomerAsync(model);
                return RedirectToAction("Index");
            }
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id) {

            await customerServiceAsync.DeleteCustomerAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            ViewBag.isEdit = false;
            var cusModel = await customerServiceAsync.GetCustomerForEditAsync(id);
            var regionCollection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(regionCollection, "Id", "Name");
            return View(cusModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerRequestModel model)
        {
            ViewBag.IsEdit = false;
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            if (ModelState.IsValid)
            {
                await customerServiceAsync.UpdateCustomerAsync(model);
                ViewBag.IsEdit = true;

            }

            return View(model);
        }
    }
}

