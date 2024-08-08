namespace BlazerApp.Models
{
    //Replicate the schema of the class that U created for UR Web Api...
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
