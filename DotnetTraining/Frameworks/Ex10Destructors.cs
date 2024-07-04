using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Destructors are sp functions that are created to be called when the object is destroyed. Opposite of Constructors, Destructors are used to release any memory that is allocated explicitly for your object. This helps in memory management of the Applications. 
 * Languages like Java and C# have their own memory management without dependency on explicit memory management that is done by developers. 
 * Destructors in these programming languages have little or no scope. 
 * However, C# has a concept of calling non .NET Code like C++, VB(Classic) using a Technology called COM(Component Object Model). 
 * This is where C# Apps need sp functions to delete the memory of the COM objects created in their programs. 
 * Destructors in .NET are called implicitly. It will be called by the .NET CLR. Whenever the CLR feels that there is not enough memory for the new objects creation, then it will call a Component called GARBAGE COLLECTOR(GC).
 * GC will free all the objects that are not in scope making space for the new objects.
 * .NET gives an interface called IDisposable which has a single method called Dispose, so in this function, U can implement the logic of explicit memory deallocation for the Unmanaged code(C++ or COM code). Here the creator of the object owns the responsibility of calling the function after the work with the object is completed. 
 */
namespace FrameworkExamples
{
    class SimpleClass : IDisposable
    {
        public int Value { get; set; }
        
        public SimpleClass(int value)
        {
            this.Value = value;
            Console.WriteLine($"The Simple class is created with value {value}");
        }
        //The Destructor will have a tild followed by the classname, it will not have access specifier, no arguements to it. U cannot call them explicitly
        ~SimpleClass()
        {
            Console.WriteLine($"The Simple class is destroyed using Destructor with value {this.Value}");
        }

        public void Dispose()
        {
            Console.WriteLine($"The Simple class is destroyed using Dispose with value {this.Value}");
            GC.SuppressFinalize( this );//GC will not call the destructor for the current object
        }
    }
    internal class Ex10Destructors
    {
        static void CreateAndDestroyObjects()
        {
            for (int i = 0; i < 1000000; i++) 
            {
                //SimpleClass cls = new SimpleClass(i);
                ////GC.Collect();//Forces the GC to come and delete the unused objects.
                ////GC.WaitForPendingFinalizers();
                //cls.Dispose();

                using (SimpleClass cls = new SimpleClass(i)) 
                {
                    //better way of creating objects in C#. If the object's class implements IDisposable, its Dispose method will be called implicitly when the object goes out of scope.
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to coding");
            CreateAndDestroyObjects();
        }
    }
}
