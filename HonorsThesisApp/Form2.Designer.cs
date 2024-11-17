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
            catagorySelector = new ComboBox();
            GB_StoreInfo = new GroupBox();
            TB_Item = new ComboBox();
            brandSelector = new ComboBox();
            TB_Price = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            TB_Barcode = new TextBox();
            label10 = new Label();
            groupBox1 = new GroupBox();
            button_AddItem = new Button();
            button_AddCategory = new Button();
            button_Submit = new Button();
            label2 = new Label();
            GB_StoreInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 28);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 21);
            label1.TabIndex = 0;
            label1.Text = "Category:";
            // 
            // catagorySelector
            // 
            catagorySelector.FormattingEnabled = true;
            catagorySelector.Location = new Point(144, 31);
            catagorySelector.Margin = new Padding(2, 1, 2, 1);
            catagorySelector.Name = "catagorySelector";
            catagorySelector.Size = new Size(120, 23);
            catagorySelector.TabIndex = 5;
            catagorySelector.Text = "Select category";
            // 
            // GB_StoreInfo
            // 
            GB_StoreInfo.BackColor = SystemColors.Control;
            GB_StoreInfo.Controls.Add(TB_Item);
            GB_StoreInfo.Controls.Add(brandSelector);
            GB_StoreInfo.Controls.Add(TB_Price);
            GB_StoreInfo.Controls.Add(label7);
            GB_StoreInfo.Controls.Add(label8);
            GB_StoreInfo.Controls.Add(label9);
            GB_StoreInfo.Controls.Add(TB_Barcode);
            GB_StoreInfo.Controls.Add(label10);
            GB_StoreInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GB_StoreInfo.Location = new Point(12, 66);
            GB_StoreInfo.Margin = new Padding(2, 1, 2, 1);
            GB_StoreInfo.Name = "GB_StoreInfo";
            GB_StoreInfo.Padding = new Padding(2, 1, 2, 1);
            GB_StoreInfo.Size = new Size(322, 197);
            GB_StoreInfo.TabIndex = 10;
            GB_StoreInfo.TabStop = false;
            GB_StoreInfo.Text = "Item Information:";
            // 
            // TB_Item
            // 
            TB_Item.FormattingEnabled = true;
            TB_Item.Location = new Point(130, 117);
            TB_Item.Margin = new Padding(2, 1, 2, 1);
            TB_Item.Name = "TB_Item";
            TB_Item.Size = new Size(132, 23);
            TB_Item.TabIndex = 10;
            // 
            // brandSelector
            // 
            brandSelector.FormattingEnabled = true;
            brandSelector.Location = new Point(130, 77);
            brandSelector.Margin = new Padding(2, 1, 2, 1);
            brandSelector.Name = "brandSelector";
            brandSelector.Size = new Size(132, 23);
            brandSelector.TabIndex = 9;
            // 
            // TB_Price
            // 
            TB_Price.Location = new Point(130, 155);
            TB_Price.Margin = new Padding(2, 1, 2, 1);
            TB_Price.Name = "TB_Price";
            TB_Price.Size = new Size(134, 23);
            TB_Price.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(13, 155);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 4;
            label7.Text = "Price:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(13, 117);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(69, 15);
            label8.TabIndex = 3;
            label8.Text = "Item Name:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(13, 79);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(41, 15);
            label9.TabIndex = 2;
            label9.Text = "Brand:";
            // 
            // TB_Barcode
            // 
            TB_Barcode.Location = new Point(130, 33);
            TB_Barcode.Margin = new Padding(2, 1, 2, 1);
            TB_Barcode.Name = "TB_Barcode";
            TB_Barcode.Size = new Size(132, 23);
            TB_Barcode.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(13, 36);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(56, 15);
            label10.TabIndex = 0;
            label10.Text = "Barcode: ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_AddItem);
            groupBox1.Controls.Add(GB_StoreInfo);
            groupBox1.Controls.Add(catagorySelector);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(16, 63);
            groupBox1.Margin = new Padding(2, 1, 2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 1, 2, 1);
            groupBox1.Size = new Size(381, 322);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enter items for this category";
            // 
            // button_AddItem
            // 
            button_AddItem.Location = new Point(12, 280);
            button_AddItem.Margin = new Padding(2, 1, 2, 1);
            button_AddItem.Name = "button_AddItem";
            button_AddItem.Size = new Size(66, 25);
            button_AddItem.TabIndex = 13;
            button_AddItem.Text = "Add Item";
            button_AddItem.UseVisualStyleBackColor = true;
            button_AddItem.Click += button_AddItem_Click;
            // 
            // button_AddCategory
            // 
            button_AddCategory.Location = new Point(16, 402);
            button_AddCategory.Margin = new Padding(2, 1, 2, 1);
            button_AddCategory.Name = "button_AddCategory";
            button_AddCategory.Size = new Size(100, 29);
            button_AddCategory.TabIndex = 12;
            button_AddCategory.Text = "Add Category";
            button_AddCategory.UseVisualStyleBackColor = true;
            // 
            // button_Submit
            // 
            button_Submit.Location = new Point(159, 450);
            button_Submit.Margin = new Padding(2, 1, 2, 1);
            button_Submit.Name = "button_Submit";
            button_Submit.Size = new Size(94, 30);
            button_Submit.TabIndex = 13;
            button_Submit.Text = "Submit";
            button_Submit.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(134, 24);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(150, 25);
            label2.TabIndex = 14;
            label2.Text = "Items Purchased";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(445, 455);
            Controls.Add(label2);
            Controls.Add(button_Submit);
            Controls.Add(button_AddCategory);
            Controls.Add(groupBox1);
            Margin = new Padding(2, 1, 2, 1);
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
        private ComboBox catagorySelector;
        private GroupBox GB_StoreInfo;
        private TextBox TB_Price;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox TB_Barcode;
        private Label label10;
        private GroupBox groupBox1;
        private Button button_AddCategory;
        private Button button_AddItem;
        private Button button_Submit;
        private Label label2;
        private ComboBox TB_Item;
        private ComboBox brandSelector;
    }
}