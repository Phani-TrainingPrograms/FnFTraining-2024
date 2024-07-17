
using DataAccessRecap.Data;
using DataAccessRecap.Models;
using DataAccessRecap.Services;
using Microsoft.Extensions.DependencyInjection;

namespace RecapConsole
{
    internal class Program
    {
        private static IDataService service;
        private static ServiceProvider CreateServices()
        {
            var services = new ServiceCollection()
                .AddDbContext<StudentDbContext>()
                .AddSingleton<IDataService, StudentDataService>()
                .BuildServiceProvider();
            return services;            
        }

        static void Main(string[] args)
        {
            var services = CreateServices();
            service = services.GetRequiredService<IDataService>();
            testForUpdation();
            testForReading();
            //testForInsertion();
        }

        private static void testForUpdation()
        {
            try
            {
                var student = new Student
                {
                    ContactNo = 9999933333,
                    StudentEmail = "phanirajbn@gmail.com",
                    StudentName = "Phaniraj B.N.",
                    StudentId = 1
                };
                service.UpdateStudent(student);
                Console.WriteLine("Student is updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void testForReading()
        {
            try
            {
                //var component =new StudentDataService(new StudentDbContext());
                var records = service.GetAllStudents();
                foreach (var record in records)
                {
                    Console.WriteLine($"{record.StudentName} can be contacted at {record.ContactNo}");
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static void testForInsertion()
        {
            try
            {
                var student = new Student
                {
                    ContactNo = 9844523455,
                    StudentEmail = "srujjan@gmail.com",
                    StudentName = "Srujjan Kulkarni"
                };
                //var context = new StudentDbContext();
                //service = new StudentDataService(context);
                service.AddNewStudent(student);
                Console.WriteLine("Student Added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

    }
}
