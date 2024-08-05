using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudEmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("cors")]
    //api/CrudEmployee/
    public class CrudEmployeeController : ControllerBase
    {
        private EmployeeDbContext _employeeDbContext;
        public CrudEmployeeController(EmployeeDbContext context) { _employeeDbContext = context; }

        [HttpGet("AllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var data = await _employeeDbContext.Employees.ToListAsync();
            return Ok(data);
        }

        [HttpGet("AllEmployees/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _employeeDbContext.Employees.FirstOrDefaultAsync((e) => e.EmpId == id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee emp)
        {
            _employeeDbContext.Employees.Add(emp);
            await _employeeDbContext.SaveChangesAsync();
            return Ok("Employee Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee emp)
        {
            var rec = await _employeeDbContext.Employees.FirstOrDefaultAsync(e => e.EmpId == emp.EmpId);
            if (rec != null)
            {
                rec.EmpSalary = emp.EmpSalary;
                rec.EmpName = emp.EmpName;
                rec.EmpAddress = emp.EmpAddress;
                await _employeeDbContext.SaveChangesAsync();
                return Ok("Employee updated Successfully");
            }
            else
            {
                return BadRequest("Employee not found to Update");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var rec = await _employeeDbContext.Employees.FirstOrDefaultAsync(e => e.EmpId == id);
            if (rec != null)
            {
                _employeeDbContext.Employees.Remove(rec);
                await _employeeDbContext.SaveChangesAsync();
                return Ok("Employee deleted successfully");
            }
            else
            {
                return BadRequest("Employee not found to delete");
            }
        }
    }
}
