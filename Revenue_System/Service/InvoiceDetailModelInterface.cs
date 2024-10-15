using Revenue_System.Models;

namespace Revenue_System.Service
{
    public interface InvoiceDetailModelInterface
    {
        List<InvoiceDetailModel> GetInvoiceDetails();
        bool deleteInvoiceDetail(int id);
        bool addInvoiceDetail(InvoiceDetailModel invoiceDetails);
        bool updateInvoiceDetail(InvoiceDetailModel invoiceDetails);
    }
}
