using Revenue_System.Models;
using System.Data.SqlClient;

namespace Revenue_System.ServiceImplements
{
    public class ProductDataAccessLayer
    {
        string connectionString = "data source=PA; database=system_revenue; integrated security=SSPI";

        // Phương thức chèn khách hàng vào bảng
        public void InsertProduct(ProductModel productModel)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "INSERT INTO Products (ProductID, ProductName, Price) VALUES (@ProductID, @ProductName, @Price)";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            cmd.Parameters.AddWithValue("@ProductID", productModel.ProductID.ToUpper());
            cmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
            cmd.Parameters.AddWithValue("@Price", productModel.Price);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Phương thức lấy toàn bộ danh sách sản phẩm trong database
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> lstProduct = new List<ProductModel>();

            using SqlConnection con = new SqlConnection(connectionString);

            string sqlQuery = "SELECT ProductID, ProductName, Price FROM Products";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ProductModel product = new ProductModel();

                product.ProductID = rdr["ProductID"].ToString();
                product.ProductName = rdr["ProductName"].ToString();
                product.Price = Convert.ToDecimal(rdr["Price"]);

                lstProduct.Add(product);
            }
            con.Close();
            return lstProduct;
        }

        //Phương thức cập nhật thông tin của sản phẩm
        public void UpdatePoduct(ProductModel productModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE Products SET ProductName = @ProductName, Price = @Price WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
                cmd.Parameters.AddWithValue("@Price", productModel.Price);
                cmd.Parameters.AddWithValue("@ProductID", productModel.ProductID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Phương thức xóa sản phẩm theo id
        public void DeleteCustomer(string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string delete_product = "DELETE FROM Products WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(delete_product, con);

                cmd.Parameters.AddWithValue("@ProductID", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
