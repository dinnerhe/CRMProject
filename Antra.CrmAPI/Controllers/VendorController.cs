using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antra.CrmAPI.Controllers
{
    [Route("api/[controller]")]
    public class VendorController : Controller
    {
        private readonly IVendorServiceAsync vendorService;

        public VendorController(IVendorServiceAsync _vendor) {
            vendorService = _vendor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await vendorService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await vendorService.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Vendor with Id = {id} is not available");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VendorRequestModel model)
        {
            var result = await vendorService.AddVendorAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(VendorRequestModel model)
        {
            var result = await vendorService.UpdateVendorAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await vendorService.DeleteVendorAsync(id);
            if (result > 0)
                return Ok("Vendor Deleted successfully");
            return BadRequest();
        }
    }
}

