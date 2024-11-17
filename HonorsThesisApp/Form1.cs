using System;
using Microsoft.Data.SqlClient;



namespace HonorsThesisApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            //LoadItemNames();
        }

        private void L_Receipt_Title_Click(object sender, EventArgs e)
        {

        }

        private void button_Next_Click(object sender, EventArgs e)
        {
          //  savePageInformation();
            Form2 newForm = new Form2(); // Create an instance of the new form
            newForm.Show();              // Show the new form
            this.Hide();                 // Optionally hide the current form
        }

        private void savePageInformation()
        {     
            // replace with correct connection string
            String connectionString = "Data Source=UMAIR;Initial Catalog=Air; Trusted_Connection=True;";

            // replace with actual sql statement using correct parameters
            String sql = "insert into Main ([Firt Name], [Last Name]) values(@first,@last)";

            // Create the connection (and be sure to dispose it at the end)
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {

                try
                {
                    // Open the connection to the database. 
                    // This is the first critical step in the process.
                    // If we cannot reach the db then we have connectivity problems
                    cnn.Open();

                    // Prepare the command to be executed on the db
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        // Create and set the parameters values 
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                        // have enum here to pass in storeid possibly?? 
                        cmd.Parameters.AddWithValue("@store", TB_StoreName.Text);
                        cmd.Parameters.AddWithValue("@staddress", TB_Address.Text);
                        cmd.Parameters.AddWithValue("@city", TB_City.Text);
                        cmd.Parameters.AddWithValue("@state", TB_State.Text);
                        cmd.Parameters.AddWithValue("@zip", TB_Zip.Text);

                        // Let's ask the db to execute the query
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            MessageBox.Show("Row inserted!!");
                        else
                            // Well this should never really happen
                            MessageBox.Show("No row inserted");

                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            } 
        }

    

        /*private void LoadItemNames()
        {
            //TODO: replace with actual server and database names and query
            var server = "RIVKALAPTOP\\SQLEXPRESS01";
            var database = "Store"; 
            String strConnect = $"Server={server};Database={database};Trusted_Connection=True;";
            String query = "SELECT BrandName FROM Brand"; 
            SqlConnection sqlCon;
            try
            {
                sqlCon = new SqlConnection(strConnect);
                sqlCon.Open();
                SqlCommand command = new SqlCommand(query, sqlCon);
                SqlDataReader reader = command.ExecuteReader();

                // Populate ComboBox with data from the database
                while (reader.Read())
                {
                    comboBox_Brand.Items.Add(reader["BrandName"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }*/
    }
}
