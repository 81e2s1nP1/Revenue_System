using Revenue_System.Models;

namespace Revenue_System.Service
{
    public interface ProductInterface
    {
        List<ProductInterface> GetProducts();
        bool deleteProdcut(int id);
        bool addProduct(ProductModel product);
        bool updateProduct(ProductModel product);
    }
}
