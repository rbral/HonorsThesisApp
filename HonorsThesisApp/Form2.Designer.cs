namespace HonorsThesisApp
{
    partial class Form2
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
            comboBox1 = new ComboBox();
            GB_StoreInfo = new GroupBox();
            textBox6 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            TB_StoreName = new TextBox();
            label10 = new Label();
            groupBox1 = new GroupBox();
            button_AddCategory = new Button();
            button_AddItem = new Button();
            button_Submit = new Button();
            label2 = new Label();
            comboBox_Brand = new ComboBox();
            comboBox_ItemName = new ComboBox();
            GB_StoreInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 60);
            label1.Name = "label1";
            label1.Size = new Size(155, 45);
            label1.TabIndex = 0;
            label1.Text = "Category:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(267, 67);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(219, 40);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Select category";
            // 
            // GB_StoreInfo
            // 
            GB_StoreInfo.BackColor = SystemColors.Control;
            GB_StoreInfo.Controls.Add(comboBox_ItemName);
            GB_StoreInfo.Controls.Add(comboBox_Brand);
            GB_StoreInfo.Controls.Add(textBox6);
            GB_StoreInfo.Controls.Add(label7);
            GB_StoreInfo.Controls.Add(label8);
            GB_StoreInfo.Controls.Add(label9);
            GB_StoreInfo.Controls.Add(TB_StoreName);
            GB_StoreInfo.Controls.Add(label10);
            GB_StoreInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GB_StoreInfo.Location = new Point(23, 141);
            GB_StoreInfo.Name = "GB_StoreInfo";
            GB_StoreInfo.Size = new Size(598, 420);
            GB_StoreInfo.TabIndex = 10;
            GB_StoreInfo.TabStop = false;
            GB_StoreInfo.Text = "Item Information:";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(241, 331);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(245, 39);
            textBox6.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 331);
            label7.Name = "label7";
            label7.Size = new Size(70, 32);
            label7.TabIndex = 4;
            label7.Text = "Price:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(25, 250);
            label8.Name = "label8";
            label8.Size = new Size(138, 32);
            label8.TabIndex = 3;
            label8.Text = "Item Name:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(25, 168);
            label9.Name = "label9";
            label9.Size = new Size(81, 32);
            label9.TabIndex = 2;
            label9.Text = "Brand:";
            // 
            // TB_StoreName
            // 
            TB_StoreName.Location = new Point(241, 70);
            TB_StoreName.Name = "TB_StoreName";
            TB_StoreName.Size = new Size(242, 39);
            TB_StoreName.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(25, 76);
            label10.Name = "label10";
            label10.Size = new Size(112, 32);
            label10.TabIndex = 0;
            label10.Text = "Barcode: ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_AddItem);
            groupBox1.Controls.Add(GB_StoreInfo);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(30, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(708, 687);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enter items for this category";
            // 
            // button_AddCategory
            // 
            button_AddCategory.Location = new Point(30, 857);
            button_AddCategory.Name = "button_AddCategory";
            button_AddCategory.Size = new Size(185, 62);
            button_AddCategory.TabIndex = 12;
            button_AddCategory.Text = "Add Category";
            button_AddCategory.UseVisualStyleBackColor = true;
            // 
            // button_AddItem
            // 
            button_AddItem.Location = new Point(23, 597);
            button_AddItem.Name = "button_AddItem";
            button_AddItem.Size = new Size(123, 53);
            button_AddItem.TabIndex = 13;
            button_AddItem.Text = "Add Item";
            button_AddItem.UseVisualStyleBackColor = true;
            // 
            // button_Submit
            // 
            button_Submit.Location = new Point(296, 961);
            button_Submit.Name = "button_Submit";
            button_Submit.Size = new Size(175, 64);
            button_Submit.TabIndex = 13;
            button_Submit.Text = "Submit";
            button_Submit.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(248, 51);
            label2.Name = "label2";
            label2.Size = new Size(291, 50);
            label2.TabIndex = 14;
            label2.Text = "Items Purchased";
            // 
            // comboBox_Brand
            // 
            comboBox_Brand.FormattingEnabled = true;
            comboBox_Brand.Location = new Point(241, 165);
            comboBox_Brand.Name = "comboBox_Brand";
            comboBox_Brand.Size = new Size(242, 40);
            comboBox_Brand.TabIndex = 9;
            // 
            // comboBox_ItemName
            // 
            comboBox_ItemName.FormattingEnabled = true;
            comboBox_ItemName.Location = new Point(241, 250);
            comboBox_ItemName.Name = "comboBox_ItemName";
            comboBox_ItemName.Size = new Size(242, 40);
            comboBox_ItemName.TabIndex = 10;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(827, 1052);
            Controls.Add(label2);
            Controls.Add(button_Submit);
            Controls.Add(button_AddCategory);
            Controls.Add(groupBox1);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            GB_StoreInfo.ResumeLayout(false);
            GB_StoreInfo.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private GroupBox GB_StoreInfo;
        private TextBox textBox6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox TB_StoreName;
        private Label label10;
        private GroupBox groupBox1;
        private Button button_AddCategory;
        private Button button_AddItem;
        private Button button_Submit;
        private Label label2;
        private ComboBox comboBox_ItemName;
        private ComboBox comboBox_Brand;
    }
}