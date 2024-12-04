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
            dateTimePicker1.Value = DateTime.Now;
            LoadItemNames();
        }

        private void L_Receipt_Title_Click(object sender, EventArgs e)
        {

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



        private void LoadItemNames()
        {
            String query = "SELECT brand_name FROM Brand";
            SqlConnection sqlCon;
            try
            {
                sqlCon = new SqlConnection(connString);
                sqlCon.Open();
                SqlCommand command = new SqlCommand(query, sqlCon);
                SqlDataReader reader = command.ExecuteReader();

                // Populate ComboBox with data from the database
                List<String> brandList = new List<String>();
                while (reader.Read())
                {
                    //  comboBox_Brand.Items.Add(reader["BrandName"].ToString());
                    //  brandList.Add(reader.GetString(1));
                    //  Console.WriteLine(reader["brand_name"].ToString());
                    brandList.Add(reader["brand_name"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
