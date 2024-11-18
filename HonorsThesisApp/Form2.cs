using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HonorsThesisApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //LoadCategory_CBData();
            //LoadBrand_CBData();
            //LoadItem_CBData();
        }

        private void button_AddItem_Click(object sender, EventArgs e)
        {
            //   addItem();
        }

        private void addItem()
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
                        cmd.Parameters.AddWithValue("@catagory_id", catagorySelector.Text);
                        cmd.Parameters.AddWithValue("@barcode", TB_Barcode.Text);
                        cmd.Parameters.AddWithValue("@brand_id", brandSelector.Text);
                        cmd.Parameters.AddWithValue("@product_name", TB_Item.Text);
                        cmd.Parameters.AddWithValue("@price", TB_Price.Text);

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

        private void LoadCategory_CBData()
        {
            // Connection string (update with actual database details)
            string connString = "Data Source=UMAIR;Initial Catalog=Air;Trusted_Connection=True;";

            string query = "SELECT CategoryName FROM Categories";

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
                                catagorySelector.Items.Add(reader[0].ToString());
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

        private void LoadBrand_CBData()
        {
            // Connection string (update with actual database details)
            string connString = "Data Source=UMAIR;Initial Catalog=Air;Trusted_Connection=True;";

            string query = "SELECT BrandName FROM Brand";

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
                                catagorySelector.Items.Add(reader[0].ToString());
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

        private void LoadItem_CBData()
        {
            // Connection string (update with actual database details)
            string connString = "Data Source=UMAIR;Initial Catalog=Air;Trusted_Connection=True;";

            string query = "SELECT ItemName FROM Item";

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
                                catagorySelector.Items.Add(reader[0].ToString());
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




        private void catagorySelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_addNewBrand_Click(object sender, EventArgs e)
        {
            TB_NewBrandName.Visible = true;
        }

        private void button_addNewItemName_Click(object sender, EventArgs e)
        {
            TB_NewItemName.Visible = true;
        }
    }
}