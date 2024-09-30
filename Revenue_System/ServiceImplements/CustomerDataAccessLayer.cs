﻿using Revenue_System.Models;
using Revenue_System.Service;
using System.Data;
using System.Data.SqlClient;

namespace Revenue_System.ServiceImplements
{
    public class CustomerDataAccessLayer : CustomerInterface
    {
        string connectionString = "data source=PA; database=system_revenue; integrated security=SSPI";

        // Phương thức chèn khách hàng vào bảng
        public void InsertCustomer(CustomerModel customerModel)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "INSERT INTO Customers (CustomerID, CustomerName, Phone) VALUES (@CustomerID, @CustomerName, @Phone)";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            cmd.Parameters.AddWithValue("@CustomerID", customerModel.CustomerID.ToUpper());
            cmd.Parameters.AddWithValue("@CustomerName", customerModel.CustomerName);
            cmd.Parameters.AddWithValue("@Phone", customerModel.Phone);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        // Phương thức lấy toàn bộ danh sách khách hàng trong database
        public List<CustomerModel> GetAllCustomer()
        {
            List<CustomerModel> lstCustomer = new List<CustomerModel>();

            using SqlConnection con = new SqlConnection(connectionString);

            string sqlQuery = "SELECT CustomerID, CustomerName, Phone FROM Customers";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                CustomerModel customer = new CustomerModel();

                customer.CustomerID = rdr["CustomerID"].ToString();
                customer.CustomerName = rdr["CustomerName"].ToString();
                customer.Phone = rdr["Phone"].ToString();

                lstCustomer.Add(customer);
            }
            con.Close();
            return lstCustomer;
        }


        //Phương thức cập nhật thông tin của khách hàng
        public void UpdateCustomer(CustomerModel customerModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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

        //Phương thức xóa khách hàng theo id
        public void DeleteCustomer(string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CustomerID", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
