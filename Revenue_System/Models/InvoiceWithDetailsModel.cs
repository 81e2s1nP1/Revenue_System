namespace Revenue_System.Models
{
    public class InvoiceWithDetailsModel
    {
        public InvoiceDetailModel invoiceDetailModel { get; set; }
        public InvoiceModel invoiceModel { get; set; }
        public ProductModel productModel { get; set; }
    }
}
