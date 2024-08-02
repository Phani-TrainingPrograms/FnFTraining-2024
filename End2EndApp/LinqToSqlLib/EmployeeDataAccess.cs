using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlLib
{
    public interface IEmployeeDataAccess
    {
        void AddEmployee(EmpTable emp);
        void DeleteEmployee(int id);
        List<EmpTable> GetAllEmployees();
        EmpTable GetEmployeeById(int id);
        void UpdateEmployee(EmpTable emp);
    }

    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private EmployeeDbDataContext context = new EmployeeDbDataContext();
        public List<EmpTable> GetAllEmployees() => context.EmpTables.ToList();

        public EmpTable GetEmployeeById(int id) => context.EmpTables.FirstOrDefault(e => e.empId == id);

        public void AddEmployee(EmpTable emp)
        {
            context.EmpTables.InsertOnSubmit(emp);//Insert to the collection
            context.SubmitChanges();//Updating to the database
        }

        public void DeleteEmployee(int id)
        {
            var rec = context.EmpTables.FirstOrDefault(e => e.empId == id);
            if (rec == null)
            {
                throw new Exception("Record not found to delete");
            }
            context.EmpTables.DeleteOnSubmit(rec);
            context.SubmitChanges();
        }

        public void UpdateEmployee(EmpTable emp)
        {
            //find the matching record.
            //set the new values taken from the parameter record. 
            //Submit the changes. 
            throw new NotImplementedException("Expected to be done by the trainee");
        }
    }
}
