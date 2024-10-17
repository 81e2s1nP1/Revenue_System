using Revenue_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Services
{
    public class ProductDataAccessLayer
    {
        string connectionString = "data source=PA; database=system_revenue; integrated security=SSPI";

        public void InsertProduct(ProductModel productModel)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            using SqlTransaction transaction = con.BeginTransaction();
            try
            {
                // Get the current maximum ProductID value (ignoring the prefix "AT")
                string sqlMaxProductID = "SELECT ISNULL(MAX(CAST(SUBSTRING(ProductID, 3, LEN(ProductID)) AS INT)), 0) FROM Products";
                SqlCommand cmdMaxProductID = new SqlCommand(sqlMaxProductID, con, transaction);
                int maxProductID = (int)cmdMaxProductID.ExecuteScalar();

                // Create a new ProductID by incrementing the maxProductID
                string productIDCurrent = "AT" + (maxProductID + 1).ToString("D3");

                // Insert the product into the Products table
                string sqlQuery = "INSERT INTO Products (ProductID, ProductName, Price) VALUES (@ProductID, @ProductName, @Price)";
                SqlCommand cmd = new SqlCommand(sqlQuery, con, transaction);

                cmd.Parameters.AddWithValue("@ProductID", productIDCurrent);
                cmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
                cmd.Parameters.AddWithValue("@Price", productModel.Price);

                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("An error occurred while adding the product: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Method to retrieve all products from the database
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> productList = new List<ProductModel>();

            using SqlConnection con = new SqlConnection(connectionString);

            string sqlQuery = "SELECT ProductID, ProductName, Price FROM Products";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ProductModel product = new ProductModel
                {
                    ProductID = rdr["ProductID"].ToString(),
                    ProductName = rdr["ProductName"].ToString(),
                    Price = Convert.ToDecimal(rdr["Price"])
                };

                productList.Add(product);
            }
            con.Close();
            return productList;
        }

        // Method to update product information
        public void UpdateProduct(ProductModel productModel)
        {
            using SqlConnection con = new SqlConnection(connectionString);
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

        // Method to delete a product by id
        public void DeleteProduct(string id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            {
                string deleteProduct = "DELETE FROM Products WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(deleteProduct, con);

                cmd.Parameters.AddWithValue("@ProductID", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
