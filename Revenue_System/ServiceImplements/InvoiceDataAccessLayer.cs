using Revenue_System.Models;
using System.Data;
using System.Data.SqlClient;

namespace Revenue_System.ServiceImplements
{
    public class InvoiceDataAccessLayer
    {
        string connectionString = "data source=PA; database=system_revenue; integrated security=SSPI";
        // Lấy danh sách đơn hàng và chi tiết đơn hàng
        public List<InvoiceWithDetailsModel> GetInvoiceWithDetails()
        {
            List<InvoiceWithDetailsModel> lstInvoiceWithDetails = new List<InvoiceWithDetailsModel>();
            List<string> lstCustomerId = new List<string>();

            using SqlConnection con = new SqlConnection(connectionString);

            string sqlQuery = @"
            SELECT 
                id.InvoiceDetailID, 
                id.InvoiceID, 
                id.ProductID, 
                id.Quantity, 
                id.TotalPrice, 
                i.CustomerID, 
                i.InvoiceDate,
                p.Price
            FROM 
                InvoiceDetails id
            JOIN 
                Invoices i ON id.InvoiceID = i.InvoiceID
            JOIN 
                Products p ON id.ProductID = p.ProductID";

            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {   
                // Tạo đối tượng InvoiceDetailModel
                InvoiceDetailModel invoiceDetailModel = new InvoiceDetailModel
                {
                    InvoiceDetailID = rdr["InvoiceDetailID"].ToString(),
                    InvoiceID = rdr["InvoiceID"].ToString(),
                    ProductID = rdr["ProductID"].ToString(),
                    Quantity = Convert.ToInt32(rdr["Quantity"]),
                    TotalPrice = Convert.ToDecimal(rdr["Price"]) * Convert.ToInt32(rdr["Quantity"])
                };

                // Tạo đối tượng InvoiceModel
                InvoiceModel invoiceModel = new InvoiceModel
                {
                    InvoiceID = rdr["InvoiceID"].ToString(),
                    CustomerID = rdr["CustomerID"].ToString(),
                    InvoiceDate = Convert.ToDateTime(rdr["InvoiceDate"])
                };

                ProductModel productModel = new ProductModel
                {
                    Price = Convert.ToDecimal(rdr["Price"])
                };

                // Tạo đối tượng InvoiceWithDetailsModel
                InvoiceWithDetailsModel invoiceWithDetailsModel = new InvoiceWithDetailsModel
                {
                    invoiceDetailModel = invoiceDetailModel,
                    invoiceModel = invoiceModel,
                    productModel = productModel
                };

                // Thêm đối tượng vào danh sách
                lstInvoiceWithDetails.Add(invoiceWithDetailsModel);
             
            }
            con.Close();
            return lstInvoiceWithDetails;
        }

        // Phương thức lấy danh sách CustomerID
        public List<string> GetAllCustomerIDs()
        {
            List<string> lstCustomerIDs = new List<string>();

            using SqlConnection con = new SqlConnection(connectionString);

            string sqlQuery = "SELECT DISTINCT CustomerID FROM Customers";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                lstCustomerIDs.Add(rdr["CustomerID"].ToString());
            }
            con.Close();

            return lstCustomerIDs;
        }

        // Phương thức lấy danh sách ProductID
        public List<string> GetAllProductIDs()
        {
            List<string> lstProductIDs = new List<string>();

            using SqlConnection con = new SqlConnection(connectionString);

            string sqlQuery = "SELECT DISTINCT ProductID FROM Products";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                lstProductIDs.Add(rdr["ProductID"].ToString());
            }
            con.Close();

