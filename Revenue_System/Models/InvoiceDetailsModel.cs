namespace Revenue_System.Models
{
    public class InvoiceDetailModel
    {
        public string InvoiceDetailID { get; set; }
        public string InvoiceID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public override string ToString()
        {
            return $"InvoiceDetailID: {InvoiceDetailID}, InvoiceID: {InvoiceID}, ProductID: {ProductID}, Quantity: {Quantity}, TotalPrice: {TotalPrice:C}";
        }
    }
}
