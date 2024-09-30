using Revenue_System.Models;

namespace Revenue_System.Service
{
    public interface InvoiceInterface
    {
        List<InvoiceModel> GetModels();
        bool deleteModel(int id);
        bool addModel(InvoiceModel model);
        bool updateModel(InvoiceModel model);
    }
}
