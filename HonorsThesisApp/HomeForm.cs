using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HonorsThesisApp
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void button_ReceiptUpload_Click(object sender, EventArgs e)
        {
            ReceiptForm1 receiptForm1 = new ReceiptForm1(); // Create an instance of the new form
            receiptForm1.Show();              // Show the new form
            this.Hide();                 // Optionally hide the current form
        }

        private void button_ShoppingList_Click(object sender, EventArgs e)
        {
            ShoppingForm shoppingForm = new ShoppingForm();
            shoppingForm.Show();
            this.Hide();
        }
    }
}
