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
            Form1 form = new Form1(); // Create an instance of the new form
            form.Show();              // Show the new form
            this.Hide();                 // Optionally hide the current form
        }

        private void button_ShoppingList_Click(object sender, EventArgs e)
        {
            ShoppingListForm form = new ShoppingListForm();
            form.Show();
            this.Hide();
        }
    }
}
