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
    public partial class ProductInsert : Form
    {
        private ProductDataAccessLayer productDataAccessLayer;
        public event Action ProductInserted;
        public ProductInsert()
        {
            productDataAccessLayer = new ProductDataAccessLayer();
            InitializeComponent();
        }

        private void Hide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Launch_Click(object sender, EventArgs e)
        {
            string productName = textBoxProductName.Text;
            string price = textBoxPrice.Text;

            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Please enter the full product name and price.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(price, out decimal parsedPrice))
            {
                MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductModel newProduct = new ProductModel
            {
                ProductName = productName.Trim(),
                Price = parsedPrice
            };

            try
            {
                productDataAccessLayer.InsertProduct(newProduct);
                MessageBox.Show("The product has been added successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi sự kiện ProductInserted
                ProductInserted?.Invoke();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductInsert_Load(object sender, EventArgs e)
        {

        }
    }
}
