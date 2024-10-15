namespace WinFormsApp1.Views
{
    partial class Customers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CustomerTable = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            button1 = new Button();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // CustomerTable
            // 
            CustomerTable.Location = new Point(12, 96);
            CustomerTable.Name = "CustomerTable";
            CustomerTable.Size = new Size(931, 385);
            CustomerTable.TabIndex = 0;
            CustomerTable.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(928, 78);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 55);
            label1.Name = "label1";
            label1.Size = new Size(170, 23);
            label1.TabIndex = 0;
            label1.Text = "CUSTOMERS-LIST";
            label1.Click += label1_Click_1;
            // 
            // panel3
            // 
            panel3.Controls.Add(button1);
            panel3.Location = new Point(12, 487);
            panel3.Name = "panel3";
            panel3.Size = new Size(931, 78);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(751, 3);
            button1.Name = "button1";
            button1.Size = new Size(155, 47);
            button1.TabIndex = 0;
            button1.Text = "Launch";
            button1.UseVisualStyleBackColor = false;
            // 
            // Customers
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
            Name = "Customers";
            Padding = new Padding(6);
            Text = "Customers";
            Load += Customers_Load;
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
    }
}