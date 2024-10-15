namespace Revenue_System.Models
{
    public class ProductModel
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        // Override phương thức ToString
        public override string ToString()
        {
            return $"ProductID: {ProductID}, ProductName: {ProductName}, Price: {Price:C}";
        }
    }
}
