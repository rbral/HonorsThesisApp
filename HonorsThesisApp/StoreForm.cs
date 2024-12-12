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
    public partial class StoreForm : Form
    {
        public StoreForm()
        {
            InitializeComponent();
            LoadCheckedListStores();
        }

        private String connString = "Data Source=RIVKALAPTOP\\SQLEXPRESS01;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";
        //private String connString = "Data Source=labB119ZD\\SQLEXPRESS;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";


        private void LoadCheckedListStores()
        {
            string query = "SELECT store_name FROM Stores";

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
                                CheckedList_Stores.Items.Add(reader[0].ToString());

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

        private void CheckedList_Stores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_CalculatePrices_Click(object sender, EventArgs e)
        {
            // Collect selected store names into a list
            List<string> selectedStores = new List<string>();

            foreach (var item in CheckedList_Stores.CheckedItems)
            {
                selectedStores.Add(item.ToString());
            }

            PriceResultsForm form = new PriceResultsForm(selectedStores);
            form.Show();
            this.Hide();
        }
    }
}
