using Revenue_System.Models;
using Revenue_System.ServiceInterfaces;
using System.Data.SqlClient;

namespace Revenue_System.ServiceImplements
{
    public class InvoiceDataAccessLayer : InvoiceDetailInterface
    {
        private readonly string connectionString = "data source=PA; database=system_revenue; integrated security=SSPI";

        // Lấy danh sách đơn hàng và chi tiết đơn hàng
        public List<InvoiceWithDetailsModel> GetInvoiceWithDetails()
        {
            var lstInvoiceWithDetails = new List<InvoiceWithDetailsModel>();

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

            using SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();

            using SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var invoiceDetailModel = new InvoiceDetailModel
                {
                    InvoiceDetailID = rdr["InvoiceDetailID"].ToString(),
                    InvoiceID = rdr["InvoiceID"].ToString(),
                    ProductID = rdr["ProductID"].ToString(),
                    Quantity = Convert.ToInt32(rdr["Quantity"]),
                    TotalPrice = Convert.ToDecimal(rdr["Price"]) * Convert.ToInt32(rdr["Quantity"])
                };

                var invoiceModel = new InvoiceModel
                {
                    InvoiceID = rdr["InvoiceID"].ToString(),
                    CustomerID = rdr["CustomerID"].ToString(),
                    InvoiceDate = Convert.ToDateTime(rdr["InvoiceDate"])
                };

                var productModel = new ProductModel
                {
                    Price = Convert.ToDecimal(rdr["Price"])
                };

                lstInvoiceWithDetails.Add(new InvoiceWithDetailsModel
                {
                    invoiceDetailModel = invoiceDetailModel,
                    invoiceModel = invoiceModel,
                    productModel = productModel
                });
            }
            return lstInvoiceWithDetails;
        }

        // Phương thức lấy danh sách CustomerID
        public List<string> GetAllCustomerIDs()
        {
            var lstCustomerIDs = new List<string>();

            using SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "SELECT DISTINCT CustomerID FROM Customers";

            using SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();

            using SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lstCustomerIDs.Add(rdr["CustomerID"].ToString());
            }
            return lstCustomerIDs;
        }

        // Phương thức lấy danh sách ProductID
        public List<string> GetAllProductIDs()
        {
            var lstProductIDs = new List<string>();

            using SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "SELECT DISTINCT ProductID FROM Products";

            using SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();

            using SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lstProductIDs.Add(rdr["ProductID"].ToString());
            }
            return lstProductIDs;
        }

        // Phương thức cập nhật lại đơn hàng, chi tiết đơn hàng
        public void UpdateInvoiceAndInvoiceDetail(InvoiceModel invoiceModel, InvoiceDetailModel invoiceDetailModel)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            using SqlTransaction transaction = con.BeginTransaction();
            try
            {
                string sqlUpdateInvoiceModel = "UPDATE Invoices SET InvoiceDate = @InvoiceDate WHERE InvoiceID = @InvoiceID";
                using SqlCommand cmdUpdateInvoiceModel = new SqlCommand(sqlUpdateInvoiceModel, con, transaction);
                cmdUpdateInvoiceModel.Parameters.AddWithValue("@InvoiceDate", invoiceModel.InvoiceDate);
                cmdUpdateInvoiceModel.Parameters.AddWithValue("@InvoiceID", invoiceModel.InvoiceID);
                cmdUpdateInvoiceModel.ExecuteNonQuery();

                string sqlUpdateInvoiceDetailModel = "UPDATE InvoiceDetails SET Quantity = @Quantity WHERE InvoiceDetailID = @InvoiceDetailID AND InvoiceID = @InvoiceID";
                using SqlCommand cmdUpdateInvoiceDetailModel = new SqlCommand(sqlUpdateInvoiceDetailModel, con, transaction);
                cmdUpdateInvoiceDetailModel.Parameters.AddWithValue("@Quantity", invoiceDetailModel.Quantity);
                cmdUpdateInvoiceDetailModel.Parameters.AddWithValue("@InvoiceDetailID", invoiceDetailModel.InvoiceDetailID);
                cmdUpdateInvoiceDetailModel.Parameters.AddWithValue("@InvoiceID", invoiceModel.InvoiceID);
                cmdUpdateInvoiceDetailModel.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                throw new Exception("Có lỗi xảy ra khi cập nhật dữ liệu.", ex);
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
                using SqlCommand cmdInvoices = new SqlCommand(sqlQueryInvoices, con, transaction);
                cmdInvoices.Parameters.AddWithValue("@InvoiceID", invoiceModel.InvoiceID.ToUpper());
                cmdInvoices.Parameters.AddWithValue("@CustomerID", invoiceModel.CustomerID);
                cmdInvoices.Parameters.AddWithValue("@InvoiceDate", invoiceModel.InvoiceDate);
                cmdInvoices.ExecuteNonQuery();

                // Thêm chi tiết đơn hàng (InvoiceDetails)
                string sqlQueryInvoiceDetails = "INSERT INTO InvoiceDetails (InvoiceDetailID, InvoiceID, ProductID, Quantity, TotalPrice) VALUES (@InvoiceDetailID, @InvoiceID, @ProductID, @Quantity, @TotalPrice)";
                using SqlCommand cmdInvoiceDetails = new SqlCommand(sqlQueryInvoiceDetails, con, transaction);
                cmdInvoiceDetails.Parameters.AddWithValue("@InvoiceDetailID", invoiceDetailModel.InvoiceDetailID.ToUpper());
                cmdInvoiceDetails.Parameters.AddWithValue("@InvoiceID", invoiceModel.InvoiceID.ToUpper());
                cmdInvoiceDetails.Parameters.AddWithValue("@ProductID", invoiceDetailModel.ProductID);
                cmdInvoiceDetails.Parameters.AddWithValue("@Quantity", invoiceDetailModel.Quantity);
                cmdInvoiceDetails.Parameters.AddWithValue("@TotalPrice", invoiceDetailModel.TotalPrice ?? 0);

                cmdInvoiceDetails.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Có lỗi xảy ra trong quá trình thêm hóa đơn và chi tiết hóa đơn: " + ex.Message);
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
        }

        // Phương thức kiểm tra sản phẩm có trong đơn hàng chưa 
        public bool ProductCheck(string productId)
        {
            return CheckExists("InvoiceDetails", "ProductID", productId);
        }

        // Phương thức kiểm tra khách hàng có trong hóa đơn chưa 
        public bool CustomerCheck(string customerId)
        {
            return CheckExists("Invoices", "CustomerID", customerId);
        }

        // Phương thức kiểm tra sự tồn tại của một mục trong bảng
        private bool CheckExists(string tableName, string columnName, string value)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @Value";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Value", value);
            con.Open();

            return (int)cmd.ExecuteScalar() > 0;
        }
    }
}
