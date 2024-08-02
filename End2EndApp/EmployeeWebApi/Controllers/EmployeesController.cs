using EmployeeWebApi.Models;
using LinqToSqlLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeDbApi.Controllers
{
    //Project type:ASP.NET Web Application, select WebAPI check box. 
    //Add the reference of the Dll
    //Drag and Drop the Dto class that was created in the Api Core project. 
    //Create a new Api Controller ->Right click on Controllers folder and select WebAPI v2 Empty Controller. 
    public class EmployeesController : ApiController
    {
        private IEmployeeDataAccess dataAccess = new EmployeeDataAccess();  
 
        //api/Employees
        public List<Employee> GetAll()
        {
            var records = from emp in dataAccess.GetAllEmployees().DefaultIfEmpty()
                          select new Employee
                          {
                              deptId = emp.DeptId == null ? 0 : emp.DeptId.Value,
                              empAddress = emp.empAddress,
                              empName = emp.empName,
                              empId = emp.empId,
                              empSalary = emp.empSalary
                          };
            return records.ToList();
        }

        //api/Employees/id
        [HttpGet]
        public Employee Find(int id)
        {
            var record = dataAccess.GetEmployeeById(id);
            return new Employee
            {
                deptId = record.DeptId == null ? 0 : record.DeptId.Value,
                empAddress = record.empAddress,
                empName = record.empName,
                empId = record.empId,
                empSalary = record.empSalary
            };
        }

        [HttpPost]
        public string AddEmployee(Employee emp)
        {
            try
            {
                //convert the Employee to EmpTable object
                EmpTable row = new EmpTable();
                row.DeptId = emp.deptId;
                row.empName = emp.empName;
                row.empSalary = emp.empSalary;
                row.empAddress = emp.empAddress;
                //Call the dll's function to add the record
                dataAccess.AddEmployee(row);
                //return success message
                //else return ex.Message
                return "Employee added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete]
        public string DeleteEmployee(int id)
        {
            try
            {
                dataAccess.DeleteEmployee(id);
                return "Employee deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPut]
        //api/Employees/id
        public string UpdateEmployee(int id, Employee emp)
        {
            try
            {
                dataAccess.UpdateEmployee(new EmpTable {DeptId = emp.deptId, empAddress = emp.empAddress, empName = emp.empName, empSalary = emp.empSalary, empId = id});
            return "Employee updated successfully";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
