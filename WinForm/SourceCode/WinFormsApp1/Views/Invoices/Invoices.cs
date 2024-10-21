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
using WinFormsApp1.Views.Invoices;

namespace WinFormsApp1.Views
{
    public partial class InvoiceList : Form
    {
        private InvoiceDataAccessLayer invoiceDataAccessLayer;
        private InvoiceUpdate invoiceUpdate;
        public InvoiceList()
        {
            invoiceUpdate = new InvoiceUpdate();
            invoiceDataAccessLayer = new InvoiceDataAccessLayer();
            InitializeComponent();
        }

        private void pMiddleInvoice(object sender, PaintEventArgs e)
        {
            ReloadInvoiceList();
        }

        public void ReloadInvoiceList()
        {
            // Retrieve the list of invoices with details
            List<InvoiceWithDetailsModel> invoiceWithDetailList = invoiceDataAccessLayer.GetInvoiceWithDetails();

            // Check if the list is empty and handle that case
            if (invoiceWithDetailList == null || invoiceWithDetailList.Count == 0)
            {
                MessageBox.Show("No invoices found.");
                return; // Exit early if there are no invoices
            }

            // Find or create the DataGridView
            DataGridView dataGridView = InvoiceTable.Controls.OfType<DataGridView>().FirstOrDefault();

            if (dataGridView == null)
            {
                // Clear existing controls and create a new DataGridView
                InvoiceTable.Controls.Clear();
                dataGridView = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToResizeColumns = false,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect
                };

                // Add the new DataGridView to the InvoiceTable
                InvoiceTable.Controls.Add(dataGridView);

                // Add columns manually for the properties you want to display
                dataGridView.Columns.Add("InvoiceID", "Invoice ID");
                dataGridView.Columns.Add("CustomerID", "Customer ID");
                dataGridView.Columns.Add("ProductID", "Product ID");
                dataGridView.Columns.Add("InvoiceDate", "Invoice Date");
                dataGridView.Columns.Add("ProductName", "Product Name");
                dataGridView.Columns.Add("Price", "Price (VND)");
                dataGridView.Columns.Add("Quantity", "Quantity");
                dataGridView.Columns.Add("TotalPrice", "Total Price (VND)");
            }

            // Clear the rows before adding new data
            dataGridView.Rows.Clear();

            // Format columns
            dataGridView.Columns["Price"].DefaultCellStyle.Format = "#,##0";
            dataGridView.Columns["TotalPrice"].DefaultCellStyle.Format = "#,##0";
            dataGridView.Columns["Quantity"].Width = 80;

            // Populate the DataGridView rows with data
            foreach (var invoiceWithDetail in invoiceWithDetailList)
            {
                // Create a new row
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView,
                    invoiceWithDetail.invoiceModel.InvoiceID,
                    invoiceWithDetail.invoiceModel.CustomerID,
                    invoiceWithDetail.productModel.ProductID,
                    invoiceWithDetail.invoiceModel.InvoiceDate.ToString("yyyy-MM-dd"),
                    invoiceWithDetail.productModel.ProductName,
                    invoiceWithDetail.productModel.Price,
                    invoiceWithDetail.invoiceDetailModel.Quantity,
                    invoiceWithDetail.invoiceDetailModel.TotalPrice
                );

                // Store InvoiceDetailID in the Tag property of the row
                row.Tag = invoiceWithDetail.invoiceDetailModel.InvoiceDetailID;

                // Add the row to the DataGridView
                dataGridView.Rows.Add(row);
            }
        }



        private void handleClickBtnDelete(object sender, EventArgs e)
        {
            // Get the current DataGridView
            DataGridView existingDataGridView = InvoiceTable.Controls.OfType<DataGridView>().FirstOrDefault();

            // Check if DataGridView is not null and a row is selected
            if (existingDataGridView != null && existingDataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = existingDataGridView.SelectedRows[0];

                // Retrieve InvoiceID from the selected row
                string invoiceID = selectedRow.Cells["InvoiceID"].Value.ToString();

                // Retrieve InvoiceDetailID from the Tag property
                string invoiceDetailID = selectedRow.Tag.ToString();

                // Confirm deletion
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this invoice?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Delete invoice and its details from the database
                    invoiceDataAccessLayer.DeleteInvoice(invoiceDetailID, invoiceID);

                    // Refresh the invoice list
                    ReloadInvoiceList();

                    MessageBox.Show("Invoice deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("Please select an invoice to delete.");
            }
        }

        private void handleClickUpdate(object sender, EventArgs e)
        {
            InvoiceUpdate invoiceUpdate = new InvoiceUpdate();

            // Get the current DataGridView
            DataGridView existingDataGridView = InvoiceTable.Controls.OfType<DataGridView>().FirstOrDefault();

            // Check if DataGridView is not null and a row is selected
            if (existingDataGridView != null && existingDataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = existingDataGridView.SelectedRows[0];

                // Retrieve information from the selected row
                string customerID = selectedRow.Cells["CustomerID"].Value.ToString();
                string invoiceID = selectedRow.Cells["InvoiceID"].Value.ToString();
                string invoiceDate = selectedRow.Cells["InvoiceDate"].Value.ToString();
                string productID = selectedRow.Cells["ProductID"].Value.ToString();
                string productName = selectedRow.Cells["ProductName"].Value.ToString();
                string quantity = selectedRow.Cells["Quantity"].Value.ToString();
                string price = selectedRow.Cells["Price"].Value.ToString();
                string totalPrice = selectedRow.Cells["TotalPrice"].Value.ToString();
                // Retrieve InvoiceDetailID from the Tag property
                string invoiceDetailID = selectedRow.Tag.ToString();

                // Create models from the retrieved data
                CustomerModel customerModel = new CustomerModel
                {
                    CustomerID = customerID
                };

                ProductModel productModel = new ProductModel
                {
                    ProductID = productID,
                    ProductName = productName,
                    Price = Convert.ToDecimal(price)
                };

                InvoiceModel invoiceModel = new InvoiceModel
                {
                    InvoiceID = invoiceID,
                    InvoiceDate = Convert.ToDateTime(invoiceDate),
                    CustomerID = customerID
                };

                InvoiceDetailModel invoiceDetailModel = new InvoiceDetailModel
                {
                    InvoiceDetailID = invoiceDetailID,
                    Quantity = Convert.ToInt32(quantity),
                    TotalPrice = Convert.ToDecimal(totalPrice)
                };

                // Set the data into InvoiceUpdate form
                invoiceUpdate.SetInvoiceInfo(customerModel, productModel, invoiceModel, invoiceDetailModel);
                invoiceUpdate.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InvoiceInsert invoiceInsert = new InvoiceInsert();

            invoiceInsert.ShowDialog(this);
        }

        private void SetDataInvoiceLaunch()
        {

        }

        private void InvoiceList_Load(object sender, EventArgs e)
        {

        }
    }
}
