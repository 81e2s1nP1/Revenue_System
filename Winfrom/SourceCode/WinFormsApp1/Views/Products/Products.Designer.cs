﻿namespace WinFormsApp1.Views
{
    partial class Products
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
            label1 = new Label();
            panel2 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            button3 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(931, 78);
            panel1.TabIndex = 0;
            panel1.Paint += pTopProduct;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 55);
            label1.Name = "label1";
            label1.Size = new Size(160, 23);
            label1.TabIndex = 0;
            label1.Text = "PRODUCTS-LIST";
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(12, 487);
            panel2.Name = "panel2";
            panel2.Size = new Size(931, 78);
            panel2.TabIndex = 1;
            panel2.Paint += pBottomProduct;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.Location = new Point(615, 3);
            button2.Name = "button2";
            button2.Size = new Size(155, 47);
            button2.TabIndex = 1;
            button2.Text = "DELETE";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.Location = new Point(776, 3);
            button1.Name = "button1";
            button1.Size = new Size(155, 47);
            button1.TabIndex = 0;
            button1.Text = "Launch";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Location = new Point(12, 96);
            panel3.Name = "panel3";
            panel3.Size = new Size(931, 385);
            panel3.TabIndex = 2;
            panel3.Paint += pMiddleProduct;
            // 
            // button3
            // 
            button3.BackColor = Color.DodgerBlue;
            button3.Location = new Point(454, 3);
            button3.Name = "button3";
            button3.Size = new Size(155, 47);
            button3.TabIndex = 2;
            button3.Text = "UPDATE";
            button3.UseVisualStyleBackColor = false;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(13F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 577);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Showcard Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 3, 5, 3);
            Name = "Products";
            Text = "Products";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}