            return lstProductIDs;
        }

        //Phương thức cập nhật lại đơn hàng, chi tiết đơn hàng
        public void UpdateInvoiceAndInvoiceDetail(InvoiceModel invoiceModel, InvoiceDetailModel invoiceDetailModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlUpdateInvoiceModel = "UPDATE Invoices SET InvoiceDate = @InvoiceDate WHERE InvoiceID = @InvoiceID";
                string sqlUpdateInvoiceDetailModel = "UPDATE InvoiceDetails SET Quantity = @Quantity WHERE InvoiceDetailID = @InvoiceDetailID AND InvoiceID = @InvoiceID";

                SqlCommand cmdUpdateInvoiceModel = new SqlCommand(sqlUpdateInvoiceModel, con);
                SqlCommand cmdUpdateInvoiceDetailModel = new SqlCommand(sqlUpdateInvoiceDetailModel, con);

                cmdUpdateInvoiceModel.Parameters.AddWithValue("@InvoiceDate", invoiceModel.InvoiceDate);
                cmdUpdateInvoiceModel.Parameters.AddWithValue("@InvoiceID", invoiceModel.InvoiceID);

                cmdUpdateInvoiceDetailModel.Parameters.AddWithValue("@Quantity", invoiceDetailModel.Quantity);
                cmdUpdateInvoiceDetailModel.Parameters.AddWithValue("@InvoiceDetailID", invoiceDetailModel.InvoiceDetailID);
                cmdUpdateInvoiceDetailModel.Parameters.AddWithValue("@InvoiceID", invoiceModel.InvoiceID);

                try
                {
                    con.Open();
                    cmdUpdateInvoiceModel.ExecuteNonQuery();
                    cmdUpdateInvoiceDetailModel.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Có lỗi xảy ra khi cập nhật dữ liệu.", ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }





        // Phương thức thêm đơn hàng vào bảng
        public void InsertInvoice(InvoiceModel invoiceModel, InvoiceDetailModel invoiceDetailModel)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            using SqlTransaction transaction = con.BeginTransaction();

            try
            {
                // Thêm đơn hàng (Invoices)
                string sqlQueryInvoices = "INSERT INTO Invoices (InvoiceID, CustomerID, InvoiceDate) VALUES (@InvoiceID, @CustomerID, @InvoiceDate)";
                SqlCommand cmdInvoices = new SqlCommand(sqlQueryInvoices, con, transaction);

                cmdInvoices.Parameters.AddWithValue("@InvoiceID", invoiceModel.InvoiceID.ToUpper());
                cmdInvoices.Parameters.AddWithValue("@CustomerID", invoiceModel.CustomerID);
                cmdInvoices.Parameters.AddWithValue("@InvoiceDate", invoiceModel.InvoiceDate);

                cmdInvoices.ExecuteNonQuery();

                // Thêm chi tiết đơn hàng (InvoiceDetails)
                string sqlQueryInvoiceDetails = "INSERT INTO InvoiceDetails (InvoiceDetailID, InvoiceID, ProductID, Quantity, TotalPrice) VALUES (@InvoiceDetailID, @InvoiceID, @ProductID, @Quantity, @TotalPrice)";
                SqlCommand cmdInvoiceDetails = new SqlCommand(sqlQueryInvoiceDetails, con, transaction);

                cmdInvoiceDetails.Parameters.AddWithValue("@InvoiceDetailID", invoiceDetailModel.InvoiceDetailID.ToUpper());
                cmdInvoiceDetails.Parameters.AddWithValue("@InvoiceID", invoiceModel.InvoiceID.ToUpper());
                cmdInvoiceDetails.Parameters.AddWithValue("@ProductID", invoiceDetailModel.ProductID);
                cmdInvoiceDetails.Parameters.AddWithValue("@Quantity", invoiceDetailModel.Quantity);
                cmdInvoiceDetails.Parameters.AddWithValue("@TotalPrice", 100);

                cmdInvoiceDetails.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Có lỗi xảy ra trong quá trình thêm hóa đơn và chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Phương thức xóa hóa đơn (Invoices) và tự động xóa chi tiết hóa đơn (InvoiceDetails)
        public void DeleteInvoice(string invoiceID)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            using SqlTransaction transaction = con.BeginTransaction();

            try
            {
                // Xóa chi tiết hóa đơn trước
                string sqlQueryInvoiceDetail = "DELETE FROM InvoiceDetails WHERE InvoiceID = @InvoiceID";
                using SqlCommand cmdQueryInvoiceDetail = new SqlCommand(sqlQueryInvoiceDetail, con, transaction);
                cmdQueryInvoiceDetail.Parameters.AddWithValue("@InvoiceID", invoiceID.ToUpper());
                cmdQueryInvoiceDetail.ExecuteNonQuery();

                // Xóa hóa đơn chính
                string sqlQuery = "DELETE FROM Invoices WHERE InvoiceID = @InvoiceID";
                using SqlCommand cmd = new SqlCommand(sqlQuery, con, transaction);
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID.ToUpper());
                cmd.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Có lỗi xảy ra trong quá trình xóa hóa đơn: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Phương thức kiểm tra sản phẩm có trong đơn hàng chưa 
        public bool ProductCheck(string productId)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string query = "SELECT COUNT(*) FROM InvoiceDetails WHERE ProductID = @ProductID";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ProductID", productId);

            int count = (int)cmd.ExecuteScalar();

            con.Close();

            return count > 0;
        }

        // Phương thức kiểm tra sản phẩm có trong đơn hàng chưa 
        public bool CustomerCheck(string customerId)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string query = "SELECT COUNT(*) FROM Invoices WHERE CustomerID = @CustomerID";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@CustomerID", customerId);

            int count = (int)cmd.ExecuteScalar();

            con.Close();

            return count > 0;
        }
    }
}
