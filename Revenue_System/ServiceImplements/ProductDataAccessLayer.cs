using Revenue_System.Models;
using Revenue_System.ServiceInterfaces;
using System.Data.SqlClient;

namespace Revenue_System.ServiceImplements
{
    public class ProductDataAccessLayer : ProductInterface
    {
        private readonly string connectionString = "data source=PA; database=system_revenue; integrated security=SSPI";

        // Phương thức chèn sản phẩm vào bảng
        public void InsertProduct(ProductModel productModel)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "INSERT INTO Products (ProductID, ProductName, Price) VALUES (@ProductID, @ProductName, @Price)";
            using SqlCommand cmd = new SqlCommand(sqlQuery, con);

            cmd.Parameters.AddWithValue("@ProductID", productModel.ProductID.ToUpper());
            cmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
            cmd.Parameters.AddWithValue("@Price", productModel.Price);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // Phương thức lấy toàn bộ danh sách sản phẩm trong database
        public List<ProductModel> GetAllProducts()
        {
            var lstProduct = new List<ProductModel>();

            using SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "SELECT ProductID, ProductName, Price FROM Products";
            using SqlCommand cmd = new SqlCommand(sqlQuery, con);

            con.Open();
            using SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var product = new ProductModel
                {
                    ProductID = rdr["ProductID"].ToString(),
                    ProductName = rdr["ProductName"].ToString(),
                    Price = Convert.ToDecimal(rdr["Price"])
                };

                lstProduct.Add(product);
            }

            return lstProduct;
        }

        // Phương thức cập nhật thông tin của sản phẩm
        public void UpdateProduct(ProductModel productModel)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "UPDATE Products SET ProductName = @ProductName, Price = @Price WHERE ProductID = @ProductID";
            using SqlCommand cmd = new SqlCommand(sqlQuery, con);

            cmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
            cmd.Parameters.AddWithValue("@Price", productModel.Price);
            cmd.Parameters.AddWithValue("@ProductID", productModel.ProductID);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // Phương thức xóa sản phẩm theo id
        public void DeleteProduct(string productId)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "DELETE FROM Products WHERE ProductID = @ProductID";
            using SqlCommand cmd = new SqlCommand(sqlQuery, con);

            cmd.Parameters.AddWithValue("@ProductID", productId);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
