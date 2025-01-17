﻿namespace WinFormsApp1.Views
{
    partial class InvoiceList
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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            InvoiceTable = new Panel();
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
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 55);
            label1.Name = "label1";
            label1.Size = new Size(153, 24);
            label1.TabIndex = 0;
            label1.Text = "INVOICES-LIST";
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
            // 
            // button3
            // 
            button3.BackColor = Color.DodgerBlue;
            button3.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(452, 0);
            button3.Name = "button3";
            button3.Size = new Size(155, 47);
            button3.TabIndex = 2;
            button3.Text = "UPDATE";
            button3.UseVisualStyleBackColor = false;
            button3.Click += handleClickUpdate;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(613, 0);
            button2.Name = "button2";
            button2.Size = new Size(155, 47);
            button2.TabIndex = 1;
            button2.Text = "DELETE";
            button2.UseVisualStyleBackColor = false;
            button2.Click += handleClickBtnDelete;
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(774, 0);
            button1.Name = "button1";
            button1.Size = new Size(154, 47);
            button1.TabIndex = 0;
            button1.Text = "LAUNCH";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // InvoiceTable
            // 
            InvoiceTable.Font = new Font("Arial", 9F, FontStyle.Bold);
            InvoiceTable.Location = new Point(12, 96);
            InvoiceTable.Name = "InvoiceTable";
            InvoiceTable.Size = new Size(931, 385);
            InvoiceTable.TabIndex = 1;
            InvoiceTable.Paint += pMiddleInvoice;
            // 
            // InvoiceList
            // 
            AutoScaleDimensions = new SizeF(13F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 577);
            Controls.Add(InvoiceTable);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Showcard Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(5, 3, 5, 3);
            Name = "InvoiceList";
            Text = "Invoices";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel InvoiceTable;
    }
}