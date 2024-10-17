using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp1.Views;

namespace WinFormsApp1
{
    // Main form of the application
    public partial class Home : Form
    {
        private Form currentForm = null; 

        public Home()
        {
            InitializeComponent();
        }

        // Event handler for form load event
        private void fCustomers_Load(object sender, EventArgs e)
        {
        }

        // Event handler for the panel paint event (navbar)
        private void navbar(object sender, PaintEventArgs e)
        {
        }

        // Method to show a child form within a panel
        private void ShowChildFormInPanel(Form childForm, Panel panelContainer)
        {
            if (currentForm != null)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            // Set up the new child form
            currentForm = childForm;
            childForm.TopLevel = false; 
            childForm.FormBorderStyle = FormBorderStyle.None; 
            childForm.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(childForm);
            childForm.Show(); 
        }

        // Event handler for the panel paint event (for customer panel)
        private void pCustomers(object sender, PaintEventArgs e)
        {
        }

        // Event handler for button1 click (showing customers)
        private void button1_Click(object sender, EventArgs e)
        {
            ShowChildFormInPanel(new CustomerList(), panel2);
        }

        // Event handler for button2 click (showing products)
        private void button2_Click(object sender, EventArgs e)
        {
            ShowChildFormInPanel(new ProductList(), panel2);
        }

        // Event handler for button3 click (showing invoices)
        private void button3_Click(object sender, EventArgs e)
        {
            ShowChildFormInPanel(new Invoices(), panel2);
        }
    }
}
