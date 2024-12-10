// old version partially edited from chatgt

using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Security.AccessControl;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

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
                                //   brandSelector.SelectedItem = reader[0].ToString();
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
            //  string query = "SELECT product_name FROM Products";

            if (brandSelector.SelectedItem?.ToString() == "Add New")
            {
                TB_Item.Items.Add("Add New");
            }

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


        // one button click for all changes:

        // from rockiconnectsql ---------------------------------------------------------------------------------


        //this is for adding an item to a store - NOT DONE
        private void button_AddItem_Click(object sender, EventArgs e)
        {

            if (categorySelector.SelectedItem == null || brandSelector.SelectedItem == null || TB_Barcode.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Category, brand, and barcode must be entered before adding a new item.");
                return;
            }

            // check if user added a new item name or brand name:
            if (!TB_NewBrandName.Text.IsNullOrEmpty() || TB_NewBrandName.Text != "Enter New Brand")
            {
                  addBrandToDB();
            }

            if (!TB_NewItemName.Text.IsNullOrEmpty() || TB_NewBrandName.Text != "Enter New Item")
            {
                  addItemToDB();
            }


            // replace with correct connection string
            //     String connectionString = "Data Source=RIVKALAPTOP\\SQLEXPRESS01;Initial Catalog=Air; Trusted_Connection=True;";
            String connectionString = "Data Source=UMAIR;Initial Catalog=Air; Trusted_Connection=True;";
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
                        cmd.Parameters.AddWithValue("@store_id", storeID);
                        cmd.Parameters.AddWithValue("@catagory_id", categorySelector.Text);
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
            // then clear all fields so user can enter a new item if they want:
            TB_Barcode.Clear();
            TB_NewBrandName.Text = "Enter New Brand";
            TB_NewItemName.Text = "Enter New Item";
            TB_Price.Clear();
        }
    


        //create a new brand - WHAT DOES THIS DO, ISNT IT IN addBrandToDB_Click - RB: I think we can delete
private void addNewBrandName()
{
    // replace with correct connection string
    //     String connectionString = "Data Source=RIVKALAPTOP\\SQLEXPRESS01;Initial Catalog=Air; Trusted_Connection=True;";
    String connectionString = "Data Source=UMAIR;Initial Catalog=Air; Trusted_Connection=True;";
    // replace with actual sql statement using correct parameters
    String sql = "insert into Main ([Firt Name], [Last Name]) values(@first,@last)";

    // Create the connection (and be sure to dispose it at the end)
    using (SqlConnection conn = new SqlConnection(connectionString))
    {

        try
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Create and set the parameters values 
                cmd.Parameters.AddWithValue("@brandName", TB_NewBrandName.Text);

                // Let's ask the db to execute the query
                int rowsAdded = cmd.ExecuteNonQuery();
                if (rowsAdded > 0)
                    MessageBox.Show("Successfully added new brand name!");
                else
                    // Well this should never really happen
                    MessageBox.Show("Error: Could not add new brand name");

            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("ERROR:" + ex.Message);
        }
    }
}

//what does this do? - isnt this add new item to db?
private void addNewItemName()
{
    // replace with correct connection string
    //     String connectionString = "Data Source=RIVKALAPTOP\\SQLEXPRESS01;Initial Catalog=Air; Trusted_Connection=True;";
    String connectionString = "Data Source=UMAIR;Initial Catalog=Air; Trusted_Connection=True;";

    // replace with actual sql statement using correct parameters
    String sql = "insert into Main ([Firt Name], [Last Name]) values(@first,@last)";

    // Create the connection (and be sure to dispose it at the end)
    using (SqlConnection conn = new SqlConnection(connectionString))
    {

        try
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Create and set the parameters values 
                cmd.Parameters.AddWithValue("@itemName", TB_NewItemName.Text);

                // Let's ask the db to execute the query
                int rowsAdded = cmd.ExecuteNonQuery();
                if (rowsAdded > 0)
                    MessageBox.Show("Successfully added new item name!");
                else
                    // Well this should never really happen
                    MessageBox.Show("Error: Could not add new item name");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("ERROR:" + ex.Message);
        }
    }
}

//gets all items
/*private void LoadItem_CBData()
{
    //  string query = "SELECT product_name FROM Products";

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
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}");
        }

    }
} */

//gets all categories
/*private void LoadCategory_CBData()
{
    string query = "SELECT category_name FROM Categories";

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

} */

//gets all brands
/*private void brandSelector_SelectedIndexChanged(object sender, EventArgs e)
{
    //   LoadBrand_CBData();
    LoadItem_CBData();
} */
/*
private void LoadBrand_CBData()
{
    string query = "SELECT brand_name FROM Brand";

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
                        //   brandSelector.SelectedItem = reader[0].ToString();
                    }
                }

            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}");
        }





    }
} */






