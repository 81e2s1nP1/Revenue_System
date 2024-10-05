using Newtonsoft.Json;

namespace Revenue_System.Models
{
    public class CustomerModel
    {
        [JsonProperty("customerID")]
        public string CustomerID { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"Customer ID: {CustomerID}, Name: {CustomerName}, Phone: {Phone}";
        }
    }
}
