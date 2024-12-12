/*namespace HonorsThesisApp
{
    partial class HomeForm
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "HomeForm";
        }

        #endregion
    }
}*/


// --------
namespace HonorsThesisApp
{
    partial class HomeForm
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
            L_Home_Title = new Label();
            button_ReceiptUpload = new Button();
            groupBox1 = new GroupBox();
            button_Settings = new Button();
            button_ShoppingList = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // L_Home_Title
            // 
            L_Home_Title.AutoSize = true;
            L_Home_Title.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            L_Home_Title.Location = new Point(264, 81);
            L_Home_Title.Margin = new Padding(4, 0, 4, 0);
            L_Home_Title.Name = "L_Home_Title";
            L_Home_Title.Size = new Size(288, 59);
            L_Home_Title.TabIndex = 4;
            L_Home_Title.Text = "ShopAI Home";
            L_Home_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_ReceiptUpload
            // 
            button_ReceiptUpload.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_ReceiptUpload.Location = new Point(104, 86);
            button_ReceiptUpload.Name = "button_ReceiptUpload";
            button_ReceiptUpload.Size = new Size(305, 128);
            button_ReceiptUpload.TabIndex = 5;
            button_ReceiptUpload.Text = "Receipt Upload";
            button_ReceiptUpload.UseVisualStyleBackColor = true;
            button_ReceiptUpload.Click += button_ReceiptUpload_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(button_Settings);
            groupBox1.Controls.Add(button_ShoppingList);
            groupBox1.Controls.Add(button_ReceiptUpload);
            groupBox1.Location = new Point(143, 203);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(534, 637);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Table of Contents";
            // 
            // button_Settings
            // 
            button_Settings.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Settings.Location = new Point(104, 431);
            button_Settings.Name = "button_Settings";
            button_Settings.Size = new Size(305, 128);
            button_Settings.TabIndex = 7;
            button_Settings.Text = "Settings";
            button_Settings.UseVisualStyleBackColor = true;
            // 
            // button_ShoppingList
            // 
            button_ShoppingList.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_ShoppingList.Location = new Point(104, 256);
            button_ShoppingList.Name = "button_ShoppingList";
            button_ShoppingList.Size = new Size(305, 128);
            button_ShoppingList.TabIndex = 6;
            button_ShoppingList.Text = "Shopping List";
            button_ShoppingList.UseVisualStyleBackColor = true;
            button_ShoppingList.Click += button_ShoppingList_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(878, 1043);
            Controls.Add(groupBox1);
            Controls.Add(L_Home_Title);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeForm";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label L_Home_Title;
        private Button button_ReceiptUpload;
        private GroupBox groupBox1;
        private Button button_Settings;
        private Button button_ShoppingList;
    }
}