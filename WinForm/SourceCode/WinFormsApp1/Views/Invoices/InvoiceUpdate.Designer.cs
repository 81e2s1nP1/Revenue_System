namespace WinFormsApp1.Views.Invoices
{
    partial class InvoiceUpdate
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
            label1 = new Label();
            panel = new Label();
            label3 = new Label();
            UPDATE = new Button();
            HideUpdt = new Button();
            panel1 = new Panel();
            LInvoiceDetailID = new Label();
            panel11 = new Panel();
            label11 = new Label();
            label9 = new Label();
            LInvoiceProductName = new Label();
            LInvoiceProductID = new Label();
            LInvoiceDate = new Label();
            LInvoiceID = new Label();
            LInvoicePrice = new Label();
            panel10 = new Panel();
            LInvoiceCustomerID = new Label();
            QuantityUpdate = new NumericUpDown();
            panel9 = new Panel();
            panel8 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel5 = new Panel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            panel4 = new Panel();
            label4 = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            LTitleForm = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QuantityUpdate).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 18);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 0;
            label1.Text = "Customer ID :";
            // 
            // panel
            // 
            panel.AutoSize = true;
            panel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel.Location = new Point(341, 48);
            panel.Name = "panel";
            panel.Size = new Size(51, 20);
            panel.TabIndex = 1;
            panel.Text = "Price :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 80);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 2;
            label3.Text = "Invoice ID :";
            // 
            // UPDATE
            // 
            UPDATE.BackColor = Color.DodgerBlue;
            UPDATE.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UPDATE.ForeColor = Color.Black;
            UPDATE.Location = new Point(421, 290);
            UPDATE.Name = "UPDATE";
            UPDATE.Size = new Size(94, 42);
            UPDATE.TabIndex = 4;
            UPDATE.Text = "UPDATE";
            UPDATE.UseVisualStyleBackColor = false;
            UPDATE.Click += UPDATE_Click;
            // 
            // HideUpdt
            // 
            HideUpdt.BackColor = Color.DodgerBlue;
            HideUpdt.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HideUpdt.ForeColor = Color.Black;
            HideUpdt.Location = new Point(521, 290);
            HideUpdt.Name = "HideUpdt";
            HideUpdt.Size = new Size(94, 42);
            HideUpdt.TabIndex = 5;
            HideUpdt.Text = "HIDE";
            HideUpdt.UseVisualStyleBackColor = false;
            HideUpdt.Click += HideUpdt_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(LInvoiceDetailID);
            panel1.Controls.Add(panel11);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(LInvoiceProductName);
            panel1.Controls.Add(LInvoiceProductID);
            panel1.Controls.Add(LInvoiceDate);
            panel1.Controls.Add(LInvoiceID);
            panel1.Controls.Add(panel);
            panel1.Controls.Add(LInvoicePrice);
            panel1.Controls.Add(panel10);
            panel1.Controls.Add(LInvoiceCustomerID);
            panel1.Controls.Add(QuantityUpdate);
            panel1.Controls.Add(panel9);
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.RoyalBlue;
            panel1.Location = new Point(12, 85);
            panel1.Name = "panel1";
            panel1.Size = new Size(619, 189);
            panel1.TabIndex = 6;
            // 
            // LInvoiceDetailID
            // 
            LInvoiceDetailID.AutoSize = true;
            LInvoiceDetailID.Location = new Point(147, 146);
            LInvoiceDetailID.Name = "LInvoiceDetailID";
            LInvoiceDetailID.Size = new Size(56, 22);
            LInvoiceDetailID.TabIndex = 25;
            LInvoiceDetailID.Text = "Invalid";
            // 
            // panel11
            // 
            panel11.BackColor = SystemColors.ActiveCaptionText;
            panel11.Location = new Point(468, 132);
            panel11.Name = "panel11";
            panel11.Size = new Size(135, 2);
            panel11.TabIndex = 11;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(464, 114);
            label11.Name = "label11";
            label11.Size = new Size(39, 22);
            label11.TabIndex = 22;
            label11.Text = "VND";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(561, 41);
            label9.Name = "label9";
            label9.Size = new Size(49, 22);
            label9.TabIndex = 21;
            label9.Text = "(VND)";
            // 
            // LInvoiceProductName
            // 
            LInvoiceProductName.AutoSize = true;
            LInvoiceProductName.Location = new Point(468, 13);
            LInvoiceProductName.Name = "LInvoiceProductName";
            LInvoiceProductName.Size = new Size(56, 22);
            LInvoiceProductName.TabIndex = 20;
            LInvoiceProductName.Text = "Invalid";
            // 
            // LInvoiceProductID
            // 
            LInvoiceProductID.AutoSize = true;
            LInvoiceProductID.Location = new Point(147, 40);
            LInvoiceProductID.Name = "LInvoiceProductID";
            LInvoiceProductID.Size = new Size(56, 22);
            LInvoiceProductID.TabIndex = 19;
            LInvoiceProductID.Text = "Invalid";
            // 
            // LInvoiceDate
            // 
            LInvoiceDate.AutoSize = true;
            LInvoiceDate.Location = new Point(148, 106);
            LInvoiceDate.Name = "LInvoiceDate";
            LInvoiceDate.Size = new Size(56, 22);
            LInvoiceDate.TabIndex = 18;
            LInvoiceDate.Text = "Invalid";
            // 
            // LInvoiceID
            // 
            LInvoiceID.AutoSize = true;
            LInvoiceID.Location = new Point(147, 72);
            LInvoiceID.Name = "LInvoiceID";
            LInvoiceID.Size = new Size(56, 22);
            LInvoiceID.TabIndex = 17;
            LInvoiceID.Text = "Invalid";
            // 
            // LInvoicePrice
            // 
            LInvoicePrice.AutoSize = true;
            LInvoicePrice.Location = new Point(468, 41);
            LInvoicePrice.Name = "LInvoicePrice";
            LInvoicePrice.Size = new Size(56, 22);
            LInvoicePrice.TabIndex = 16;
            LInvoicePrice.Text = "Invalid";
            // 
            // panel10
            // 
            panel10.BackColor = SystemColors.ActiveCaptionText;
            panel10.Location = new Point(468, 63);
            panel10.Name = "panel10";
            panel10.Size = new Size(135, 2);
            panel10.TabIndex = 10;
            // 
            // LInvoiceCustomerID
            // 
            LInvoiceCustomerID.AutoSize = true;
            LInvoiceCustomerID.Location = new Point(148, 13);
            LInvoiceCustomerID.Name = "LInvoiceCustomerID";
            LInvoiceCustomerID.Size = new Size(56, 22);
            LInvoiceCustomerID.TabIndex = 15;
            LInvoiceCustomerID.Text = "Invalid";
            // 
            // QuantityUpdate
            // 
            QuantityUpdate.Location = new Point(468, 78);
            QuantityUpdate.Name = "QuantityUpdate";
            QuantityUpdate.Size = new Size(44, 27);
            QuantityUpdate.TabIndex = 14;
            // 
            // panel9
            // 
            panel9.BackColor = SystemColors.ActiveCaptionText;
            panel9.Location = new Point(147, 63);
            panel9.Name = "panel9";
            panel9.Size = new Size(155, 2);
            panel9.TabIndex = 9;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.ActiveCaptionText;
            panel8.Location = new Point(147, 95);
            panel8.Name = "panel8";
            panel8.Size = new Size(155, 2);
            panel8.TabIndex = 10;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ActiveCaptionText;
            panel6.Location = new Point(464, 36);
            panel6.Name = "panel6";
            panel6.Size = new Size(135, 2);
            panel6.TabIndex = 9;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ActiveCaptionText;
            panel7.Location = new Point(147, 129);
            panel7.Name = "panel7";
            panel7.Size = new Size(155, 2);
            panel7.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveCaptionText;
            panel5.Location = new Point(147, 35);
            panel5.Name = "panel5";
            panel5.Size = new Size(155, 2);
            panel5.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(341, 17);
            label8.Name = "label8";
            label8.Size = new Size(118, 20);
            label8.TabIndex = 13;
            label8.Text = "Product Name :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(341, 80);
            label7.Name = "label7";
            label7.Size = new Size(78, 20);
            label7.TabIndex = 12;
            label7.Text = "Quantity :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(341, 114);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 11;
            label6.Text = "Curency :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 48);
            label5.Name = "label5";
            label5.Size = new Size(92, 20);
            label5.TabIndex = 10;
            label5.Text = "Product ID :";
            // 
            // panel4
            // 
            panel4.Location = new Point(123, 28);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 1);
            panel4.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(16, 114);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 9;
            label4.Text = "Invoice Date :";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Location = new Point(321, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(2, 165);
            panel3.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.Controls.Add(LTitleForm);
            panel2.Location = new Point(12, 25);
            panel2.Name = "panel2";
            panel2.Size = new Size(619, 54);
            panel2.TabIndex = 7;
            // 
            // LTitleForm
            // 
            LTitleForm.AutoSize = true;
            LTitleForm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LTitleForm.ForeColor = Color.Black;
            LTitleForm.Location = new Point(16, 26);
            LTitleForm.Name = "LTitleForm";
            LTitleForm.Size = new Size(174, 28);
            LTitleForm.TabIndex = 8;
            LTitleForm.Text = "UPDATE INVOICE";
            // 
            // InvoiceUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(644, 360);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(HideUpdt);
            Controls.Add(UPDATE);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InvoiceUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InvoiceUpdate";
            Load += InvoiceUpdate_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)QuantityUpdate).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label3;
        private Button UPDATE;
        private Button HideUpdt;
        private Panel panel1;
        private Label label4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel10;
        private Panel panel9;
        private Panel panel8;
        private NumericUpDown QuantityUpdate;
        private Label LTitleForm;
        private Label LInvoiceProductName;
        private Label LInvoiceProductID;
        private Label LInvoiceDate;
        private Label LInvoiceID;
        private Label LInvoiceCustomerName;
        private Label LInvoiceCustomerID;
        private Label panel;
        private Label LInvoicePrice;
        private Label label9;
        private Label LInvoiceDetailID;
        private Label label11;
        private Panel panel11;
    }
}