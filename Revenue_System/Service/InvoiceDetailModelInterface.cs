using Revenue_System.Models;
using System.Collections.Generic;

namespace Revenue_System.ServiceInterfaces
{
    public interface InvoiceDetailInterface
    {
        List<InvoiceWithDetailsModel> GetInvoiceWithDetails();
        List<string> GetAllCustomerIDs();
        List<string> GetAllProductIDs();
        void UpdateInvoiceAndInvoiceDetail(InvoiceModel invoiceModel, InvoiceDetailModel invoiceDetailModel);
        void InsertInvoice(InvoiceModel invoiceModel, InvoiceDetailModel invoiceDetailModel);
        void DeleteInvoice(string invoiceID);
        bool ProductCheck(string productId);
        bool CustomerCheck(string customerId);
    }
}