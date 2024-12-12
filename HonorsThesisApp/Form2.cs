
using System.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;


namespace HonorsThesisApp
{
    public partial class Form2 : Form
    {
        private static String strServer = ConfigurationManager.AppSettings["server"];
        private static String strDatabase = ConfigurationManager.AppSettings["database"];
        private String strConnect = $"Server={strServer};Database={strDatabase};TrustServerCertificate=True;";
        private String currBrand = "";
        private int storeID;
        private DateTime date;

        //     private String connString = "Data Source=RIVKALAPTOP\\SQLEXPRESS01;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";
        private String connString = "Data Source=labB119ZD\\SQLEXPRESS;Initial Catalog=ShopAI;Integrated Security=True;TrustServerCertificate=True;";
        public Form2(int storeID, DateTime date)
        {
            InitializeComponent();
            LoadCategory_CBData();
            LoadBrand_CBData();
            this.storeID = storeID;
            this.date = date;
        }

        #region Load Combo Box Data
        //gets all categories
        private void LoadCategory_CBData()
        {
            string query = "SELECT category_name FROM Categories ORDER BY category_name";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    //categorySelector.Items.Clear();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                categorySelector.Items.Add(reader[0].ToString());
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

        //gets all brands
        private void LoadBrand_CBData()
        {
            string query = "SELECT brand_name FROM Brand ORDER BY brand_name";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        String selectedCategory = "";
                        if (categorySelector.SelectedItem != null)
                        {
                            selectedCategory = categorySelector.SelectedItem.ToString();
                        }
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                brandSelector.Items.Add(reader[0].ToString());
                            }
                        }
                    }
                    brandSelector.Items.Add("Add New");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }

        //gets all items
        private void LoadItem_CBData()
        {

            string query = "SELECT product_name FROM Products p JOIN Brand b ON p.brand_id = b.brand_id WHERE brand_name = @currBrand";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        String selectedBrand = "";
                        if (brandSelector.SelectedItem != null)
                        {
                            selectedBrand = brandSelector.SelectedItem.ToString();
                        }
                        TB_Item.Items.Clear();
                        command.Parameters.AddWithValue("@currBrand", selectedBrand);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TB_Item.Items.Add(reader[0].ToString());
                            }
                        }

                    }
                    TB_Item.Items.Add("Add New");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }

            }
        }
        #endregion

        #region Selected Index Changed
        private void brandSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brandSelector.SelectedItem?.ToString() == "Add New")
            {
                TB_NewBrandName.Visible = true;
                TB_NewBrandName.Text = "Enter New Brand";
                TB_Item.Items.Add("Add New");
            }
            else
            {
                TB_NewBrandName.Visible = false;
                LoadItem_CBData();
            }
        }

        private void TB_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TB_Item.SelectedItem?.ToString() == "Add New")
            {
                TB_NewItemName.Visible = true;
                TB_NewItemName.Text = "Enter New Item";
            }
            else
            {
                TB_NewItemName.Visible = false;
            }
        }

        #endregion

        #region Add Brand, Product, Store Item
        // this actually adds a new brand
        private void addBrandToDB()
        {
            if (TB_NewBrandName != null)
            {

                String query = "INSERT INTO Brand VALUES(@brand)";

                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    try
                    {
                        cnn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, cnn))
                        {
                            cmd.Parameters.AddWithValue("@brand", TB_NewBrandName.Text);
                            int rowsAdded = cmd.ExecuteNonQuery();
                            if (rowsAdded > 0)
                                MessageBox.Show("Brand Added!");
                            else
                                MessageBox.Show("Brand Failed to Add");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR:" + ex.Message);
                    }
                }
                brandSelector.Items.Clear();
                LoadBrand_CBData();
                TB_NewBrandName.Visible = false;
             
            }
        }

        //this is for adding a product
        private void addItemToDB()
        {
            if (categorySelector.SelectedItem == null || brandSelector.SelectedItem == null || TB_Barcode.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Category must be entered before adding a new item.");
                return;
            }
            if (brandSelector.SelectedItem == null)
            {
                MessageBox.Show("Brand must be entered before adding a new item.");
                return;
            }

            if (TB_Barcode.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Barcode must be entered before adding a new item.");
                return;
            }
            
            
            int category = 0;
            int brand = 0;
            string getCategoryId = "SELECT category_id FROM Categories WHERE category_name = @catname";
            string getBrandId = "SELECT brand_id FROM brand WHERE brand_name = @brandname";
            String query = "INSERT INTO Products VALUES(@barcode, @item, @brand, @category)";

            // Create the connection (and be sure to dispose it at the end)
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                try
                {
                    cnn.Open();
                    //get category & brand ID
                    using (SqlCommand cmd = new SqlCommand(getCategoryId, cnn))
                    {
                        cmd.Parameters.AddWithValue("@catname", categorySelector.SelectedItem);
                        try
                        {
                            var result = cmd.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                category = Convert.ToInt32(result);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand(getBrandId, cnn))
                    {

                        if (brandSelector.SelectedItem == "Add New")
                        {
                            cmd.Parameters.AddWithValue("@brandname", TB_NewItemName.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@brandname", brandSelector.SelectedItem);
                        }
                        try
                        {
                            var result = cmd.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                brand = Convert.ToInt32(result);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }

                    // add item to db
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@barcode", TB_Barcode.Text);
                        cmd.Parameters.AddWithValue("@item", TB_NewItemName.Text);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@brand", brand);
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            MessageBox.Show("Item inserted");
                        else
                            MessageBox.Show("Item could not be inserted");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }
            TB_Item.Items.Clear();
            LoadItem_CBData();
            TB_NewItemName.Visible = false;
                
        }
        

        

        //this is for adding an item to a store
        private void button_AddItem_Click(object sender, EventArgs e)
        {
            //add the brand & item if needed
            if (brandSelector.SelectedItem == "Add New" && (!TB_NewBrandName.Text.IsNullOrEmpty() || TB_NewBrandName.Text != "Enter New Brand"))
            {
                addBrandToDB();
            }
            if (TB_Item.SelectedItem == "Add New" && (!TB_NewItemName.Text.IsNullOrEmpty() || TB_NewBrandName.Text != "Enter New Item"))
            {
                addItemToDB();
            }

            double price = 0.0;
            try
            {
                price = Convert.ToDouble(TB_Price.Text);
            } catch
            {
                MessageBox.Show("Price must be a positive number");
                return;
            }

            if (TB_Item.SelectedItem == null && TB_Item.SelectedItem != "Add New")
            {
                MessageBox.Show("Selected Item must be inputted before adding a new item.");
                return;
            }



            GetIds helperClass = new GetIds();
            String query = "MERGE INTO Store_products AS target USING (VALUES (@product, @store, @price, @date )) AS source (product_id, store_id, price, date) ON target.product_id = source.product_id AND target.store_id = source.store_id WHEN MATCHED THEN UPDATE SET target.price = CASE WHEN target.date > source.date THEN target.price ELSE source.price END, target.date = CASE WHEN target.date > source.date THEN target.date ELSE source.date END WHEN NOT MATCHED THEN INSERT (product_id, store_id, price, date) VALUES (source.product_id, source.store_id, source.price, source.date);";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                try
                {
                    cnn.Open();
                    // add item to db
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@product", helperClass.GetProductId(TB_Item.SelectedItem, TB_NewItemName.Text));
                        cmd.Parameters.AddWithValue("@store", storeID);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@date", date);
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            MessageBox.Show("Product Added to Store");
                        else
                            MessageBox.Show("Failed to add product to Store");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }

            TB_Barcode.Clear();
            brandSelector.Items.Clear();
            LoadBrand_CBData();
            TB_Item.Items.Clear();
            LoadItem_CBData();
            TB_NewBrandName.Visible = false;
            TB_NewItemName.Visible = false;
            
        }


        //submit form
         private void button_Submit_Click(object sender, EventArgs e)
        {
            // exit the screen
            MessageBox.Show("Are you sure you're done entering items for this shopping date and store?");

        }
        #endregion
  
    }
}