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
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync productService;

        public ProductController(IProductServiceAsync _product) { productService = _product; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await productService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await productService.GetByIdAsync(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound($"Product with Id = {id} is not available");
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestModel model)
        {
            var result = await productService.AddProductAsync(model);
            if (result > 0) return Ok(model);
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Put(ProductRequestModel model)
        {
            var result = await productService.UpdateProductAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await productService.DeleteProductAsync(id);
            if (result > 0)
                return Ok("Product Deleted successfully");
            return BadRequest();
        }
    }
}

