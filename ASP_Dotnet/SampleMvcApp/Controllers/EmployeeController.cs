using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Models;

namespace SampleMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
       private readonly EmployeeDbContext _employeeDbContext;

        //In real time examples, U must create a Service which implements an interface and inject the interface object into the controller. 
        public EmployeeController(EmployeeDbContext context)
        {
            this._employeeDbContext = context;
        }

        public IActionResult AllEmployees()
        {
            var employees = _employeeDbContext.Employees.ToList();
            return View(employees);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var record = _employeeDbContext.Employees.FirstOrDefault(e =>e.EmpId == id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(Employee postedData)
        {
            var id = postedData.EmpId;
            var record = _employeeDbContext.Employees.FirstOrDefault(e => e.EmpId == id);
            if (record == null)
            {
                return NotFound();
            }
            record.EmpName = postedData.EmpName;
            record.EmpAddress = postedData.EmpAddress;
            record.EmpSalary = postedData.EmpSalary;
            record.EmpImage = postedData.EmpImage;
            _employeeDbContext.SaveChanges();
            return RedirectToAction("AllEmployees");
        }

        public IActionResult AddNew() => View(new Employee());

        [HttpPost]
        public IActionResult AddNew(Employee employee)
        {
            if(employee != null)
            {
                employee.EmpImage = @"../Images/" + employee.EmpImage;
                _employeeDbContext.Employees.Add(employee);
                _employeeDbContext.SaveChanges();
            }
            return RedirectToAction("AllEmployees");
        }
    }
}
