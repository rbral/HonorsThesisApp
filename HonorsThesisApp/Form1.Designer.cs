﻿namespace HonorsThesisApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dateTimePicker1 = new DateTimePicker();
            L_Receipt_Title = new Label();
            L_Date = new Label();
            GB_StoreInfo = new GroupBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            TB_StoreName = new TextBox();
            label1 = new Label();
            button_Next = new Button();
            GB_StoreInfo.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(366, 232);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(324, 39);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.Value = new DateTime(2024, 11, 3, 19, 40, 6, 0);
            // 
            // L_Receipt_Title
            // 
            L_Receipt_Title.AutoSize = true;
            L_Receipt_Title.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            L_Receipt_Title.Location = new Point(239, 89);
            L_Receipt_Title.Name = "L_Receipt_Title";
            L_Receipt_Title.Size = new Size(313, 59);
            L_Receipt_Title.TabIndex = 3;
            L_Receipt_Title.Text = "Receipt Upload";
            L_Receipt_Title.TextAlign = ContentAlignment.MiddleCenter;
            L_Receipt_Title.Click += L_Receipt_Title_Click;
            // 
            // L_Date
            // 
            L_Date.AutoSize = true;
            L_Date.BackColor = SystemColors.Control;
            L_Date.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            L_Date.Location = new Point(92, 226);
            L_Date.Name = "L_Date";
            L_Date.Size = new Size(268, 45);
            L_Date.TabIndex = 4;
            L_Date.Text = "Date of purchase:";
            L_Date.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // GB_StoreInfo
            // 
            GB_StoreInfo.BackColor = SystemColors.Control;
            GB_StoreInfo.Controls.Add(textBox4);
            GB_StoreInfo.Controls.Add(textBox3);
            GB_StoreInfo.Controls.Add(textBox2);
            GB_StoreInfo.Controls.Add(textBox1);
            GB_StoreInfo.Controls.Add(label5);
            GB_StoreInfo.Controls.Add(label4);
            GB_StoreInfo.Controls.Add(label3);
            GB_StoreInfo.Controls.Add(label2);
            GB_StoreInfo.Controls.Add(TB_StoreName);
            GB_StoreInfo.Controls.Add(label1);
            GB_StoreInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GB_StoreInfo.Location = new Point(92, 340);
            GB_StoreInfo.Name = "GB_StoreInfo";
            GB_StoreInfo.Size = new Size(598, 568);
            GB_StoreInfo.TabIndex = 5;
            GB_StoreInfo.TabStop = false;
            GB_StoreInfo.Text = "Store Info:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(241, 420);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(207, 50);
            textBox4.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(241, 331);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(207, 50);
            textBox3.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(241, 250);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(207, 50);
            textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(241, 165);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 50);
            textBox1.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 410);
            label5.Name = "label5";
            label5.Size = new Size(112, 32);
            label5.TabIndex = 5;
            label5.Text = "Zip code:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 331);
            label4.Name = "label4";
            label4.Size = new Size(72, 32);
            label4.TabIndex = 4;
            label4.Text = "State:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 250);
            label3.Name = "label3";
            label3.Size = new Size(60, 32);
            label3.TabIndex = 3;
            label3.Text = "City:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 168);
            label2.Name = "label2";
            label2.Size = new Size(103, 32);
            label2.TabIndex = 2;
            label2.Text = "Address:";
            // 
            // TB_StoreName
            // 
            TB_StoreName.Location = new Point(241, 70);
            TB_StoreName.Name = "TB_StoreName";
            TB_StoreName.Size = new Size(207, 50);
            TB_StoreName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 76);
            label1.Name = "label1";
            label1.Size = new Size(141, 32);
            label1.TabIndex = 0;
            label1.Text = "Store name:";
            // 
            // button_Next
            // 
            button_Next.Location = new Point(335, 961);
            button_Next.Name = "button_Next";
            button_Next.Size = new Size(150, 46);
            button_Next.TabIndex = 6;
            button_Next.Text = "Next";
            button_Next.UseVisualStyleBackColor = true;
            button_Next.Click += button_Next_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(827, 1052);
            Controls.Add(button_Next);
            Controls.Add(GB_StoreInfo);
            Controls.Add(L_Date);
            Controls.Add(L_Receipt_Title);
            Controls.Add(dateTimePicker1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            GB_StoreInfo.ResumeLayout(false);
            GB_StoreInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dateTimePicker1;
        private Label L_Receipt_Title;
        private Label L_Date;
        private GroupBox GB_StoreInfo;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox TB_StoreName;
        private Label label1;
        private TextBox textBox4;
        private TextBox textBox3;
        private Button button_Next;
    }
}
