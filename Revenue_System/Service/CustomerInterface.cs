using Revenue_System.Models;

namespace Revenue_System.Service
{
    public interface CustomerInterface
    {
        void InsertCustomer(CustomerModel customerModel);
        List<CustomerModel> GetAllCustomer();
        void UpdateCustomer(CustomerModel customerModel);
        void DeleteCustomer(string id);
    }
}
