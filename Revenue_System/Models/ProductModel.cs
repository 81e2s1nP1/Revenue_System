using Newtonsoft.Json;

namespace Revenue_System.Models
{
    public class ProductModel{
        [JsonProperty("productID")]
        public string ProductID { get; set; }
        [JsonProperty("productName")]
        public string ProductName { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"Product ID: {ProductID}, Product Name: {ProductName}, Price: {Price:C}";
        }

    }
}

