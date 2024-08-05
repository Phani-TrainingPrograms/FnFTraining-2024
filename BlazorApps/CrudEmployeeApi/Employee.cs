using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Include the required Nuget packages for EF 8.0
namespace CrudEmployeeApi
{
    [Table("CrudEmployee")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext>options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
