using System.ComponentModel.DataAnnotations;

namespace BlazorWebAssembly.Models
{
    //Todo: Create a Class that represents UR Entity. It should be the data that U want to present in the User interface of the Blazor app

    public enum Options
    {
        Add, Subtract, Multiply, Divide, Square, SquareRoot
    }

    /// <summary>
    /// Entity Class that is used to present the data into the Application.
    /// </summary>
    public class Calculator
    {
        [Required(ErrorMessage = "Value must be set")]
        public double FirstValue { get; set; }
        
        [Required(ErrorMessage = "Second Value must be set")]
        public double SecondValue { get; set; }

        [Required(ErrorMessage = "Choose the right option")]
        public Options Option { get; set; }

        [Range(1, 50, ErrorMessage = "Age should be b/w 1 to 50 only")]
        public int Age { get; set; } = 10;


    }
    
}
