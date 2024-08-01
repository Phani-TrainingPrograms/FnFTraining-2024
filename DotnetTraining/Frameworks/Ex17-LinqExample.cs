using FrameworkExamples.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Xml.Linq;

//Language integrated Queries provides functions and keywords to perform query based operations on collection objects of .NET. 
//if U have all records from the database stored into a Entity component like List<T>, Dictionary<K, V>, then U can perform queries on the obtained data for UR business requirements. 
namespace FrameworkExamples
{
    using Data;
    using System.ComponentModel.DataAnnotations;

    internal class Ex17_LinqExample
    {
        public static IConfigurationRoot? Configuration { get; set; }

        private static LinqRepo repo = null;
        private static void Init()
        {
           
            var config = new ConfigurationBuilder()
               .SetBasePath("C:\\Trainings\\FnfTraining\\FnFTraining-2024\\DotnetTraining\\Ex02-FrameworkExamples")
               .AddJsonFile("appsettings.json", false)
               .Build();
            Configuration = config;
            var fileName = Configuration["FileOptions:linqCsv"];
            repo = new LinqRepo(fileName);
        }

        
        static void Main()
        {
            //firstExample();
            Init();
            //Display all the employee names:
            var empList = repo.Employees;

            //displayNamesAndCities(empList);
            //searchByCity(empList, "Lucknow");
            //orderByCity(empList);
            //groupEmployeesByCity(empList);
            //joinsExample();
            //groupJoinExample();
            //leftJoinExample();
            //allDeptsWithEmpList();
            convertToXml();
        }

        private static void convertToXml()
        {
            var empList = repo.Employees;
            var xml = new XElement("EmployeeList",
                from emp in empList
                select new XElement("Employee",
                      new XElement("Id", emp.EmpId),
                      new XElement("Name", emp.EmpName),
                      new XElement("City", emp.EmpCity),
                      new XElement("Salary", emp.EmpSalary),
                      new XElement("DeptId", emp.DeptId)
                  ));
            xml.Save("Employees.xml");
            Console.WriteLine(xml);

            var empNames = from emp in xml.Descendants("Employee")
                           select emp.Element("Name");
            foreach (var tag in empNames)
            {
                Console.WriteLine(tag.Value);
            }
        }

        //All Depts along with their employees
        private static void allDeptsWithEmpList()
        {
            var empList = repo.Employees;
            var depts = repo.Departments;

            var results = from dept in depts
                          join emp in empList
                          on dept.DeptId equals emp.DeptId into temp
                          from de in temp.DefaultIfEmpty()
                          select new
                          {
                              Name = de != null ? de.EmpName : "NULL",
                              Dept = dept.DeptName
                          };
            foreach (var dept in results)
            {
                Console.WriteLine(dept);
            }


        }

        private static void leftJoinExample()
        {
            var emplist = repo.Employees;
            var depts = repo.Departments;
            var results = from emp in emplist
                          join dept in depts
                          on emp.DeptId equals dept.DeptId into temp                   
                          from copy in temp.DefaultIfEmpty()
                          select new
                          {
                              Name = emp.EmpName,
                              Dept = copy == null ? "Not assigned" : copy.DeptName
                          };
            foreach (var rec in results)
            {
                Console.WriteLine(rec);
            }
        }

        private static void groupJoinExample()
        {
            var emplist = repo.Employees;
            var depts = repo.Departments;
            var query = from dept in depts
                        join emp in emplist
                        on dept.DeptId equals emp.DeptId
                        group new
                        {
                            emp.EmpName,
                            dept.DeptName
                        } by dept.DeptName into gr
                        select gr;

            foreach(var gr in query)
            {
                Console.WriteLine("People from " + gr.Key);
                foreach(var rec in gr)
                {
                    Console.WriteLine(rec.EmpName);
                }
            }
        }

        private static void joinsExample()
        {
            var emplist = repo.Employees;
            var depts = repo.Departments;

            var records = from emp in emplist
                          join dept in depts
                          on emp.DeptId equals dept.DeptId
                          select new { Name = emp.EmpName, Dept = dept.DeptName };
            foreach (var rec in records)
            {
                Console.WriteLine(rec);
            }

        }

        private static void groupEmployeesByCity(List<Data.Employee> empList)
        {
            var groups = from emp in empList
                         orderby emp.EmpName descending
                         group new { emp.EmpName, emp.EmpSalary }
                         by emp.EmpCity into gr                         
                         orderby gr.Key
                         select gr;
            //The Query returns a collection of groups where each group has a collection of empNames with Salaries. 
            foreach(var group in groups)
            {
                Console.WriteLine("People from " + group.Key);
                foreach(var rec in group)
                    Console.WriteLine(rec);
            }



        }

        private static void orderByCity(List<Data.Employee> empList)
        {
            var records = (from emp in empList
                          orderby emp.EmpCity
                          select emp.EmpCity).Distinct();
            foreach (var rec in records)
            {
                Console.WriteLine(rec);
            }
        }

        private static void searchByCity(List<Data.Employee> empList, string city)
        {
            var query = from emp in empList
                        where emp.EmpCity == city
                        select emp;
            Console.WriteLine("People from " + city);
            foreach (var emp in query)
            {
                Console.WriteLine($"{emp.EmpName}");
            }
        }

        private static void displayNamesAndCities(List<Data.Employee> empList)
        {
            var query = from emp in empList
                        select new { emp.EmpName, emp.EmpCity };
            foreach (var name in query)
            {
                Console.WriteLine(name);
                //todo: Diplay: name from city
            }
        }

        private static void firstExample()
        {
            var values = new string[] { "Apples", "Mangoes", "Oranges", "Bananas" };
            var filtered = from e in values
                           where e.Length > 6
                           select e;

            foreach (var e in filtered)
            {
                Console.WriteLine(e);
            }

            filtered = from e in values
                       where e.EndsWith("es")
                       select e;
            Console.WriteLine("Fruits ending with es: ");
            foreach (var e in filtered)
            {
                Console.WriteLine(e);
            }
        }
    }
}


//Further to explore: XLINQ: LINQ to XML