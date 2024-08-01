namespace SampleApiMvcClient.Models
{
    //create the class with properties set with Camel casing...
    public class Stock
    {
        public int StockId { get; set; }
        public string StockName { get; set; } = string.Empty;
        public string StockDescription { get; set; } = string.Empty;
        public double UnitPrice { get; set; }
    }
}
