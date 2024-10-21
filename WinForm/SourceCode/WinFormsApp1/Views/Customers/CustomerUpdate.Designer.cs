namespace WinFormsApp1.Views.Customers
{
    partial class CustomerUpdate
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
            LTitleForm = new Label();
            Ptextbox = new Panel();
            textBoxCusIDUpdate = new TextBox();
            label4 = new Label();
            label3 = new Label();
            textBoxCusPhoneUpdate = new TextBox();
            textBoxCusNameUpdate = new TextBox();
            UPDATE = new Button();
            HideUpdt = new Button();
            Ptextbox.SuspendLayout();
            SuspendLayout();
            // 
            // LTitleForm
            // 
            LTitleForm.AutoSize = true;
            LTitleForm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LTitleForm.ForeColor = Color.Black;
            LTitleForm.Location = new Point(17, 57);
            LTitleForm.Name = "LTitleForm";
            LTitleForm.Size = new Size(201, 28);
            LTitleForm.TabIndex = 0;
            LTitleForm.Text = "UPDATE CUSTOMER";
            // 
            // Ptextbox
            // 
            Ptextbox.BackColor = Color.DodgerBlue;
            Ptextbox.Controls.Add(textBoxCusIDUpdate);
            Ptextbox.Controls.Add(label4);
            Ptextbox.Controls.Add(label3);
            Ptextbox.Controls.Add(textBoxCusPhoneUpdate);
            Ptextbox.Controls.Add(textBoxCusNameUpdate);
            Ptextbox.Location = new Point(17, 99);
            Ptextbox.Name = "Ptextbox";
            Ptextbox.Size = new Size(312, 173);
            Ptextbox.TabIndex = 1;
            // 
            // textBoxCusIDUpdate
            // 
            textBoxCusIDUpdate.Location = new Point(12, 3);
            textBoxCusIDUpdate.Name = "textBoxCusIDUpdate";
            textBoxCusIDUpdate.Size = new Size(125, 27);
            textBoxCusIDUpdate.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
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
            label3.ForeColor = Color.Black;
            label3.Location = new Point(12, 26);
            label3.Name = "label3";
            label3.Size = new Size(144, 23);
            label3.TabIndex = 6;
            label3.Text = "Customer Name:";
            // 
            // textBoxCusPhoneUpdate
            // 
            textBoxCusPhoneUpdate.Location = new Point(12, 122);
            textBoxCusPhoneUpdate.Name = "textBoxCusPhoneUpdate";
            textBoxCusPhoneUpdate.Size = new Size(282, 27);
            textBoxCusPhoneUpdate.TabIndex = 5;
            // 
            // textBoxCusNameUpdate
            // 
            textBoxCusNameUpdate.Location = new Point(12, 52);
            textBoxCusNameUpdate.Name = "textBoxCusNameUpdate";
            textBoxCusNameUpdate.Size = new Size(282, 27);
            textBoxCusNameUpdate.TabIndex = 4;
            // 
            // UPDATE
            // 
            UPDATE.BackColor = Color.DodgerBlue;
            UPDATE.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UPDATE.ForeColor = Color.Black;
            UPDATE.Location = new Point(136, 292);
            UPDATE.Name = "UPDATE";
            UPDATE.Size = new Size(94, 42);
            UPDATE.TabIndex = 3;
            UPDATE.Text = "UPDATE";
            UPDATE.UseVisualStyleBackColor = false;
            UPDATE.Click += UPDATE_Click;
            // 
            // HideUpdt
            // 
            HideUpdt.BackColor = Color.DodgerBlue;
            HideUpdt.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HideUpdt.ForeColor = Color.Black;
            HideUpdt.Location = new Point(235, 292);
            HideUpdt.Name = "HideUpdt";
            HideUpdt.Size = new Size(94, 42);
            HideUpdt.TabIndex = 4;
            HideUpdt.Text = "HIDE";
            HideUpdt.UseVisualStyleBackColor = false;
            HideUpdt.Click += HideUpdt_Click;
            // 
            // CustomerUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(346, 355);
            Controls.Add(HideUpdt);
            Controls.Add(UPDATE);
            Controls.Add(Ptextbox);
            Controls.Add(LTitleForm);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "CustomerUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Ptextbox.ResumeLayout(false);
            Ptextbox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LTitleForm;
        private Panel Ptextbox;
        private Label label4;
        private Label label3;
        private TextBox textBoxCusPhoneUpdate;
        private TextBox textBoxCusNameUpdate;
        private Button UPDATE;
        private Button HideUpdt;
        private TextBox textBoxCusIDUpdate;
    }
}
