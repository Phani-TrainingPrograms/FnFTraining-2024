using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleMvcApp.Models
{
    [Table("EmployeeTable")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public string EmpAddress { get; set; } = string.Empty;
        public  int EmpSalary { get; set; }
        public string EmpImage { get; set; } = string.Empty;

    }

    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        //Use this constructor for DI of Configuration in the Program.cs
        public EmployeeDbContext(DbContextOptions options) :base(options)
        {
            
        }
    }
}
