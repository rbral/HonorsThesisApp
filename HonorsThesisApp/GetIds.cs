using System.Configuration;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace HonorsThesisApp
{
    internal class GetIds
    {
        private static String strServer = ConfigurationManager.AppSettings["server"];
        private static String strDatabase = ConfigurationManager.AppSettings["database"];

        // private String connString = "Data Source=RIVKALAPTOP\\SQLEXPRESS01;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";

        private String connString = "Data Source=labB119ZD\\SQLEXPRESS;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";
        //get store Id
        public int GetStoreId(object selectedItem, string tbName = "")
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
                        if (selectedItem == "Add New Store")
                        {
                            command.Parameters.AddWithValue("@currstore", tbName);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@currStore", selectedItem);
                        }
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
        //get the product ID
        public int GetProductId(object selectedItem, string tbName = "")
        {
            int product = 0;
            string getBrandId = "SELECT product_id FROM Products WHERE product_name = @productname";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                try
                {
                    // Open the connection to the database. 
                    cnn.Open();
                    //get category ID
                    using (SqlCommand cmd = new SqlCommand(getBrandId, cnn))
                    {
                        if (selectedItem == "Add New")
                        {
                            cmd.Parameters.AddWithValue("@productname", tbName);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@productname", selectedItem);
                        }
                        try
                        {
                            var result = cmd.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                product = Convert.ToInt32(result);
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
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }
            return product;
        }
    }
}