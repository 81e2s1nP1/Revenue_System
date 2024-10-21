namespace WinFormsApp1.Views.Products
{
    partial class ProductUpdate
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
            LTitleForm = new Label();
            Ptextbox = new Panel();
            textBoxProIDUpdate = new TextBox();
            label4 = new Label();
            label3 = new Label();
            textBoxProductPriceUpdate = new TextBox();
            textBoxProductNameUpdate = new TextBox();
            HideUpdt = new Button();
            UPDATE = new Button();
            Ptextbox.SuspendLayout();
            SuspendLayout();
            // 
            // LTitleForm
            // 
            LTitleForm.AutoSize = true;
            LTitleForm.BackColor = Color.Azure;
            LTitleForm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LTitleForm.ForeColor = Color.Black;
            LTitleForm.Location = new Point(17, 57);
            LTitleForm.Name = "LTitleForm";
            LTitleForm.Size = new Size(188, 28);
            LTitleForm.TabIndex = 1;
            LTitleForm.Text = "UPDATE PRODUCT";
            // 
            // Ptextbox
            // 
            Ptextbox.BackColor = Color.DodgerBlue;
            Ptextbox.Controls.Add(textBoxProIDUpdate);
            Ptextbox.Controls.Add(label4);
            Ptextbox.Controls.Add(label3);
            Ptextbox.Controls.Add(textBoxProductPriceUpdate);
            Ptextbox.Controls.Add(textBoxProductNameUpdate);
            Ptextbox.Location = new Point(17, 99);
            Ptextbox.Name = "Ptextbox";
            Ptextbox.Size = new Size(312, 173);
            Ptextbox.TabIndex = 2;
            // 
            // textBoxProIDUpdate
            // 
            textBoxProIDUpdate.Location = new Point(12, 3);
            textBoxProIDUpdate.Name = "textBoxProIDUpdate";
            textBoxProIDUpdate.Size = new Size(125, 27);
            textBoxProIDUpdate.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(12, 96);
            label4.Name = "label4";
            label4.Size = new Size(108, 23);
            label4.TabIndex = 7;
            label4.Text = "Price (VND):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(12, 26);
            label3.Name = "label3";
            label3.Size = new Size(130, 23);
            label3.TabIndex = 6;
            label3.Text = "Product Name:";
            // 
            // textBoxProductPriceUpdate
            // 
            textBoxProductPriceUpdate.Location = new Point(12, 122);
            textBoxProductPriceUpdate.Name = "textBoxProductPriceUpdate";
            textBoxProductPriceUpdate.Size = new Size(282, 27);
            textBoxProductPriceUpdate.TabIndex = 5;
            // 
            // textBoxProductNameUpdate
            // 
            textBoxProductNameUpdate.Location = new Point(12, 52);
            textBoxProductNameUpdate.Name = "textBoxProductNameUpdate";
            textBoxProductNameUpdate.Size = new Size(282, 27);
            textBoxProductNameUpdate.TabIndex = 4;
            // 
            // HideUpdt
            // 
            HideUpdt.BackColor = Color.DodgerBlue;
            HideUpdt.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HideUpdt.ForeColor = Color.Black;
            HideUpdt.Location = new Point(235, 292);
            HideUpdt.Name = "HideUpdt";
            HideUpdt.Size = new Size(94, 42);
            HideUpdt.TabIndex = 5;
            HideUpdt.Text = "HIDE";
            HideUpdt.UseVisualStyleBackColor = false;
            HideUpdt.Click += HideUpdt_Click;
            // 
            // UPDATE
            // 
            UPDATE.BackColor = Color.DodgerBlue;
            UPDATE.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UPDATE.ForeColor = Color.Black;
            UPDATE.Location = new Point(135, 292);
            UPDATE.Name = "UPDATE";
            UPDATE.Size = new Size(94, 42);
            UPDATE.TabIndex = 6;
            UPDATE.Text = "UPDATE";
            UPDATE.UseVisualStyleBackColor = false;
            UPDATE.Click += UPDATE_Click;
            // 
            // ProductUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(346, 355);
            Controls.Add(UPDATE);
            Controls.Add(HideUpdt);
            Controls.Add(Ptextbox);
            Controls.Add(LTitleForm);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "ProductUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProductUpdate";
            Load += ProductUpdate_Load;
            Ptextbox.ResumeLayout(false);
            Ptextbox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LTitleForm;
        private Panel Ptextbox;
        private TextBox textBoxProIDUpdate;
        private Label label4;
        private Label label3;
        private TextBox textBoxProductPriceUpdate;
        private TextBox textBoxProductNameUpdate;
        private Button HideUpdt;
        private Button UPDATE;
    }
}