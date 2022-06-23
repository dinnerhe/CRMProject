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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServiceAsync categoryService;
        public CategoryController(ICategoryServiceAsync _category) {
            categoryService = _category;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await categoryService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await categoryService.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Category with Id = {id} is not available");
            return Ok(result);
        }
        

        [HttpPost]
        public async Task<IActionResult> Post(CategoryModel model)
        {
            if (model == null) {
                return BadRequest();
            }
            var result = await categoryService.AddCategoeyAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }
        
        

        [HttpPut]
        public async Task<IActionResult> Put(CategoryModel model)
        {
            var result = await categoryService.UpdateCategoryAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await categoryService.DeleteCategoryAsync(id);
            if (result > 0)
                return Ok("Category Deleted successfully");
            return BadRequest();
        }
    }
}

