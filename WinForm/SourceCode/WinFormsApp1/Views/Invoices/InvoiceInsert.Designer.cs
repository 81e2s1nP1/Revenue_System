namespace WinFormsApp1.Views.Invoices
{
    partial class InvoiceInsert
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
            panel1 = new Panel();
            listBoxProductID = new ListBox();
            InvoiceDateValue = new Label();
            label7 = new Label();
            InvoiceIDValue = new Label();
            panel5 = new Panel();
            label5 = new Label();
            panel4 = new Panel();
            panel11 = new Panel();
            label4 = new Label();
            CustomerIDSelection = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            TableInvoiceCreate = new Panel();
            Launch = new Button();
            button1 = new Button();
            panel3 = new Panel();
            LabelTop = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(listBoxProductID);
            panel1.Controls.Add(InvoiceDateValue);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(InvoiceIDValue);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel11);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(CustomerIDSelection);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(10, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(679, 131);
            panel1.TabIndex = 0;
            // 
            // listBoxProductID
            // 
            listBoxProductID.FormattingEnabled = true;
            listBoxProductID.ItemHeight = 17;
            listBoxProductID.Location = new Point(468, 16);
            listBoxProductID.Name = "listBoxProductID";
            listBoxProductID.Size = new Size(135, 72);
            listBoxProductID.TabIndex = 18;
            listBoxProductID.SelectedIndexChanged += listBoxProductID_SelectedIndexChanged;
            // 
            // InvoiceDateValue
            // 
            InvoiceDateValue.AutoSize = true;
            InvoiceDateValue.Location = new Point(128, 97);
            InvoiceDateValue.Name = "InvoiceDateValue";
            InvoiceDateValue.Size = new Size(45, 17);
            InvoiceDateValue.TabIndex = 17;
            InvoiceDateValue.Text = "Invalid";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label7.Location = new Point(468, 93);
            label7.Name = "label7";
            label7.Size = new Size(47, 23);
            label7.TabIndex = 8;
            label7.Text = "VND";
            // 
            // InvoiceIDValue
            // 
            InvoiceIDValue.AutoSize = true;
            InvoiceIDValue.Location = new Point(125, 17);
            InvoiceIDValue.Name = "InvoiceIDValue";
            InvoiceIDValue.Size = new Size(45, 17);
            InvoiceIDValue.TabIndex = 16;
            InvoiceIDValue.Text = "Invalid";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveCaptionText;
            panel5.Location = new Point(468, 117);
            panel5.Name = "panel5";
            panel5.Size = new Size(135, 2);
            panel5.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.Location = new Point(356, 96);
            label5.Name = "label5";
            label5.Size = new Size(84, 23);
            label5.TabIndex = 14;
            label5.Text = "Curency :";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaptionText;
            panel4.Location = new Point(125, 37);
            panel4.Name = "panel4";
            panel4.Size = new Size(135, 2);
            panel4.TabIndex = 13;
            // 
            // panel11
            // 
            panel11.BackColor = SystemColors.ActiveCaptionText;
            panel11.Location = new Point(125, 117);
            panel11.Name = "panel11";
            panel11.Size = new Size(135, 2);
            panel11.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(3, 96);
            label4.Name = "label4";
            label4.Size = new Size(119, 23);
            label4.TabIndex = 9;
            label4.Text = "Invoice Date :";
            // 
            // CustomerIDSelection
            // 
            CustomerIDSelection.FormattingEnabled = true;
            CustomerIDSelection.Location = new Point(125, 54);
            CustomerIDSelection.Name = "CustomerIDSelection";
            CustomerIDSelection.Size = new Size(135, 25);
            CustomerIDSelection.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(356, 16);
            label3.Name = "label3";
            label3.Size = new Size(106, 23);
            label3.TabIndex = 2;
            label3.Text = "Product ID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(3, 56);
            label2.Name = "label2";
            label2.Size = new Size(120, 23);
            label2.TabIndex = 1;
            label2.Text = "Customer ID :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(3, 16);
            label1.Name = "label1";
            label1.Size = new Size(99, 23);
            label1.TabIndex = 0;
            label1.Text = "Invoice ID :";
            // 
            // TableInvoiceCreate
            // 
            TableInvoiceCreate.BorderStyle = BorderStyle.FixedSingle;
            TableInvoiceCreate.Location = new Point(10, 197);
            TableInvoiceCreate.Name = "TableInvoiceCreate";
            TableInvoiceCreate.Size = new Size(679, 184);
            TableInvoiceCreate.TabIndex = 1;
            // 
            // Launch
            // 
            Launch.BackColor = Color.DodgerBlue;
            Launch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Launch.Location = new Point(520, 387);
            Launch.Name = "Launch";
            Launch.Size = new Size(82, 36);
            Launch.TabIndex = 6;
            Launch.Text = "LAUNCH";
            Launch.UseVisualStyleBackColor = false;
            Launch.Click += HandleClickLuanchEnvent;
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(607, 387);
            button1.Name = "button1";
            button1.Size = new Size(82, 36);
            button1.TabIndex = 7;
            button1.Text = "HIDE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(LabelTop);
            panel3.Location = new Point(10, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(679, 44);
            panel3.TabIndex = 1;
            // 
            // LabelTop
            // 
            LabelTop.AutoSize = true;
            LabelTop.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTop.Location = new Point(3, 20);
            LabelTop.Name = "LabelTop";
            LabelTop.Size = new Size(169, 28);
            LabelTop.TabIndex = 3;
            LabelTop.Text = "CREATE INVOICE";
            // 
            // InvoiceInsert
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 433);
            Controls.Add(panel3);
            Controls.Add(button1);
            Controls.Add(Launch);
            Controls.Add(TableInvoiceCreate);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "InvoiceInsert";
            Padding = new Padding(6);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InvoiceInsert";
            Load += InvoiceInsert_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel TableInvoiceCreate;
        private Button Launch;
        private Button button1;
        private Panel panel3;
        private Label LabelTop;
        private Label label1;
        private Label label3;
        private Label label2;
        private ComboBox CustomerIDSelection;
        private Label label4;
        private Panel panel11;
        private Panel panel4;
        private Label label5;
        private Panel panel5;
        private Label InvoiceDateValue;
        private Label InvoiceIDValue;
        private Panel panel2;
        private Label label7;
        private ListBox listBoxProductID;
    }
}