﻿using Revenue_System.Models;
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
        private CustomerList customerList;
        public CustomerInsert()
        {
            InitializeComponent();
            customerDataAccessLayer = new CustomerDataAccessLayer();
            customerList = new CustomerList();
        }

        private void CustomerInsert_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}