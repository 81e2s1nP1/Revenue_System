using WinFormsApp1.Views;

namespace WinFormsApp1
{
    public partial class Home : Form
    {
        private Form currentForm = null;
        public Home()
        {
            InitializeComponent();
        }

        private void fCustomers_Load(object sender, EventArgs e)
        {
            // Code to execute when the form loads
        }

        private void navbar(object sender, PaintEventArgs e)
        {
            // Code to execute during panel paint event
        }

        private void ShowChildFormInPanel(Form childForm, Panel panelContainer)
        {
            // Nếu đã có form hiện tại, đóng nó
            if (currentForm != null)
            {
                currentForm.Close();
            }

            // Thiết lập form mới
            currentForm = childForm; 
            childForm.TopLevel = false; 
            childForm.FormBorderStyle = FormBorderStyle.None; 
            childForm.Dock = DockStyle.Fill;

            // Xóa các control con trước khi thêm form mới
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(childForm);
            childForm.Show();
        }

        private void pCustomers(object sender, PaintEventArgs e)
        {
            // Code to execute during panel paint event
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowChildFormInPanel(new Customers(), panel2);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ShowChildFormInPanel(new Products(), panel2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowChildFormInPanel(new Invoices(), panel2);
        }

    }
}
