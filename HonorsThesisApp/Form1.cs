using System;
using System.Data.SqlClient;


namespace HonorsThesisApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //LoadItemNames();
        }

        private void L_Receipt_Title_Click(object sender, EventArgs e)
        {

        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(); // Create an instance of the new form
            newForm.Show();              // Show the new form
            this.Hide();                 // Optionally hide the current form
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
