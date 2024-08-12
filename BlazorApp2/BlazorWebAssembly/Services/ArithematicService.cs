using BlazorWebAssembly.Client;
using System.Diagnostics;
using System.Net.Security;

namespace BlazorWebAssembly.Services
{
    public interface IArithematicService
    {
        double AddFunction(double first, double second);
        double DivideFunction(double first, double second);
        double MultiplyFunction(double first, double second);
        double SquareFunction(double v);
        double SquareRoot(double v);
        double SubtractFunction(double first, double second);
    }

    public class ArithematicService : IArithematicService
    {
        private readonly ISimpleService _service;
        private readonly string caller;
        public ArithematicService(ISimpleService service)
        {
            this._service = service;
            this.caller = this._service.GetName();
        }

        public double AddFunction(double first, double second)
        {
            Console.WriteLine("Testing the result by: " + this.caller);
            return first + second;
        }
        public double SubtractFunction(double first, double second) => first - second;
        public double MultiplyFunction(double first, double second) => first * second;
        public double DivideFunction(double first, double second) => first / second;
        public double SquareFunction(double v) => v * v;
        public double SquareRoot(double v) => Math.Sqrt(v);
    }
}
