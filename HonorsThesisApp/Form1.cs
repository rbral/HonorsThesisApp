using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;



namespace HonorsThesisApp
{
    public partial class Form1 : Form
    {
        private static String strServer = ConfigurationManager.AppSettings["server"];
        private static String strDatabase = ConfigurationManager.AppSettings["database"];
        private String strConnect = $"Server={strServer};Database={strDatabase};TrustServerCertificate=True;";

        private String connString = "Data Source=RIVKALAPTOP\\SQLEXPRESS01;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";

        //private String connString = "Data Source=labB119ZD\\SQLEXPRESS;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";
        public Form1()
        {
            InitializeComponent();
            LoadStores();
            dateTimePicker1.Value = DateTime.Now;
        }

        //get store Id
        private int GetStoreId()
        {
            string query = "SELECT store_id FROM Stores WHERE store_name = @currStore";
            int storeId = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@currSTore", storeSelector.SelectedItem);
                        try
                        {
                            var result = command.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                storeId = Convert.ToInt32(result);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }

                    }
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
               
                   
                }
                return storeId;

            }
 

        //creates a new Form 2 when the user clicks Next
        private void button_Next_Click(object sender, EventArgs e)
        {


            int storeID = GetStoreId();
            DateTime date = dateTimePicker1.Value;
            if (storeID != 0)
            {
                Form2 newForm = new Form2(storeID, date); // Create an instance of the new form
                newForm.Show();              // Show the new form
                this.Hide();                 // Optionally hide the current form
            }
            else
            {
                MessageBox.Show("Error. No valid store selected");
            }
        }

      

        //not sure what this does or if we need this
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 

        }

        //load the stores into the selector
        private void LoadStores()
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

        
        //add a store & clear the field
        private void addStoreButton_Click(object sender, EventArgs e)
        {
            storeSelector.Items.Clear();
            AddStore();
            TB_Address.Clear();
            TB_City.Clear();
            TB_State.Clear();
            TB_Zip.Clear();
            TB_StoreName.Clear();
            LoadStores();
        }
        private void AddStore()
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
    }
}
