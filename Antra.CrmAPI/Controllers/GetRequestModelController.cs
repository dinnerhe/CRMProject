using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antra.CrmAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetRequestModelController : ControllerBase
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public GetRequestModelController(IEmployeeServiceAsync empservice)
        {
            employeeServiceAsync = empservice;
        }


        [HttpGet]
        [Route("{id:int}")]
        [ActionName("requestEmployee")]
        public async Task<IActionResult> requestEmployee(int id)
        {
            //var item = await employeeServiceAsync.GetEmployeeForEditAsync(id);
            var item = await employeeServiceAsync.GetEmployeeForEditAsync(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound($"Employee with Id = {id} is not available");
        }
    }
}

