using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1.Views
{
    partial class CustomerList
    {
        // Required designer variable
        private System.ComponentModel.IContainer components = null;

        // Clean up any resources being used
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // Required method for Designer support - do not modify the contents of this method with the code editor
        private void InitializeComponent()
        {
            CustomerTable = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            showUpdateForm = new Button();
            button2 = new Button();
            button1 = new Button();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // CustomerTable
            // 
            CustomerTable.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CustomerTable.Location = new Point(12, 96);
            CustomerTable.Name = "CustomerTable";
            CustomerTable.Size = new Size(931, 385);
            CustomerTable.TabIndex = 0;
            CustomerTable.Paint += pMiddleCustomer;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(928, 78);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 55);
            label1.Name = "label1";
            label1.Size = new Size(187, 24);
            label1.TabIndex = 0;
            label1.Text = "CUSTOMERS-LIST";
            // 
            // panel3
            // 
            panel3.Controls.Add(showUpdateForm);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Location = new Point(12, 487);
            panel3.Name = "panel3";
            panel3.Size = new Size(931, 78);
            panel3.TabIndex = 2;
            // 
            // showUpdateForm
            // 
            showUpdateForm.BackColor = Color.DodgerBlue;
            showUpdateForm.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            showUpdateForm.Location = new Point(457, 3);
            showUpdateForm.Name = "showUpdateForm";
            showUpdateForm.Size = new Size(155, 47);
            showUpdateForm.TabIndex = 2;
            showUpdateForm.Text = "UPDATE";
            showUpdateForm.UseVisualStyleBackColor = false;
            showUpdateForm.Click += showUpdateForm_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(618, 3);
            button2.Name = "button2";
            button2.Size = new Size(155, 47);
            button2.TabIndex = 1;
            button2.Text = "DELETE";
            button2.UseVisualStyleBackColor = false;
            button2.Click += ShowActionForm;
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(776, 3);
            button1.Name = "button1";
            button1.Size = new Size(155, 47);
            button1.TabIndex = 0;
            button1.Text = "LAUNCH";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ShowInsertForm;
            // 
            // CustomerList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(955, 577);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(CustomerTable);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerList";
            Padding = new Padding(6);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customers";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel CustomerTable;
        private Panel panel2;
        private Panel panel3;
        private Button button1;
        private Label label1;
        private Button button2;
        private Button showUpdateForm;
    }
}
