namespace CrudEmployeeApp.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
    }

    public static class EmployeeRepo
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee{ EmpAddress ="Bangalore", EmpId = 11, EmpName ="Robert", EmpSalary = 56000},
            new Employee{ EmpAddress ="London", EmpId = 12, EmpName ="Tony Scott", EmpSalary = 34000},
            new Employee{ EmpAddress ="New York", EmpId = 13, EmpName ="Andy Emmerson ", EmpSalary = 36000},
            new Employee{ EmpAddress ="Paris", EmpId = 14, EmpName ="Simmy Carter", EmpSalary = 40000}
        };

        public static void AddEmployee(Employee employee) => _employees.Add(employee);

        public static List<Employee> GetAll() => _employees;

        public static Employee GetById(int id) => _employees.FirstOrDefault(e => e.EmpId == id);

        public static void UpdateEmployee(Employee emp)
        {
            var found = _employees.FirstOrDefault(e => e.EmpId == emp.EmpId);
            if (found != null)
            {
                found.EmpName = emp.EmpName;
                found.EmpAddress = emp.EmpAddress;
                found.EmpSalary = emp.EmpSalary;
                return;
            }
            else throw new Exception("Employee not found to update");
        }

        public static void Delete(int id)
        {
            var found = _employees.FirstOrDefault(e => e.EmpId == id);
            if (found != null)
            {
                _employees.Remove(found);
            }
            else
            {
                throw new Exception("Employee not found to delete");
            }
        }
    }
}
