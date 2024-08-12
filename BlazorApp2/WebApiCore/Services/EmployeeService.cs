using WebApiCore.Data;

namespace WebApiCore.Services
{
    public interface IEmployeeService
    {
        //Curd operations
    } 
    public class EmployeeService : IEmployeeService
    {
        private readonly FnfTrainingContext _context;
        public EmployeeService(FnfTrainingContext context)
        {
            _context = context;
        }
        //Implement the interface as seen earlier. 
    }
    //Next Step: Implement the DI for this interface in the Program.cs file. 
}