private void addBrandToDB_Click(object sender, EventArgs e)
{
    if (TB_NewBrandName != null)
    {

        String query = "INSERT INTO Brand VALUES(@brand)";

        using (SqlConnection cnn = new SqlConnection(connString))
        {
            try
            {

                // If we cannot reach the db then we have connectivity problems
                cnn.Open();

                // Prepare the command to be executed on the db
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    // Create and set the parameters values 
                    cmd.Parameters.AddWithValue("@brand", TB_NewBrandName.Text);
                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0)
                        MessageBox.Show("Row inserted!!");
                    else
                        // Well this should never really n
                        MessageBox.Show("No row inserted");
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
    //    addBrandToDB.Visible = false;
        button_addNewBrand.Visible = true;
    }
}


//buttons to make fields to add new brand/item
/*private void button_addNewBrand_Click(object sender, EventArgs e)
{
    TB_NewBrandName.Visible = true;
    addBrandToDB.Visible = true;
    button_addNewBrand.Visible = false;
} */

/*private void button_addNewItemName_Click(object sender, EventArgs e)
{
    TB_NewItemName.Visible = true;
    addItemToDB.Visible = true;
    button_addNewItemName.Visible = false;  
} */





// this actually adds a new brand
/*private void addBrandToDB_Click(object sender, EventArgs e)
{
    if (TB_NewBrandName != null)
    {

        String query = "INSERT INTO Brand VALUES(@brand)";

        using (SqlConnection cnn = new SqlConnection(connString))
        {
            try
            {

                // If we cannot reach the db then we have connectivity problems
                cnn.Open();

                // Prepare the command to be executed on the db
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    // Create and set the parameters values 
                    cmd.Parameters.AddWithValue("@brand", TB_NewBrandName.Text);
                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0)
                        MessageBox.Show("Row inserted!!");
                    else
                        // Well this should never really n
                        MessageBox.Show("No row inserted");
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
        addBrandToDB.Visible = false;
        button_addNewBrand.Visible = true;
    }
} */
//submit form
private void button_Submit_Click(object sender, EventArgs e)
{
    // exit the screen
    MessageBox.Show("Are you sure you're done entering items for this shopping date and store?");

}

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

                        // If we cannot reach the db then we have connectivity problems
                        cnn.Open();

                        // Prepare the command to be executed on the db
                        using (SqlCommand cmd = new SqlCommand(query, cnn))
                        {
                            // Create and set the parameters values 
                            cmd.Parameters.AddWithValue("@brand", TB_NewBrandName.Text);
                            int rowsAdded = cmd.ExecuteNonQuery();
                            if (rowsAdded > 0)
                                MessageBox.Show("Row inserted!!");
                            else
                                // Well this should never really n
                                MessageBox.Show("No row inserted");
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
                //addBrandToDB.Visible = false;
                //button_addNewBrand.Visible = true;
            }
        }

        //this is for adding a product
        private void addItemToDB()
        {
            if (categorySelector.SelectedItem == null || brandSelector.SelectedItem == null || TB_Barcode.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Category, brand, and barcode must be entered before adding a new item.");
                return;
            }
            else if (TB_NewItemName == null)
            {
                MessageBox.Show("You must enter an item name before pressing add Item");
                return;
            }
            else
            {
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
                        // Open the connection to the database. 
                        cnn.Open();
                        //get category & brand ID
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
                            cmd.Parameters.AddWithValue("@brandname", brandSelector.SelectedItem);
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
                            // Create and set the parameters values 
                            cmd.Parameters.AddWithValue("@barcode", TB_Barcode.Text);
                            cmd.Parameters.AddWithValue("@item", TB_NewItemName.Text);
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@brand", brand);
                            int rowsAdded = cmd.ExecuteNonQuery();
                            if (rowsAdded > 0)
                                MessageBox.Show("Row inserted!!");
                            else
                                //       // Well this should never really n
                                MessageBox.Show("No row inserted");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR:" + ex.Message);
                    }
                }
                TB_Item.Items.Clear();
                LoadItem_CBData(); TB_NewItemName.Visible = false;
                //addItemToDB.Visible = false;
                //button_addNewItemName.Visible = true;
            }
        }



        //submit form
     /*   private void button_Submit_Click(object sender, EventArgs e)
        {
            // exit the screen
            MessageBox.Show("Are you sure you're done entering items for this shopping date and store?");

                using (SqlCommand cmd = new SqlCommand(getBrandId, cnn))
                {
                    cmd.Parameters.AddWithValue("@brandname", brandSelector.SelectedItem);
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
                } */

//this is for adding an item to a store - NOT DONE
/*private void button_AddItem_Click(object sender, EventArgs e)
{
    double price = Convert.ToDouble(TB_Price.Text);
    if (brandSelector.SelectedItem == null || TB_Price.Text == "")
    {
        MessageBox.Show("Selected Item & Price must be inputted before adding a new item.");
    }
    else if (price <= 0.0)
    {
        MessageBox.Show("Price must be a positive number");
    }

    else
    {
        String query = "INSERT INTO Store_products VALUES(@product, @store, @price, @date)";
        // Create the connection (and be sure to dispose it at the end)
        using (SqlConnection cnn = new SqlConnection(connString))
        {
            try
            {
                cnn.Open();
                // add item to db
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@product", GetProductId());
                    cmd.Parameters.AddWithValue("@store", storeID);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@date", date);
                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0)
                        MessageBox.Show("Row inserted!!");
                    else
                 //       // Well this should never really n
                        MessageBox.Show("No row inserted");
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
        //TB_NewBrandName.Visible = false;
        //addBrandToDB.Visible = false;
        //button_addNewBrand.Visible = true;
        TB_Item.Items.Clear();
        LoadItem_CBData();
        TB_NewItemName.Visible = false;
        addItemToDB.Visible = false;
        button_addNewItemName.Visible = true;
    }
}
*/
}
}