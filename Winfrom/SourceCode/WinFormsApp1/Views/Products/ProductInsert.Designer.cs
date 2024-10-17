namespace WinFormsApp1.Views.Products
{
    partial class ProductInsert
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
            LabelTop = new Label();
            panel1 = new Panel();
            lProductPrice = new Label();
            lProductName = new Label();
            textBoxPrice = new TextBox();
            textBoxProductName = new TextBox();
            Hide = new Button();
            Launch = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // LabelTop
            // 
            LabelTop.AutoSize = true;
            LabelTop.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTop.Location = new Point(17, 57);
            LabelTop.Name = "LabelTop";
            LabelTop.Size = new Size(183, 28);
            LabelTop.TabIndex = 2;
            LabelTop.Text = "CREATE PRODUCT";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DodgerBlue;
            panel1.Controls.Add(lProductPrice);
            panel1.Controls.Add(lProductName);
            panel1.Controls.Add(textBoxPrice);
            panel1.Controls.Add(textBoxProductName);
            panel1.Location = new Point(17, 91);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 173);
            panel1.TabIndex = 3;
            // 
            // lProductPrice
            // 
            lProductPrice.AutoSize = true;
            lProductPrice.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lProductPrice.Location = new Point(12, 96);
            lProductPrice.Name = "lProductPrice";
            lProductPrice.Size = new Size(54, 23);
            lProductPrice.TabIndex = 7;
            lProductPrice.Text = "Price:";
            // 
            // lProductName
            // 
            lProductName.AutoSize = true;
            lProductName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lProductName.Location = new Point(12, 26);
            lProductName.Name = "lProductName";
            lProductName.Size = new Size(130, 23);
            lProductName.TabIndex = 6;
            lProductName.Text = "Product Name:";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(12, 122);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(282, 27);
            textBoxPrice.TabIndex = 5;
            // 
            // textBoxProductName
            // 
            textBoxProductName.Location = new Point(12, 52);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(282, 27);
            textBoxProductName.TabIndex = 4;
            // 
            // Hide
            // 
            Hide.BackColor = Color.DodgerBlue;
            Hide.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Hide.Location = new Point(235, 296);
            Hide.Name = "Hide";
            Hide.Size = new Size(94, 42);
            Hide.TabIndex = 4;
            Hide.Text = "HIDE";
            Hide.UseVisualStyleBackColor = false;
            Hide.Click += Hide_Click;
            // 
            // Launch
            // 
            Launch.BackColor = Color.DodgerBlue;
            Launch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Launch.Location = new Point(135, 296);
            Launch.Name = "Launch";
            Launch.Size = new Size(94, 42);
            Launch.TabIndex = 5;
            Launch.Text = "LAUNCH";
            Launch.UseVisualStyleBackColor = false;
            Launch.Click += Launch_Click;
            // 
            // ProductInsert
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(346, 355);
            Controls.Add(Launch);
            Controls.Add(Hide);
            Controls.Add(panel1);
            Controls.Add(LabelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductInsert";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelTop;
        private Panel panel1;
        private Label lProductPrice;
        private Label lProductName;
        private TextBox textBoxPrice;
        private TextBox textBoxProductName;
        private new Button Hide;
        private Button Launch;
    }
}