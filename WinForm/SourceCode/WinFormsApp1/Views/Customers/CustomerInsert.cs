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
    public partial class CustomerInsert : Form
    {
        private CustomerDataAccessLayer customerDataAccessLayer;
        public event Action customerInserted;
        public CustomerInsert()
        {
            InitializeComponent();
            customerDataAccessLayer = new CustomerDataAccessLayer();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Launch_Click(object sender, EventArgs e)
        {
            string customerName = textBoxCustomerName.Text;
            string phone = textBoxPhone.Text;

            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên khách hàng và số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CustomerModel newCustomer = new CustomerModel
            {
                CustomerName = customerName.Trim(),
                Phone = phone.Trim()
            };

            try
            {
                customerDataAccessLayer.InsertCustomer(newCustomer);
                MessageBox.Show("Khách hàng đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                customerInserted?.Invoke(); // gọi sự kiện insert customer

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerInsert_Load(object sender, EventArgs e)
        {

        }
    }
}
