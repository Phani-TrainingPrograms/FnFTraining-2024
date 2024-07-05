using System;
using System.Runtime.Versioning;
using System.Threading;
/*
 * Multi Threading:
 * What is a Process: A Process is an instance of an Executable. Each process has a private address space where all the required units of the program are loaded and executed in the order of the logic defined in the Program. 
 * Thread defines the path of execution within the process. 
 * Every process must have atleast one thread for the execution. If no threads are running,the process is killed (Terminate).
 * Most of the Apps can work well with a single thread with good consistancy and durability. 
 * However, if U want to perform 2 operations parallelly, then we go for new thread. These threads are created to perform some task(job) and will terminate after the task is completed.  
 * Each thread in .NET is represented by a .NET Class Thread. U create an instance of this class and pass a function to it as arg using a Delegate called ThreadStart. The function defines the functionality of the thread. It defines what the thread should do when it starts. 
 * Thead is started using Start method. If ParameterizedThreadStart is used, then U should pass the paramters as boxed value into the Start method. 
 * U can invoke functions asynchronously without creating threads as threads are kernel objects that puts lots of strain on the CPU. For smaller functions, we can use delegate instances to invoke the functions asynchronously instead of creating heavy thread objects. 
 * 
 */
namespace FrameworkExamples
{
   
    internal class Ex12MultiThreading
    {
        /// <summary>
        /// Function that will be used in a Thread
        /// </summary>
        static void NormalFunction()
        {
            Console.WriteLine("The normal function has begun");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Thread Beep #{i}");
                Console.Beep();
            }
            Console.WriteLine("The function has ended");
        }

        /// <summary>
        /// Parameterised Function that will be used to create thread
        /// </summary>
        /// <param name="arg">Arg to be passed to the Thread Func</param>
        static void ParameterizedFunction(object arg)
        {
            //expected int to be passed. 
            int max = (int)arg;
            Console.WriteLine("The function with args has begun");
            for (int i = 0; i < max; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Thread with arg Beep #{i}");
                Console.Beep();
            }
            Console.WriteLine("The function with args has ended");
        }

        [SupportedOSPlatform("Windows")]
        static void AsyncFunction()
        {
            Action action = () =>
            {
                NormalFunction();
            };
           action.BeginInvoke(null, null);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main has started to execute");
            //NormalFunction();
            //Invoke the NormalFunction as a seperate Thread. so that the main can continue to do its tasks. 
            //creatingThreads();
            AsyncFunction();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Main is doing its job");
            }
            Console.WriteLine("Main has ended the functionalities, time to close");
        }

        private static void creatingThreads()
        {
            Thread th = new Thread(NormalFunction);
            Thread th2 = new Thread(new ParameterizedThreadStart(ParameterizedFunction));
            th.Start();
            th2.Start(5);
        }
    }
}
//How to create Async programming. 
