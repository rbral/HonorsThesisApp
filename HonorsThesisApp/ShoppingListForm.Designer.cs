namespace HonorsThesisApp
{
    partial class ShoppingListForm
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
            L_StoreChoice = new Label();
            checkedList_Products = new CheckedListBox();
            button_Next = new Button();
            SuspendLayout();
            // 
            // L_StoreChoice
            // 
            L_StoreChoice.AutoSize = true;
            L_StoreChoice.BackColor = SystemColors.Control;
            L_StoreChoice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            L_StoreChoice.Location = new Point(17, 24);
            L_StoreChoice.Margin = new Padding(2, 0, 2, 0);
            L_StoreChoice.MinimumSize = new Size(65, 21);
            L_StoreChoice.Name = "L_StoreChoice";
            L_StoreChoice.Size = new Size(272, 21);
            L_StoreChoice.TabIndex = 9;
            L_StoreChoice.Text = "Select all items you'd like to purchase:";
            L_StoreChoice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkedList_Products
            // 
            checkedList_Products.CheckOnClick = true;
            checkedList_Products.FormattingEnabled = true;
            checkedList_Products.Location = new Point(20, 59);
            checkedList_Products.Margin = new Padding(2, 1, 2, 1);
            checkedList_Products.Name = "checkedList_Products";
            checkedList_Products.Size = new Size(435, 292);
            checkedList_Products.TabIndex = 10;
            checkedList_Products.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // button_Next
            // 
            button_Next.Location = new Point(20, 442);
            button_Next.Margin = new Padding(2, 1, 2, 1);
            button_Next.Name = "button_Next";
            button_Next.Size = new Size(81, 22);
            button_Next.TabIndex = 11;
            button_Next.Text = "Next";
            button_Next.UseVisualStyleBackColor = true;
            button_Next.Click += button_Next_Click;
            // 
            // ShoppingListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(523, 488);
            Controls.Add(button_Next);
            Controls.Add(checkedList_Products);
            Controls.Add(L_StoreChoice);
            Margin = new Padding(2, 1, 2, 1);
            Name = "ShoppingListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShoppingListForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label L_StoreChoice;
        private CheckedListBox checkedList_Products;
        private Button button_Next;
    }
}