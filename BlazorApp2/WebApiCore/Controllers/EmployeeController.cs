using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Dtos;
using WebApiCore.Services;

namespace WebApiCore.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
           return Ok(new List<Employee>());
        }
    }
}
