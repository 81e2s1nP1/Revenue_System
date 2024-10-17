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

namespace WinFormsApp1.Views.Products
{
    public partial class ProductUpdate : Form
    {
        private ProductDataAccessLayer productDataAccessLayer;
        public ProductUpdate()
        {
            InitializeComponent();
            productDataAccessLayer = new ProductDataAccessLayer();
        }

        private void ProductUpdate_Load(object sender, EventArgs e)
        {

        }

        public void SetProductInfo(string productID, string productName, string price)
        {
            textBoxProIDUpdate.Text = productID ?? string.Empty;
            textBoxProIDUpdate.Visible = false;
            textBoxProductNameUpdate.Text = productName;
            textBoxProductPriceUpdate.Text = price;
        }

        private void HideUpdt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //handle click update product event
        private void UPDATE_Click(object sender, EventArgs e)
        {
            string productId = textBoxProIDUpdate.Text;
            string productName = textBoxProductNameUpdate.Text;
            string priceText = textBoxProductPriceUpdate.Text;

            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(priceText))
            {
                MessageBox.Show("Please enter both product name and price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Try to parse the price to decimal
            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProductModel updateProduct = new ProductModel
            {
                ProductID = productId.Trim(),
                ProductName = productName.Trim(),
                Price = price
            };

            try
            {
                productDataAccessLayer.UpdateProduct(updateProduct);
                MessageBox.Show("Product updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
