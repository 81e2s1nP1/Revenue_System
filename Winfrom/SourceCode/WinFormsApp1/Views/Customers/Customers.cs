using Revenue_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Services;
using WinFormsApp1.Views.Customers;

namespace WinFormsApp1.Views
{
    public partial class CustomerList : Form
    {
        private CustomerDataAccessLayer customerDataAccessLayer;

        public CustomerList()
        {
            InitializeComponent();
            customerDataAccessLayer = new CustomerDataAccessLayer();
        }


        //Location list customer render
        private void pMiddleCustomer(object sender, PaintEventArgs e)
        {
            ReloadCustomerList();
        }

        private void pTopCustomer(object sender, PaintEventArgs e)
        {
        }

        private void pBottomCustomer(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            // Logic cho label (nếu cần)
        }

        private void ShowActionForm(object sender, EventArgs e)
        {
            // Get the current DataGridView
            DataGridView existingDataGridView = CustomerTable.Controls.OfType<DataGridView>().FirstOrDefault();

            // Check if DataGridView is not null and a row is selected
            if (existingDataGridView != null && existingDataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = existingDataGridView.SelectedRows[0];

                // Retrieve CustomerID from the selected row
                string customerID = selectedRow.Cells["CustomerID"].Value.ToString();

                // Confirm deletion
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Delete customer from the database
                    customerDataAccessLayer.DeleteCustomer(customerID);

                    // Refresh the customer list
                    ReloadCustomerList();

                    MessageBox.Show("Customer deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        private void ShowInsertForm(object sender, EventArgs e)
        {
            CustomerInsert customerInsert = new CustomerInsert();
            customerInsert.ShowDialog(this);
        }

        private void showUpdateForm_Click(object sender, EventArgs e)
        {
            CustomerUpdate customerUpdate = new CustomerUpdate();
            // Get the current DataGridView
            DataGridView existingDataGridView = CustomerTable.Controls.OfType<DataGridView>().FirstOrDefault();

            // Check if DataGridView is not null and a row is selected
            if (existingDataGridView != null && existingDataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = existingDataGridView.SelectedRows[0];
                // Retrieve CustomerID, CustomerName, Phone from the selected row
                string customerID = selectedRow.Cells["CustomerID"].Value.ToString();
                string customerName = selectedRow.Cells["CustomerName"].Value.ToString();
                string phone = selectedRow.Cells["Phone"].Value.ToString();

                customerUpdate.SetCustomerInfo(customerID, customerName, phone);
                customerUpdate.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        public void ReloadCustomerList()
        {
            // Find existing DataGridView
            DataGridView existingDataGridView = CustomerTable.Controls.OfType<DataGridView>().FirstOrDefault();

            // If a DataGridView already exists, update its data source
            if (existingDataGridView != null)
            {
                List<CustomerModel> customerList = customerDataAccessLayer.GetAllCustomers();
                existingDataGridView.DataSource = customerList;

                // Optionally, check if customerList is empty and handle that case
                if (customerList == null || customerList.Count == 0)
                {
                    MessageBox.Show("No customers found.");
                }
            }
            else
            {
                // Clear existing controls from the CustomerTable
                CustomerTable.Controls.Clear();

                // Create a new DataGridView with appropriate settings
                DataGridView dataGridView = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToResizeColumns = false,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect
                };

                // Add the new DataGridView to the CustomerTable
                CustomerTable.Controls.Add(dataGridView);

                // Retrieve the list of customers and set as DataSource
                List<CustomerModel> customerList = customerDataAccessLayer.GetAllCustomers();
                dataGridView.DataSource = customerList;

                // Optionally, check if customerList is empty and handle that case
                if (customerList == null || customerList.Count == 0)
                {
                    MessageBox.Show("No customers found.");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}