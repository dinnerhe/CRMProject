using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.WebMVC.Models;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServiceAsync productService;
        private readonly IVendorServiceAsync vendorService;
        private readonly ICategoryServiceAsync categoryService;

        public ProductController(IProductServiceAsync pro, IVendorServiceAsync ven, ICategoryServiceAsync cat) {
            productService = pro;
            vendorService = ven;
            categoryService = cat;
        }

        public async Task<IActionResult> Index()
        {
            var collection = await productService.GetAllAsync();
            if(collection != null) return View(collection);
            return View(new List<ProductResponseModel>());
        }
        public IActionResult Detail()
        {
            ViewData["Title"] = "Product/Details";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var cateoryModels = await categoryService.GetAllAsync();
            var vendorModels = await vendorService.GetAllAsync();
            ViewBag.Categories = new SelectList(cateoryModels, "Id", "Name");
            ViewBag.Vendors = new SelectList(vendorModels, "Id", "Name");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await productService.AddProductAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var productModel = await productService.GetProductForEditAsync(id);
            var cateoryModels = await categoryService.GetAllAsync();
            var vendorModels = await vendorService.GetAllAsync();
            ViewBag.Categories = new SelectList(cateoryModels, "Id", "Name");
            ViewBag.Vendors = new SelectList(vendorModels, "Id", "Name");
            return View(productModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductRequestModel model) { 
            ViewBag.IsEdit = false;
            var cateoryModels = await categoryService.GetAllAsync();
            var vendorModels = await vendorService.GetAllAsync();
            ViewBag.Categories = new SelectList(cateoryModels, "Id", "Name");
            ViewBag.Vendors = new SelectList(vendorModels, "Id", "Name");
            if (ModelState.IsValid) {
                await productService.UpdateProductAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id) {
            await productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id) {
            var item = await productService.GetByIdAsync(id);
            var category = await categoryService.GetByIdAsync(item.CategoryId);
            var vendor = await vendorService.GetByIdAsync(item.VendorId);
            ViewData["Category"] = category.Name;
            ViewData["Vendor"] = vendor.Name;
            return View(item);
        }
    }
}
