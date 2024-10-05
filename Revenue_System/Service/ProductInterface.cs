using Revenue_System.Models;
using System.Collections.Generic;

namespace Revenue_System.ServiceInterfaces
{
    public interface ProductInterface
    {
        void InsertProduct(ProductModel productModel);
        List<ProductModel> GetAllProducts();
        void UpdateProduct(ProductModel productModel);
        void DeleteProduct(string productId);
    }
}
