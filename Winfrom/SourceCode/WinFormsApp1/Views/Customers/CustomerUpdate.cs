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

namespace WinFormsApp1.Views.Customers
{
    public partial class CustomerUpdate : Form
    {
        private CustomerDataAccessLayer customerDataAccessLayer;
        private CustomerList customerList;
        public CustomerUpdate()
        {
            InitializeComponent();
            customerDataAccessLayer = new CustomerDataAccessLayer();
            customerList = new CustomerList();
        }

        private void LTitleForm_Click(object sender, EventArgs e)
        {

        }

        private void CustomerUpdate_Load(object sender, EventArgs e)
        {

        }

        private void HideUpdt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Ptextbox_Paint(object sender, PaintEventArgs e)
        {

        }

        public void SetCustomerInfo(string customerID, string customerName, string phone)
        {
            textBoxCusIDUpdate.Text = customerID ?? string.Empty;
            textBoxCusIDUpdate.Visible = false;
            textBoxCusNameUpdate.Text = customerName;
            textBoxCusPhoneUpdate.Text = phone;
        }

        private void textBoxCusIDUpdate_TextChanged(object sender, EventArgs e)
        {

        }

        //handle click update customer event
        private void UPDATE_Click(object sender, EventArgs e)
        {
            string customerId = textBoxCusIDUpdate.Text;
            string customerName = textBoxCusNameUpdate.Text;
            string phone = textBoxCusPhoneUpdate.Text;
            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter both customer name and phone number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CustomerModel updateCustomer = new CustomerModel
            {
                CustomerID = customerId.Trim(),
                CustomerName = customerName.Trim(),
                Phone = phone.Trim()
            };

            try
            {
                customerDataAccessLayer.UpdateCustomer(updateCustomer);
                MessageBox.Show("Customer updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                // Refresh the customer list
                //customerList.ReloadCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
