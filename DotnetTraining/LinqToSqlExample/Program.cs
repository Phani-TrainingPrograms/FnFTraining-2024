using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlExample
{
    interface IlinqAccess
    {
         void AddEmployee(EmpTable emp);
         void DeleteEmployee(int id);
         EmpTable GetEmployee(int id);
         List<EmpTable> GetAllEmployees();
        void UpdateEmployee(EmpTable emp);
    }

    //Todo:Implement this interface using LINQ to SQL classes and make this as a DLL. Consume this dll inside a Web API and call that web api in a mVC app to make it multi tier architecture. 

    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MydataDataContext();
            var rec = new EmpTable
            {
                DeptId = 1,
                empAddress ="Bangalore", 
                empName ="TestName",
                empSalary = 56000
            };
            context.EmpTables.InsertOnSubmit(rec);
            context.SubmitChanges();
            var empNames = context.EmpTables.ToList();
            foreach (var emp in empNames)
            {
                Console.WriteLine(emp.empName);
            }
        }
    }
}
