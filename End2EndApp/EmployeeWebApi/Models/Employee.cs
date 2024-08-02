namespace EmployeeWebApi.Models
{
    public class Employee
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public string empAddress { get; set; }
        public decimal empSalary { get; set; }

        public int deptId { get; set; }
    }
}
