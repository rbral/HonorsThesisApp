using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HonorsThesisApp
{
    public partial class ShoppingListForm : Form
    {
        public ShoppingListForm()
        {
            InitializeComponent();
            LoadCheckedListProducts();

        }

        private String connString = "Data Source=RIVKALAPTOP\\SQLEXPRESS01;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";
        //private String connString = "Data Source=labB119ZD\\SQLEXPRESS;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";

        private void LoadCheckedListProducts()
        {
            string query = "SELECT product_name FROM Products";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                checkedList_Products.Items.Add(reader[0].ToString());

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }

            }
        }

        


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            StoreForm form = new StoreForm();
            form.Show();
            this.Hide();
        }
    }
}
