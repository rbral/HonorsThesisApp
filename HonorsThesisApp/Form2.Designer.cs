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
            categorySelector = new ComboBox();
            GB_StoreInfo = new GroupBox();
            TB_NewItemName = new TextBox();
            TB_NewBrandName = new TextBox();
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
            label1.Location = new Point(22, 60);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 45);
            label1.TabIndex = 0;
            label1.Text = "Category:";
            // 
            // categorySelector
            // 
            categorySelector.FormattingEnabled = true;
            categorySelector.Location = new Point(267, 66);
            categorySelector.Margin = new Padding(4, 2, 4, 2);
            categorySelector.Name = "categorySelector";
            categorySelector.Size = new Size(219, 40);
            categorySelector.TabIndex = 5;
            categorySelector.Text = "Select category";
            // 
            // GB_StoreInfo
            // 
            GB_StoreInfo.BackColor = SystemColors.Control;
            GB_StoreInfo.Controls.Add(TB_NewItemName);
            GB_StoreInfo.Controls.Add(TB_NewBrandName);
            GB_StoreInfo.Controls.Add(TB_Item);
            GB_StoreInfo.Controls.Add(brandSelector);
            GB_StoreInfo.Controls.Add(TB_Price);
            GB_StoreInfo.Controls.Add(label7);
            GB_StoreInfo.Controls.Add(label8);
            GB_StoreInfo.Controls.Add(label9);
            GB_StoreInfo.Controls.Add(TB_Barcode);
            GB_StoreInfo.Controls.Add(label10);
            GB_StoreInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GB_StoreInfo.Location = new Point(22, 141);
            GB_StoreInfo.Margin = new Padding(4, 2, 4, 2);
            GB_StoreInfo.Name = "GB_StoreInfo";
            GB_StoreInfo.Padding = new Padding(4, 2, 4, 2);
            GB_StoreInfo.Size = new Size(661, 576);
            GB_StoreInfo.TabIndex = 10;
            GB_StoreInfo.TabStop = false;
            GB_StoreInfo.Text = "Item Information:";
            // 
            // TB_NewItemName
            // 
            TB_NewItemName.Location = new Point(241, 403);
            TB_NewItemName.Margin = new Padding(4, 2, 4, 2);
            TB_NewItemName.Name = "TB_NewItemName";
            TB_NewItemName.Size = new Size(242, 39);
            TB_NewItemName.TabIndex = 17;
            TB_NewItemName.Text = "Enter New Item";
            TB_NewItemName.Visible = false;
            // 
            // TB_NewBrandName
            // 
            TB_NewBrandName.Location = new Point(241, 243);
            TB_NewBrandName.Margin = new Padding(4, 2, 4, 2);
            TB_NewBrandName.Name = "TB_NewBrandName";
            TB_NewBrandName.Size = new Size(242, 39);
            TB_NewBrandName.TabIndex = 16;
            TB_NewBrandName.Text = "Enter New Brand";
            TB_NewBrandName.Visible = false;
            // 
            // TB_Item
            // 
            TB_Item.FormattingEnabled = true;
            TB_Item.Location = new Point(241, 339);
            TB_Item.Margin = new Padding(4, 2, 4, 2);
            TB_Item.Name = "TB_Item";
            TB_Item.Size = new Size(242, 40);
            TB_Item.TabIndex = 10;
            TB_Item.SelectedIndexChanged += TB_Item_SelectedIndexChanged;
            // 
            // brandSelector
            // 
            brandSelector.FormattingEnabled = true;
            brandSelector.Location = new Point(241, 179);
            brandSelector.Margin = new Padding(4, 2, 4, 2);
            brandSelector.Name = "brandSelector";
            brandSelector.Size = new Size(242, 40);
            brandSelector.TabIndex = 9;
            brandSelector.SelectedValueChanged += brandSelector_SelectedIndexChanged;
            // 
            // TB_Price
            // 
            TB_Price.Location = new Point(245, 510);
            TB_Price.Margin = new Padding(4, 2, 4, 2);
            TB_Price.Name = "TB_Price";
            TB_Price.Size = new Size(245, 39);
            TB_Price.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(24, 516);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(70, 32);
            label7.TabIndex = 4;
            label7.Text = "Price:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(26, 339);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(138, 32);
            label8.TabIndex = 3;
            label8.Text = "Item Name:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(24, 181);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(81, 32);
            label9.TabIndex = 2;
            label9.Text = "Brand:";
            // 
            // TB_Barcode
            // 
            TB_Barcode.Location = new Point(241, 70);
            TB_Barcode.Margin = new Padding(4, 2, 4, 2);
            TB_Barcode.Name = "TB_Barcode";
            TB_Barcode.Size = new Size(242, 39);
            TB_Barcode.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(24, 77);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(112, 32);
            label10.TabIndex = 0;
            label10.Text = "Barcode: ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_AddItem);
            groupBox1.Controls.Add(GB_StoreInfo);
            groupBox1.Controls.Add(categorySelector);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(82, 130);
            groupBox1.Margin = new Padding(4, 2, 4, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 2, 4, 2);
            groupBox1.Size = new Size(708, 826);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enter items for this category";
            // 
            // button_AddItem
            // 
            button_AddItem.Location = new Point(22, 751);
            button_AddItem.Margin = new Padding(4, 2, 4, 2);
            button_AddItem.Name = "button_AddItem";
            button_AddItem.Size = new Size(210, 53);
            button_AddItem.TabIndex = 13;
            button_AddItem.Text = "Add Item";
            button_AddItem.UseVisualStyleBackColor = true;
            button_AddItem.Click += button_AddItem_Click;
            // 
            // button_Submit
            // 
            button_Submit.Location = new Point(366, 992);
            button_Submit.Margin = new Padding(4, 2, 4, 2);
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
            label2.Location = new Point(249, 51);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(291, 50);
            label2.TabIndex = 14;
            label2.Text = "Items Purchased";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(904, 1088);
            Controls.Add(label2);
            Controls.Add(button_Submit);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 2, 4, 2);
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
        private ComboBox categorySelector;
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
        private TextBox TB_NewBrandName;
        private Button button_addNewItemName;
        private Button button_addNewBrand;
        private TextBox TB_NewItemName;
        private Button addBrandToDB;
        private Button addItemToDB;
    }
}