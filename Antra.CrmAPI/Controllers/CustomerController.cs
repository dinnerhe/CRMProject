using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antra.CrmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync customerServiceAsync;

        public CustomerController(ICustomerServiceAsync _customer) { customerServiceAsync = _customer; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await customerServiceAsync.GetAllAsync());
        }

        [HttpGet]
        [Route("{id: int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await customerServiceAsync.GetByIdAsync(id);
            if (item != null) {
                return Ok(item);
            }
            return NotFound($"Customer with Id = {id} is not available");
        }
        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequestModel model) {
            var result = await customerServiceAsync.AddCustomerAsync(model);
            if (result > 0) return Ok(model);
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Put(CustomerRequestModel model) {
            var result = await customerServiceAsync.UpdateCustomerAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var result = await customerServiceAsync.DeleteCustomerAsync(id);
            if (result > 0)
                return Ok("Customer Deleted successfully");
            return BadRequest();
        }
    }
}

