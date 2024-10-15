namespace Revenue_System.Models
{
    public class InvoiceCreateModel
    {
        public InvoiceModel InvoiceModel { get; set; }
        public string SelectedQuantities { get; set; }
        public List<string> ProductIDs { get; set; }
    }
}
