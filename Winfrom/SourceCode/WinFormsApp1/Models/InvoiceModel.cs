namespace Revenue_System.Models
{
    public class InvoiceModel
    {
        public string InvoiceID { get; set; }
        public string CustomerID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceDetailModel> InvoiceDetails { get; set; }

        public override string ToString()
        {
            return $"InvoiceID: {InvoiceID}, CustomerID: {CustomerID}, InvoiceDate: {InvoiceDate.ToString("yyyy-MM-dd")}";
        }
    }
}
