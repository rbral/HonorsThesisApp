namespace HonorsThesisApp
{
    partial class StoreForm
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
            groupBox_StoreChoice = new GroupBox();
            CheckedList_Stores = new CheckedListBox();
            button_CalculatePrices = new Button();
            groupBox_StoreChoice.SuspendLayout();
            SuspendLayout();
            // 
            // L_StoreChoice
            // 
            L_StoreChoice.AutoSize = true;
            L_StoreChoice.BackColor = SystemColors.Control;
            L_StoreChoice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            L_StoreChoice.Location = new Point(51, 61);
            L_StoreChoice.Margin = new Padding(4, 0, 4, 0);
            L_StoreChoice.MinimumSize = new Size(121, 45);
            L_StoreChoice.Name = "L_StoreChoice";
            L_StoreChoice.Size = new Size(586, 45);
            L_StoreChoice.TabIndex = 8;
            L_StoreChoice.Text = "Which stores would you like to shop in?";
            L_StoreChoice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox_StoreChoice
            // 
            groupBox_StoreChoice.Controls.Add(CheckedList_Stores);
            groupBox_StoreChoice.Location = new Point(50, 136);
            groupBox_StoreChoice.Name = "groupBox_StoreChoice";
            groupBox_StoreChoice.Size = new Size(587, 400);
            groupBox_StoreChoice.TabIndex = 9;
            groupBox_StoreChoice.TabStop = false;
            groupBox_StoreChoice.Text = "Select all that apply";
            // 
            // CheckedList_Stores
            // 
            CheckedList_Stores.CheckOnClick = true;
            CheckedList_Stores.FormattingEnabled = true;
            CheckedList_Stores.Location = new Point(69, 94);
            CheckedList_Stores.Name = "CheckedList_Stores";
            CheckedList_Stores.Size = new Size(438, 256);
            CheckedList_Stores.TabIndex = 0;
            CheckedList_Stores.SelectedIndexChanged += CheckedList_Stores_SelectedIndexChanged;
            // 
            // button_CalculatePrices
            // 
            button_CalculatePrices.Location = new Point(50, 628);
            button_CalculatePrices.Margin = new Padding(4, 2, 4, 2);
            button_CalculatePrices.Name = "button_CalculatePrices";
            button_CalculatePrices.Size = new Size(251, 64);
            button_CalculatePrices.TabIndex = 12;
            button_CalculatePrices.Text = "Find Cheap Prices!";
            button_CalculatePrices.UseVisualStyleBackColor = true;
            button_CalculatePrices.Click += this.button_CalculatePrices_Click;
            // 
            // StoreForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(878, 1043);
            Controls.Add(button_CalculatePrices);
            Controls.Add(groupBox_StoreChoice);
            Controls.Add(L_StoreChoice);
            Name = "StoreForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShoppingForm";
            groupBox_StoreChoice.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label L_StoreChoice;
        private GroupBox groupBox_StoreChoice;
        private CheckedListBox CheckedList_Stores;
        private Button button_CalculatePrices;
    }
}
