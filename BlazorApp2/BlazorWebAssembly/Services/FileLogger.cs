using System.Globalization;

namespace BlazorWebAssembly.Services
{
    public class FileLogger
    {
        private string dirName = "C:\\FnfLogs";
        private string fileName = "MyLogs.txt";
        private string fullName = string.Empty;
        public FileLogger() 
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            fullName = Path.Combine(dirName, fileName);
            if (!File.Exists(fullName))
                File.Create(fullName);
        }

        public void Log(string message) => File.AppendAllText(fullName, message);
        
    }
}
