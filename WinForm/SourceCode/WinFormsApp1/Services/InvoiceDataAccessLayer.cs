using Revenue_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Services
{
    public class InvoiceDataAccessLayer
    {
        private string connectionString = "data source=PA; database=system_revenue; integrated security=SSPI";

        // Retrieve the list of invoices and their details
        public List<InvoiceWithDetailsModel> GetInvoiceWithDetails()
        {
            List<InvoiceWithDetailsModel> invoiceWithDetailsList = new List<InvoiceWithDetailsModel>();

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
                p.ProductID,
                p.ProductName,
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
                // Create InvoiceDetailModel object
                InvoiceDetailModel invoiceDetailModel = new InvoiceDetailModel
                {
                    InvoiceDetailID = rdr["InvoiceDetailID"].ToString(),
                    InvoiceID = rdr["InvoiceID"].ToString(),
                    ProductID = rdr["ProductID"].ToString(),
                    Quantity = Convert.ToInt32(rdr["Quantity"]),
                    TotalPrice = Convert.ToDecimal(rdr["Price"]) * Convert.ToInt32(rdr["Quantity"])
                };

                // Create InvoiceModel object
                InvoiceModel invoiceModel = new InvoiceModel
                {
                    InvoiceID = rdr["InvoiceID"].ToString(),
                    CustomerID = rdr["CustomerID"].ToString(),
                    InvoiceDate = Convert.ToDateTime(rdr["InvoiceDate"])
                };

                // Create ProductModel object
                ProductModel productModel = new ProductModel
                {
                    ProductID = rdr["ProductID"].ToString(),
                    ProductName = rdr["ProductName"].ToString(),
                    Price = Convert.ToDecimal(rdr["Price"])
                };

                // Create InvoiceWithDetailsModel object
                InvoiceWithDetailsModel invoiceWithDetailsModel = new InvoiceWithDetailsModel
                {
                    invoiceDetailModel = invoiceDetailModel,
                    invoiceModel = invoiceModel,
                    productModel = productModel
                };

                // Add the object to the list
                invoiceWithDetailsList.Add(invoiceWithDetailsModel);
            }
            con.Close();
            return invoiceWithDetailsList;
        }

        // Method to retrieve the list of customers
        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();

            using SqlConnection con = new SqlConnection(connectionString);

            string sqlQuery = "SELECT DISTINCT CustomerID, CustomerName, Phone FROM Customers";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                CustomerModel customer = new CustomerModel
                {
                    CustomerID = rdr["CustomerID"].ToString(),
                    CustomerName = rdr["CustomerName"].ToString(),
                    Phone = rdr["Phone"].ToString()
                };

                customerList.Add(customer);
            }
            con.Close();

            return customerList;
        }

        // Method to update invoice and invoice details
        public void UpdateInvoiceAndInvoiceDetail(InvoiceModel invoiceModel, InvoiceDetailModel invoiceDetailModel)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string sqlUpdateInvoice = "UPDATE Invoices SET InvoiceDate = @InvoiceDate WHERE InvoiceID = @InvoiceID";
            string sqlUpdateInvoiceDetail = "UPDATE InvoiceDetails SET Quantity = @Quantity WHERE InvoiceDetailID = @InvoiceDetailID AND InvoiceID = @InvoiceID";

            SqlCommand cmdUpdateInvoice = new SqlCommand(sqlUpdateInvoice, con);
            SqlCommand cmdUpdateInvoiceDetail = new SqlCommand(sqlUpdateInvoiceDetail, con);

            cmdUpdateInvoice.Parameters.AddWithValue("@InvoiceDate", invoiceModel.InvoiceDate);
            cmdUpdateInvoice.Parameters.AddWithValue("@InvoiceID", invoiceModel.InvoiceID);

            cmdUpdateInvoiceDetail.Parameters.AddWithValue("@Quantity", invoiceDetailModel.Quantity);
            cmdUpdateInvoiceDetail.Parameters.AddWithValue("@InvoiceDetailID", invoiceDetailModel.InvoiceDetailID);
            cmdUpdateInvoiceDetail.Parameters.AddWithValue("@InvoiceID", invoiceModel.InvoiceID);

            try
            {
                con.Open();
                cmdUpdateInvoice.ExecuteNonQuery();
                cmdUpdateInvoiceDetail.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error occurred while updating data.", ex);
            }
            finally
            {
                con.Close();
            }
        }

        // Method to insert invoice and its details
            public void InsertInvoice(InvoiceModel invoiceModel, List<int> quantities, List<string> productIDs)
            {
                using SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                using SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    //string sqlMaxInvoiceID = "SELECT ISNULL(MAX(CAST(SUBSTRING(InvoiceID, 4, LEN(InvoiceID)) AS INT)), 0) FROM Invoices";
                    //SqlCommand cmdMaxInvoiceID = new SqlCommand(sqlMaxInvoiceID, con, transaction);
                    //int maxInvoiceID = (int)cmdMaxInvoiceID.ExecuteScalar();

                    //string newInvoiceID = "ABC" + (maxInvoiceID + 1).ToString("D5");
                    string newInvoiceID = GetNewInvoiceID();

                    string sqlInsertInvoice = "INSERT INTO Invoices (InvoiceID, CustomerID, InvoiceDate) VALUES (@InvoiceID, @CustomerID, @InvoiceDate)";
                    SqlCommand cmdInsertInvoice = new SqlCommand(sqlInsertInvoice, con, transaction);
                    cmdInsertInvoice.Parameters.AddWithValue("@InvoiceID", newInvoiceID);
                    cmdInsertInvoice.Parameters.AddWithValue("@CustomerID", invoiceModel.CustomerID);
                    cmdInsertInvoice.Parameters.AddWithValue("@InvoiceDate", invoiceModel.InvoiceDate);
                    cmdInsertInvoice.ExecuteNonQuery();

                    string sqlMaxInvoiceDetailID = "SELECT ISNULL(MAX(CAST(SUBSTRING(InvoiceDetailID, 4, LEN(InvoiceDetailID)) AS INT)), 0) FROM InvoiceDetails";
                    SqlCommand cmdMaxInvoiceDetailID = new SqlCommand(sqlMaxInvoiceDetailID, con, transaction);
                    int maxInvoiceDetailID = (int)cmdMaxInvoiceDetailID.ExecuteScalar();

                    for (int i = 0; i < productIDs.Count; i++) //Create Invoice Details belong InvoiceID 
                    {
                        string sqlInsertInvoiceDetail = "INSERT INTO InvoiceDetails (InvoiceDetailID, InvoiceID, ProductID, Quantity, TotalPrice) VALUES (@InvoiceDetailID, @InvoiceID, @ProductID, @Quantity, @TotalPrice)";
                        SqlCommand cmdInsertInvoiceDetail = new SqlCommand(sqlInsertInvoiceDetail, con, transaction);

                        string newInvoiceDetailID = "AAA" + (maxInvoiceDetailID + 1).ToString("D5");
                        maxInvoiceDetailID++;

                        cmdInsertInvoiceDetail.Parameters.AddWithValue("@InvoiceDetailID", newInvoiceDetailID);
                        cmdInsertInvoiceDetail.Parameters.AddWithValue("@InvoiceID", newInvoiceID);
                        cmdInsertInvoiceDetail.Parameters.AddWithValue("@ProductID", productIDs[i]);
                        cmdInsertInvoiceDetail.Parameters.AddWithValue("@Quantity", quantities[i]);
                        cmdInsertInvoiceDetail.Parameters.AddWithValue("@TotalPrice", 100);

                        cmdInsertInvoiceDetail.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error occurred while inserting invoice and its details: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        // Method to delete invoice and its details
        public void DeleteInvoice(string invoiceDetailID, string invoiceID)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlTransaction transaction = con.BeginTransaction();

            try
            {
                string sqlDeleteInvoiceDetail = "DELETE FROM InvoiceDetails WHERE InvoiceDetailID = @InvoiceDetailID";
                SqlCommand cmdDeleteInvoiceDetail = new SqlCommand(sqlDeleteInvoiceDetail, con, transaction);
                cmdDeleteInvoiceDetail.Parameters.AddWithValue("@InvoiceDetailID", invoiceDetailID.ToUpper());
                int rowsAffected = cmdDeleteInvoiceDetail.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    string sqlCountInvoiceDetails = "SELECT COUNT(*) FROM InvoiceDetails WHERE InvoiceID = @InvoiceID";
                    SqlCommand cmdCount = new SqlCommand(sqlCountInvoiceDetails, con, transaction);
                    cmdCount.Parameters.AddWithValue("@InvoiceID", invoiceID.ToUpper());
                    int detailCount = (int)cmdCount.ExecuteScalar();

                    if (detailCount == 0)
                    {
                        string sqlDeleteInvoice = "DELETE FROM Invoices WHERE InvoiceID = @InvoiceID";
                        SqlCommand cmdDeleteInvoice = new SqlCommand(sqlDeleteInvoice, con, transaction);
                        cmdDeleteInvoice.Parameters.AddWithValue("@InvoiceID", invoiceID.ToUpper());
                        cmdDeleteInvoice.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error occurred while deleting invoice: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Method to check if a product exists in any invoice
        public bool ProductCheck(string productId)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string query = "SELECT COUNT(*) FROM InvoiceDetails WHERE ProductID = @ProductID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ProductID", productId);

            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }

        // Method to check if the product is in the order
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

        public string GetNewInvoiceID() {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using SqlTransaction transaction = con.BeginTransaction();
            string newInvoiceID = "";
            try
            {
                string sqlMaxInvoiceID = "SELECT ISNULL(MAX(CAST(SUBSTRING(InvoiceID, 4, LEN(InvoiceID)) AS INT)), 0) FROM Invoices";
                SqlCommand cmdMaxInvoiceID = new SqlCommand(sqlMaxInvoiceID, con, transaction);
                int maxInvoiceID = (int)cmdMaxInvoiceID.ExecuteScalar();

                newInvoiceID += "ABC" + (maxInvoiceID + 1).ToString("D5");
            }
            catch (SqlException ex)
            {
                throw new Exception("Error occurred while updating data.", ex);
            }
            finally
            {
                con.Close();
            }
            return newInvoiceID;
        }
    }
}
