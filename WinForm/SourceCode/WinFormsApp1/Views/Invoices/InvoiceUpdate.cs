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

namespace WinFormsApp1.Views.Invoices
{
    public partial class InvoiceUpdate : Form
    {
        private InvoiceDataAccessLayer invoiceDataAccessLayer;
        public InvoiceUpdate()
        {
            invoiceDataAccessLayer = new InvoiceDataAccessLayer();
            InitializeComponent();
        }

        private void InvoiceUpdate_Load(object sender, EventArgs e)
        {

        }

        public void SetInvoiceInfo(CustomerModel customerModel, ProductModel productModel, InvoiceModel invoiceModel, InvoiceDetailModel invoiceDetailModel)
        {
            LInvoiceCustomerID.Text = invoiceModel.CustomerID ?? string.Empty;
            LInvoicePrice.Text = productModel.Price.ToString("N0") ?? string.Empty;
            LInvoiceID.Text = invoiceModel.InvoiceID ?? string.Empty;
            LInvoiceDate.Text = invoiceModel.InvoiceDate.ToString("yyyy-MM-dd") ?? string.Empty;
            LInvoiceProductID.Text = productModel.ProductID ?? string.Empty;
            LInvoiceProductName.Text = productModel.ProductName ?? string.Empty;
            QuantityUpdate.Value = invoiceDetailModel.Quantity;
            LInvoiceDetailID.Text = invoiceDetailModel.InvoiceDetailID ?? string.Empty;
            LInvoiceDetailID.Visible = false;
        }


        private void HideUpdt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            // Get values from the UI controls
            int quantity = (int)QuantityUpdate.Value;
            string invoiceDateStr = LInvoiceDate.Text;
            string invoiceID = LInvoiceID.Text;
            string invoiceDetailID = LInvoiceDetailID.Text;

            // Check if the quantity is greater than 0
            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the invoice date is valid
            if (!DateTime.TryParse(invoiceDateStr, out DateTime invoiceDate))
            {
                MessageBox.Show("Please enter a valid invoice date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if InvoiceDetailID is null or empty
            if (string.IsNullOrEmpty(invoiceDetailID))
            {
                MessageBox.Show("No invoice detail selected to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create invoice and invoice detail models to update
            InvoiceModel updateInvoice = new InvoiceModel
            {
                InvoiceID = invoiceID,
                InvoiceDate = invoiceDate
            };

            InvoiceDetailModel updateInvoiceDetail = new InvoiceDetailModel
            {
                InvoiceDetailID = invoiceDetailID,
                Quantity = quantity
            };

            // Call the update method from the data access layer
            try
            {
                invoiceDataAccessLayer.UpdateInvoiceAndInvoiceDetail(updateInvoice, updateInvoiceDetail);
                MessageBox.Show("Invoice updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                /* 
                Optionally reload the invoice list if needed
                ReloadInvoiceList(); 
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
