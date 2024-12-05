using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using Microsoft.Data.SqlClient;



namespace HonorsThesisApp
{
    public partial class Form1 : Form
    {
        private static String strServer = ConfigurationManager.AppSettings["server"];
        private static String strDatabase = ConfigurationManager.AppSettings["database"];
        private String strConnect = $"Server={strServer};Database={strDatabase};TrustServerCertificate=True;";

        //   private String connString = "Data Source=RIVKALAPTOP\\SQLEXPRESS01;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";

        private String connString = "Data Source=labB119ZD\\SQLEXPRESS;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";
        public Form1()
        {
            InitializeComponent();
            loadStores();
            dateTimePicker1.Value = DateTime.Now;
        }


        //creates a new Form 2 when the user clicks Next
        private void button_Next_Click(object sender, EventArgs e)
        {
            addStore(); //this should only happen if the user doesn't select a store

            int storeID = 0; //replace with actual store id

            Form2 newForm = new Form2(storeID); // Create an instance of the new form
            newForm.Show();              // Show the new form
            this.Hide();                 // Optionally hide the current form
        }

        //add a store

        private void addStore()
        {
            string sql = "INSERT INTO Stores (store_name, address, city, state, postal_code, country) " +
             "VALUES (@store, @staddress, @city, @state, @zip, 'USA')";

            // Create the connection (and be sure to dispose it at the end)
            using (SqlConnection cnn = new SqlConnection(connString))
            {

                try
                {
                    // open the connection & prepare the command
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@store", TB_StoreName.Text);
                        cmd.Parameters.AddWithValue("@staddress", TB_Address.Text);
                        cmd.Parameters.AddWithValue("@city", TB_City.Text);
                        cmd.Parameters.AddWithValue("@state", TB_State.Text);
                        cmd.Parameters.AddWithValue("@zip", TB_Zip.Text);

                        //execute the query
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            MessageBox.Show("Row successfully inserted!");
                        else
                            MessageBox.Show("No row inserted");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void loadStores()
        {
            string query = "SELECT store_name FROM Stores";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        String selectedStore = "";
                        if (storeSelector.SelectedItem != null)
                        {
                            selectedStore = storeSelector.SelectedItem.ToString();
                        }
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                storeSelector.Items.Add(reader[0].ToString());

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

        private void addStoreButton_Click(object sender, EventArgs e)
        {
            storeSelector.Items.Clear();
            addStore();
            TB_Address.Clear();
            TB_City.Clear();
            TB_State.Clear();
            TB_Zip.Clear();
            TB_StoreName.Clear();
            loadStores();
        }
    }
}
