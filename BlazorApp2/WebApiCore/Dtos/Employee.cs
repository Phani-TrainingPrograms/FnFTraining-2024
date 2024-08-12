namespace WebApiCore.Dtos
{
    public class Employee
    {
        public int EmpId { get; set; }

        public string EmpName { get; set; } = null!;

        public string EmpAddress { get; set; } = null!;

        public decimal EmpSalary { get; set; }

        public int DeptId { get; set; }
    }

    public class Dept
    {
        public int DeptId { get; set; }

        public string Deptname { get; set; } = null!;
    }

    //Next Step: Create the Services Folder and create an interface for a Service and an Impl Class that implements the service to perform the Crud operations.
}
