using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;



namespace HonorsThesisApp
{
    public partial class Form1 : Form
    {
        private static String strServer = ConfigurationManager.AppSettings["server"];
        private static String strDatabase = ConfigurationManager.AppSettings["database"];
        private String connString = "Data Source=RIVKALAPTOP\\SQLEXPRESS01;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";
        //private String connString = "Data Source=labB119ZD\\SQLEXPRESS;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";
        public Form1()
        {
            InitializeComponent();
            LoadStores();
            dateTimePicker1.Value = DateTime.Now;
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
                    storeSelector.Items.Add("Add New Store");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }

            }
        }
        private void AddStore()
        {
            if (TB_StoreName.TextLength == 0 || TB_Address.TextLength == 0 || TB_City.TextLength == 0
                || TB_State.TextLength == 0 || TB_Zip.TextLength == 0)
            {
                MessageBox.Show("Error: Fields are missing. Fill in all fields before adding a store");
            }
            else
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
                                MessageBox.Show("Added Store Successfully");
                            else
                                MessageBox.Show("Store could not be added");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR:" + ex.Message);
                    }
                }
            }
        }


        //creates a new Form 2 when the user clicks Next
        private void button_Next_Click(object sender, EventArgs e)
        {
            if (storeSelector.SelectedItem == "Add New Store")
            {
                AddStore();
            }
            GetIds helperClass = new GetIds();
            int storeID = helperClass.GetStoreId(storeSelector.SelectedItem, TB_StoreName.Text);
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



        

    
    }
}
