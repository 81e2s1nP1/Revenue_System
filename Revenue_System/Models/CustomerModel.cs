namespace Revenue_System.Models
{
    public class CustomerModel
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"Customer ID: {CustomerID}, Name: {CustomerName}, Phone: {Phone}";
        }
    }
}
