namespace WinFormsApp1.Views.Customers
{
    partial class CustomerInsert
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            textBoxPhone = new TextBox();
            textBoxCustomerName = new TextBox();
            LabelTop = new Label();
            Launch = new Button();
            Hide = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DodgerBlue;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBoxPhone);
            panel1.Controls.Add(textBoxCustomerName);
            panel1.Location = new Point(17, 99);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 173);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 96);
            label4.Name = "label4";
            label4.Size = new Size(135, 23);
            label4.TabIndex = 7;
            label4.Text = "Number Phone:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 26);
            label3.Name = "label3";
            label3.Size = new Size(144, 23);
            label3.TabIndex = 6;
            label3.Text = "Customer Name:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(12, 122);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(282, 27);
            textBoxPhone.TabIndex = 5;
            // 
            // textBoxCustomerName
            // 
            textBoxCustomerName.Location = new Point(12, 52);
            textBoxCustomerName.Name = "textBoxCustomerName";
            textBoxCustomerName.Size = new Size(282, 27);
            textBoxCustomerName.TabIndex = 4;
            // 
            // LabelTop
            // 
            LabelTop.AutoSize = true;
            LabelTop.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTop.Location = new Point(17, 57);
            LabelTop.Name = "LabelTop";
            LabelTop.Size = new Size(196, 28);
            LabelTop.TabIndex = 1;
            LabelTop.Text = "CREATE CUSTOMER";
            // 
            // Launch
            // 
            Launch.BackColor = Color.DodgerBlue;
            Launch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Launch.Location = new Point(135, 296);
            Launch.Name = "Launch";
            Launch.Size = new Size(94, 42);
            Launch.TabIndex = 2;
            Launch.Text = "LAUNCH";
            Launch.UseVisualStyleBackColor = false;
            Launch.Click += Launch_Click;
            // 
            // Hide
            // 
            Hide.BackColor = Color.DodgerBlue;
            Hide.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Hide.Location = new Point(235, 296);
            Hide.Name = "Hide";
            Hide.Size = new Size(94, 42);
            Hide.TabIndex = 3;
            Hide.Text = "HIDE";
            Hide.UseVisualStyleBackColor = false;
            Hide.Click += button1_Click;
            // 
            // CustomerInsert
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(346, 355);
            Controls.Add(Hide);
            Controls.Add(Launch);
            Controls.Add(LabelTop);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerInsert";
            StartPosition = FormStartPosition.CenterScreen;
            Load += CustomerInsert_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button Launch;
        private new Button Hide;
        private TextBox textBoxPhone;
        private TextBox textBoxCustomerName;
        private Label LabelTop;
        private Label label3;
        private Label label4;
    }
}
