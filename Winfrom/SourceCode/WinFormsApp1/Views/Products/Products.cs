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
using WinFormsApp1.Views.Products;

namespace WinFormsApp1.Views
{
    public partial class ProductList : Form
    {
        private ProductDataAccessLayer productDataAccessLayer;
        public ProductList()
        {
            InitializeComponent();
            productDataAccessLayer = new ProductDataAccessLayer();
        }

        private void pMiddleProduct(object sender, PaintEventArgs e)
        {
            ReloadProductList();
        }

        private void pTopProduct(object sender, PaintEventArgs e)
        {

        }

        private void pBottomProduct(object sender, PaintEventArgs e)
        {

        }

        //method using show Form to cretate Product
        private void showProductInsertForm(object sender, EventArgs e)
        {
            ProductInsert productInsert = new ProductInsert();
            productInsert.ShowDialog(this);
        }

        public void ReloadProductList()
        {
            // Find existing DataGridView
            DataGridView existingDataGridView = ProductTable.Controls.OfType<DataGridView>().FirstOrDefault();

            // Retrieve the list of products
            List<ProductModel> productList = productDataAccessLayer.GetAllProducts();

            // Check if product list is null
            if (productList == null)
            {
                MessageBox.Show("Error retrieving product data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if a DataGridView already exists
            if (existingDataGridView != null)
            {
                // Update the data source of the existing DataGridView
                existingDataGridView.DataSource = productList;

                // Change the header text of the Price column
                existingDataGridView.Columns["Price"].HeaderText = "Price (VND)";

                // Format the Price column
                existingDataGridView.Columns["Price"].DefaultCellStyle.Format = "#,##0";

                // Handle empty product list case
                if (productList.Count == 0)
                {
                    MessageBox.Show("No products found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Clear existing controls from the ProductTable
                ProductTable.Controls.Clear();

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

                // Add the new DataGridView to the ProductTable
                ProductTable.Controls.Add(dataGridView);

                // Set the data source for the new DataGridView
                dataGridView.DataSource = productList;

                // Change the header text of the Price column
                dataGridView.Columns["Price"].HeaderText = "Price (VND)";

                // Format the Price column
                dataGridView.Columns["Price"].DefaultCellStyle.Format = "#,##0";

                // Handle empty product list case
                if (productList.Count == 0)
                {
                    MessageBox.Show("No products found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void handleClickBtnDelete(object sender, EventArgs e)
        {
            // Get the current DataGridView
            DataGridView existingDataGridView = ProductTable.Controls.OfType<DataGridView>().FirstOrDefault();

            // Check if DataGridView is not null and a row is selected
            if (existingDataGridView != null && existingDataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = existingDataGridView.SelectedRows[0];

                // Retrieve CustomerID from the selected row
                string productID = selectedRow.Cells["ProductID"].Value.ToString();

                // Confirm deletion
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Delete customer from the database
                    productDataAccessLayer.DeleteProduct(productID);

                    // Refresh the customer list
                    ReloadProductList();

                    MessageBox.Show("Customer deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        private void showUpdateForm_Click(object sender, EventArgs e)
        {
            ProductUpdate productUpdate = new ProductUpdate();
            // Get the current DataGridView
            DataGridView existingDataGridView = ProductTable.Controls.OfType<DataGridView>().FirstOrDefault();

            // Check if DataGridView is not null and a row is selected
            if (existingDataGridView != null && existingDataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = existingDataGridView.SelectedRows[0];
                // Retrieve CustomerID, CustomerName, Phone from the selected row
                string productID = selectedRow.Cells["ProductID"].Value.ToString();
                string productName = selectedRow.Cells["ProductName"].Value.ToString();
                string price = selectedRow.Cells["Price"].Value.ToString();

                productUpdate.SetProductInfo(productID, productName, price);
                productUpdate.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }
    }
}
