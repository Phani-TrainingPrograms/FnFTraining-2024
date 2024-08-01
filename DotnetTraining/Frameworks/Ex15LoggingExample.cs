using MathComponentLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkExamples
{
    delegate void LogMessage(string message);
    class MyConsoleLogger : ICustomLogger
    {
        public void WriteLog(string message)
        {
            string msgLine = $"[{DateTime.Now.ToShortTimeString()}]: {message}\n";
            var oldClor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msgLine);
            Console.ForegroundColor = oldClor;
        }
    }
    internal class Ex15LoggingExample
    {
        static void Main(string[] args)
        {
            //ICustomLogger logger = new MyConsoleLogger();
            //LogExampleClass cls = new LogExampleClass(logger);
            //cls.TestFunc();

            LogMessage log = LogToConsole;
            log += LogToFile;

            log("Testing on both the resources");
        }

        static void LogToConsole(string message)
        {
            ICustomLogger logger = new MyConsoleLogger();
            string msgLine = $"[{DateTime.Now.ToShortTimeString()}]: {message}\n";
            logger.WriteLog(msgLine);
        }

        static void LogToFile(string message)
        {
            ICustomLogger logging = new FileLogger();
            string msgLine = $"[{DateTime.Now.ToShortTimeString()}]: {message}\n";
            logging.WriteLog(msgLine);
        }
    }
}
