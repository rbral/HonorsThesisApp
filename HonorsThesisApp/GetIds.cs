using System.Collections.Frozen;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using static System.ComponentModel.Design.ObjectSelectorEditor;
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

        //holds all the info for a a store: key string is the name of the store, ProductStoreInfo is a class taht has the total price and list of products.
        Dictionary<string, ProductStoreInfo> map = new Dictionary<string, ProductStoreInfo>();
        List<string> noProductsAvailable = new List<string>();

        //adds all the selectedStores to a dictionary 
        public void addStores(List<string> selectedStores)
        {
            List<string> emptyList = new List<string>();
           
            for (int ix = 0; ix < selectedStores.Count; ix++)
            {
                map.Add(selectedStores[ix], new ProductStoreInfo(0.0, emptyList));
            }
        }


        //This method goes through every product and finds the cheapest one. It adds the product to the store list and increments the total price for that store
        public void getStoreProducts(List<string> items, List<string> stores)
        {
            //do this for every product
            for (int itemIX = 0; itemIX < items.Count; itemIX++)
            {
                string cheapestStore = "";
                double cheapestPrice = 0;
                string itemName = items[itemIX];
                string getStoreAndPrice = "SELECT TOP 1 store_name FROM Store_products sp JOIN Stores s ON s.store_id = sp.store_id JOIN Products p ON sp.product_id = p.product_id " +
                    "WHERE product_name = @product_name AND store_name IN(@store_names) BY price ASC";
               
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    try
                    {
                        // Open the connection to the database. 
                        cnn.Open();
                        
                        using (SqlCommand cmd = new SqlCommand(getStoreAndPrice, cnn))
                        {
                            cmd.Parameters.AddWithValue("@product_name", itemName);
                            //   cmd.Parameters.AddWithValue("@store_names", string.Join(", ", stores));
                            cmd.Parameters.AddWithValue("@store_names", stores);
                            try
                            {
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        cheapestStore = reader["store_name"].ToString();
                                        cheapestPrice = Convert.ToDouble(reader["price"]);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error executing query: " + ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR:" + ex.Message);
                    }
                }
                
                if(cheapestStore.IsNullOrEmpty() || cheapestPrice < 0.01)
                {
                    noProductsAvailable.Add(itemName);
                }
                else
                {
                    // ProductStoreInfo info = map.GetValueOrDefault(cheapestStore);
                    // info.totalPrice += cheapestPrice;
                    // info.productNames.Add(itemName);
                    ProductStoreInfo info = map[cheapestStore];
                    info.totalPrice += cheapestPrice;
                    info.productNames.Add(itemName);
                    map[cheapestStore] = info;


                    

                }
               

            }
        }

       
    }
}