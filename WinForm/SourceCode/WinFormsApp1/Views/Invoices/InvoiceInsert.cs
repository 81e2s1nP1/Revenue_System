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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Revenue_System.Models;

namespace WinFormsApp1.Views.Invoices
{
    public partial class InvoiceInsert : Form
    {
        private InvoiceDataAccessLayer invoiceDataAccessLayer;
        private ProductDataAccessLayer productDataAccessLayer;
        private CustomerDataAccessLayer customerDataAccessLayer;
        private DataGridView dataGridView;
        public event Action InvoiceInserted;
        public InvoiceInsert()
        {
            InitializeComponent();
            invoiceDataAccessLayer = new InvoiceDataAccessLayer();
            productDataAccessLayer = new ProductDataAccessLayer();
            customerDataAccessLayer = new CustomerDataAccessLayer();
        }

        private void InvoiceInsert_Load(object sender, EventArgs e)
        {
            InvoiceIDValue.Text = invoiceDataAccessLayer.GetNewInvoiceID();
            InvoiceDateValue.Text = DateTime.Now.ToString("yyyy-MM-dd");

            var customers = customerDataAccessLayer.GetAllCustomers();
            CustomerIDSelection.DataSource = customers;
            CustomerIDSelection.ValueMember = "CustomerID";

            // Get the list of products
            var products = productDataAccessLayer.GetAllProducts();

            // Assign the list of products to ListBox
            listBoxProductID.DataSource = products;
            listBoxProductID.DisplayMember = "ProductName";
            listBoxProductID.ValueMember = "ProductID";

            // Set multi-select mode for ListBox
            listBoxProductID.SelectionMode = SelectionMode.MultiExtended;

            // Initialize and configure DataGridView
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Add columns to DataGridView
            dataGridView.Columns.Add("ProductID", "Product ID");
            dataGridView.Columns.Add("ProductName", "Product Name");
            dataGridView.Columns.Add("Price", "Price (VND)");
            dataGridView.Columns.Add("Quantity", "Quantity");

            TableInvoiceCreate.Controls.Add(dataGridView);
        }

        private void listBoxProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if listBoxProductID is initialized
            if (listBoxProductID == null || dataGridView == null)
            {
                return; // If anything is not initialized
            }

            // Clear old rows in DataGridView to refresh the list
            dataGridView.Rows.Clear();

            // Check if no items are selected in the ListBox
            if (listBoxProductID.SelectedItems.Count == 0)
            {
                return;
            }

            // Iterate through selected products in ListBox
            foreach (var item in listBoxProductID.SelectedItems)
            {
                var product = item as ProductModel;
                if (product != null)
                {
                    string formattedPrice = product.Price.ToString("N0");
                    dataGridView.Rows.Add(product.ProductID, product.ProductName, formattedPrice, 1);
                }
            }
        }


        private void HandleClickLuanchEnvent(object sender, EventArgs e)
        {
            try
            {
                // Get the selected customer ID from ComboBox
                var selectedCustomerID = CustomerIDSelection.SelectedValue;
                string customerId = "";
                if (selectedCustomerID != null)
                {
                    customerId = selectedCustomerID.ToString(); // Assign value to customerId
                }
                else
                {
                    throw new InvalidOperationException("No customer selected.");
                }

                // Validate and get the invoice date
                if (!DateTime.TryParse(InvoiceDateValue.Text, out DateTime invoiceDate))
                {
                    throw new FormatException("Invalid invoice date format.");
                }

                // Get the number of rows in DataGridView
                int rowCount = dataGridView.Rows.Count;

                // Check if any products are selected
                if (rowCount == 0)
                {
                    throw new InvalidOperationException("No products selected.");
                }

                // Initialize lists to store product IDs and quantities
                List<string> productIds = new List<string>();
                List<int> quantities = new List<int>(); // List to store quantities

                // Loop through all rows in DataGridView
                for (int i = 0; i < rowCount; i++)
                {
                    if (dataGridView.Rows[i].IsNewRow) continue; // Skip new row if any

                    // Get ProductID from column 0
                    string productId = dataGridView.Rows[i].Cells[0].Value?.ToString();
                    // Get Quantity from column 3
                    int quantity;
                    if (!int.TryParse(dataGridView.Rows[i].Cells[3].Value?.ToString(), out quantity))
                    {
                        throw new FormatException($"Invalid quantity format in row {i + 1}.");
                    }

                    // Add ProductID and Quantity to lists
                    if (!string.IsNullOrEmpty(productId)) // Check if ProductID is not null or empty
                    {
                        productIds.Add(productId);
                        quantities.Add(quantity); // Add Quantity to the list
                    }
                    else
                    {
                        throw new InvalidOperationException($"Product ID cannot be null or empty in row {i + 1}.");
                    }
                }

                // Initialize InvoiceModel
                InvoiceModel invoice = new InvoiceModel
                {
                    CustomerID = customerId,
                    InvoiceDate = invoiceDate
                };

                // Call InsertInvoice method with productIds and quantities
                invoiceDataAccessLayer.InsertInvoice(invoice, quantities, productIds);
                MessageBox.Show("Invoice created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi sự kiện ProductInserted
                InvoiceInserted?.Invoke();

                this.Hide();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
