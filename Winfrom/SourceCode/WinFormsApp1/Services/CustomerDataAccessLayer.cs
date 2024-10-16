using Revenue_System.Models;
using System.Data.SqlClient;


namespace WinFormsApp1.Services
{
    public class CustomerDataAccessLayer
    {
        string connectionString = "data source=PA; database=system_revenue; integrated security=SSPI";

        // Method to retrieve the entire list of customers from the database
        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();

            using SqlConnection con = new SqlConnection(connectionString);

            string sqlQuery = "SELECT CustomerID, CustomerName, Phone FROM Customers";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                CustomerModel customer = new CustomerModel
                {
                    CustomerID = rdr["CustomerID"]?.ToString() ?? string.Empty,
                    CustomerName = rdr["CustomerName"]?.ToString() ?? string.Empty,
                    Phone = rdr["Phone"]?.ToString() ?? string.Empty
                };

                customerList.Add(customer);
            }
            con.Close();
            return customerList;
        }

        // Method to insert customer information
        public void InsertCustomer(CustomerModel customerModel)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            using SqlTransaction transaction = con.BeginTransaction();
            try
            {
                // Get the current maximum CustomerID value (ignoring the "AT18N" prefix)
                string sqlMaxCustomerID = "SELECT ISNULL(MAX(CAST(SUBSTRING(CustomerID, 6, LEN(CustomerID)) AS INT)), 0) FROM Customers";
                SqlCommand cmdMaxCustomerID = new SqlCommand(sqlMaxCustomerID, con, transaction);
                int maxCustomerID = (int)cmdMaxCustomerID.ExecuteScalar();

                // Generate a new CustomerID by incrementing the maxCustomerID
                string customerIDCurrent = "AT18N" + (maxCustomerID + 1).ToString("D5");

                // Insert the customer into the Customers table
                string sqlQuery = "INSERT INTO Customers (CustomerID, CustomerName, Phone) VALUES (@CustomerID, @CustomerName, @Phone)";
                SqlCommand cmd = new SqlCommand(sqlQuery, con, transaction);

                cmd.Parameters.AddWithValue("@CustomerID", customerIDCurrent);
                cmd.Parameters.AddWithValue("@CustomerName", customerModel.CustomerName);
                cmd.Parameters.AddWithValue("@Phone", customerModel.Phone);

                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("An error occurred while adding the customer: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Method to update customer information
        public void UpdateCustomer(CustomerModel customerModel)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            {
                string sqlQuery = "UPDATE Customers SET CustomerName = @CustomerName, Phone = @Phone WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@CustomerName", customerModel.CustomerName);
                cmd.Parameters.AddWithValue("@Phone", customerModel.Phone);
                cmd.Parameters.AddWithValue("@CustomerID", customerModel.CustomerID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Method to delete a customer by id
        public void DeleteCustomer(string id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            {
                string sqlQuery = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.AddWithValue("@CustomerID", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
