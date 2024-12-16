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
using Microsoft.IdentityModel.Tokens;

namespace HonorsThesisApp
{
    public partial class StoreForm : Form
    {
        List<String> selectedProducts = new List<string>();
        public StoreForm(List<String> products)
        {
            InitializeComponent();
            LoadCheckedListStores();
            selectedProducts = products;
        }

        private String connString = "Data Source=RIVKALAPTOP\\SQLEXPRESS01;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";
        //private String connString = "Data Source=labB119ZD\\SQLEXPRESS;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";

        //holds all the info for a a store: key string is the name of the store, ProductStoreInfo is a class taht has the total price and list of products.
        Dictionary<string, ProductStoreInfo> map = new Dictionary<string, ProductStoreInfo>();
        List<string> noProductsAvailable = new List<string>();


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
            addStores(selectedStores);
            getStoreProducts(selectedProducts, selectedStores);
            PriceResultsForm form = new PriceResultsForm(map, noProductsAvailable);
            form.Show();
            this.Hide();
        }

        //adds all the selectedStores to a dictionary 
        public void addStores(List<string> selectedStores)
        {
            List<string> emptyList = new List<string>();
            for (int ix = 0; ix < selectedStores.Count; ix++)
            {
                map.Add(selectedStores[ix], new ProductStoreInfo(0.0));
            }
        }

        public void getStoreProducts(List<string> items, List<string> stores)
        {
            //do this for every product
            for (int itemIX = 0; itemIX < items.Count; itemIX++)
            {
                string cheapestStore = "";
                double cheapestPrice = 0;
                string itemName = items[itemIX];
                //   string getStoreAndPrice = "SELECT TOP 1 store_name, sp.price FROM Store_products sp JOIN Stores s ON s.store_id = sp.store_id JOIN Products p ON sp.product_id = p.product_id " +
                //        "WHERE product_name = @product_name AND store_name IN(@store_names) ORDER BY price ASC";
                string getStoreAndPrice = "SELECT TOP 1 store_name, sp.price FROM Store_products sp JOIN Stores s ON s.store_id = sp.store_id JOIN Products p ON sp.product_id = p.product_id " +
                    "WHERE product_name = @product_name AND store_name IN({0}) ORDER BY price ASC";
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    try
                    {
                        // Open the connection to the database. 
                        cnn.Open();

                        using (SqlCommand cmd = new SqlCommand(getStoreAndPrice, cnn))
                        {
                            cmd.Parameters.AddWithValue("@product_name", itemName);
                            var storeParameterList = new List<string>();
                            foreach (String store in stores)
                            {
                                var paramName = "@storeParam" + stores.IndexOf(store);
                                cmd.Parameters.AddWithValue(paramName, store);
                                storeParameterList.Add(paramName);
                            }
                            //   cmd.Parameters.AddWithValue("@store_names", string.Join(", ", stores));
                            cmd.CommandText = string.Format(getStoreAndPrice, string.Join(",", storeParameterList));
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

                if (cheapestStore.IsNullOrEmpty() || cheapestPrice < 0.01)
                {
                    noProductsAvailable.Add(itemName);
                }
                else
                {
                    ProductStoreInfo info = map.GetValueOrDefault(cheapestStore);
                    info.totalPrice += cheapestPrice;
                    info.productNames.Add(itemName);


                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeForm form = new HomeForm();
            form.Show();
            this.Hide();
        }
    }
}
