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
        public CustomerUpdate()
        {
            InitializeComponent();
            customerDataAccessLayer = new CustomerDataAccessLayer();
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

        private void UPDATE_Click(object sender, EventArgs e)
        { }
        //private void UPDATE_Click(object sender, EventArgs e)
        //{
        //        string customerId = textBoxCusIDUpdate.Text;
        //        string customerName = textBoxCusNameUpdate.Text;
        //        string phone = textBoxCusPhoneUpdate.Text;
        //        //CustomerModel customer = new CustomerModel(customerId, customerName, phone);
        //        // Delete customer from the database
        //        customerDataAccessLayer.UpdateCustomer(customer);

        //        // Refresh the customer list
        //        //ReloadCustomerList();

        //        MessageBox.Show("Customer deleted successfully!");
        //}
    }
}
