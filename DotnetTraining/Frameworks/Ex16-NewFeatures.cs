using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//New features were included as a part of .NET Framwork 4.0 and C# v5
//var, lamdba Functions, anonymous types, extension methods. 
 namespace FrameworkExamples
{
    static class MyExtensions
    {
        //Extension methods are methods added to the instance of the class, but not to the class itself. If a class is sealed and U wish to add few helper methods for that class which cannot be extended, then U can add those methods to the instance instead of the class itself. 
        //Extension methods is not object oriented, they are not the part of any OOP features. 
        public static int GetNoOfWords(this string input)
        {
            var words = input.Split(' ');
            return words.Length;
        }

        //Find the Start of the week for a given date..
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startDay = DayOfWeek.Sunday)
        {
            int diff = (7 + (dt.DayOfWeek - startDay)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        //todo: Display the numbers suffixed with K or M or B.
        //110000 -> 11K
        //11000000 -> 11M   

    }
    internal class NewFeatures
    {
        static void Main(string[] args)
        {
            //usingVarExample();
            //anonymousTypesExample();
            extensionMethodsExample();
        }

        private static void extensionMethodsExample()
        {
            string data = "New features were included as a part of .NET Framwork 4.0 and C# v5";
            int no = data.GetNoOfWords();
            Console.WriteLine("The total no of words in this data is " + no);

            DateTime dt = DateTime.Now.AddDays(14);
            var sundayDate = dt.StartOfWeek(DayOfWeek.Sunday);
            Console.WriteLine(sundayDate.ToLongDateString());

        }

        private static void anonymousTypesExample()
        {
            var emp = new
            {
                Empid = 123, Empname ="Phaniraj", EmpAddress = "Bangalore"
            };
            Console.WriteLine(emp);
            Console.WriteLine($"The name is {emp.Empname} from {emp.EmpAddress} and is having an Id of {emp.Empid}");
            //Anonymous types helps in creating data carriers for a given application. If U want to return objects on a adhoc manner, then U can create an anonymous type and return it. anonymous types are always refered with var variables. 
        }

        private static void usingVarExample()
        {
            //var is implicit typed local variable. The variable holds the data type of the data that is assigned to it in the declaration statement of the variable. var can be used only as local variables.
            //var keyword cannot be applied as return type of a function,neither it could be used as field of a class, nor it can be used as parameters of a function. var shall not be used as return type of a function. It is purely used as local variable. 
            //It provides a convinient way of using local variables. var variables cannot be initialized in multiple statements. 
            //Once the data is assigned to it, all the rules of data type conversion will be applicable to var variable.
            var strData = "string"; //strData holds the data type of string. 
            var no = 234;
            strData = no.ToString();
            //var x; error as the variable must be initialized in the same line
             var x = strData;
            Console.WriteLine(strData);
            Console.WriteLine(strData.GetType().Name);

        }
    }
}
