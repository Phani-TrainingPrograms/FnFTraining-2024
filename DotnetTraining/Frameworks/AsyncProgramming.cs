using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Frameworks
{
    internal class AsyncProgramming
    {

        static void ThreadPoolUsage()
        {
            int count1, count2;
            Console.WriteLine("before");
            ThreadPool.GetAvailableThreads(out count1, out count2);
            Console.WriteLine($"{count1}, {count2}");
            Console.WriteLine("after");
            ThreadPool.QueueUserWorkItem((arg)=>
            {
                ThreadPool.GetAvailableThreads(out count1, out count2);
                Console.WriteLine($"{count1}, {count2}");
                Console.WriteLine("The arg value: " + arg);
                Console.WriteLine("This function is invoked thru Thread pool");
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Thread Pool");
                    Thread.Sleep(100);
                }
            }, 123);
        }
        /// <summary>
        /// Function that will be used in a Thread
        /// </summary>
        static int NormalFunction()
        {
            Console.WriteLine("The normal function has begun");
            int res = 0;
            for (int i = 0; i < 4; i++)
            {
                res += i;
                Thread.Sleep(1000);
                Console.WriteLine($"Thread Beep #{i}");
                Console.Beep();
            }
            Console.WriteLine("The function has ended");
            return res;
        }
        static void AsyncFunction()
        {
            //This is callback function, this functio
          
            Func<int> func = () =>
            {
                return NormalFunction();
            };

            IAsyncResult res = null;
            //func(); //synchronous call
            res = func.BeginInvoke((ar) =>
            {
                if (ar.IsCompleted)
                {
                    var result = func.EndInvoke(ar);
                    Console.WriteLine(result);
                }
            }, null);
            //while (!res.IsCompleted)
            //{
            //    Console.WriteLine("Please wait!!!!!");
            //}
        }
        static void Main(string[] args)
        {
            ThreadPoolUsage();
            //AsyncFunction();
            Console.WriteLine("Main has started to execute");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Main is doing its job");
            }
           
            //Thread.Sleep(5000);
            //Console.WriteLine("Main has ended the functionalities, time to close");
        }
    }
}
