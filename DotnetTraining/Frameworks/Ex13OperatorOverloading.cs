using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkExamples
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
        public static Employee operator +(Employee lhs, int rhs)
        {
            lhs.EmpSalary += rhs;
            return lhs;
        }

        public static Employee operator -(Employee lhs, int rhs)
        {
            lhs.EmpSalary -= rhs;
            return lhs;
        }

        // Assignment operator cannot be overloaded...
        //public static Employee operator =(Employee lhs, Employee rhs)
        //{
        //    lhs.EmpId -= rhs.EmpId;
        //    lhs.EmpSalary = rhs.EmpSalary;
        //    lhs.EmpName = rhs.EmpName;
        //    return lhs;
        //}

        public static implicit operator Employee(Cst rhs)
        {
            var emp = new Employee { EmpId = rhs.CstId, EmpName = rhs.CstName, EmpSalary = rhs.BaseValue };
            return emp; 
        }

    }

    class Cst
    {
        public int BaseValue { get; set; }
        public string CstName { get; set; }
        public int CstId { get; set; }
    }
    internal class Ex13OperatorOverloading
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee { EmpId = 11, EmpName = "Phaniraj", EmpSalary = 45000 };
            
            
            emp += 5000;
            Console.WriteLine("The Current salary is " + emp.EmpSalary);

            emp -= 10000;
            Console.WriteLine("The Current salary is " + emp.EmpSalary);

            Employee emp2 = new Cst { CstId = 1, BaseValue = 4000, CstName = "Suresh" };
            Console.WriteLine("The Name: " + emp2.EmpName);
        }
    }
}
