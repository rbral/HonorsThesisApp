using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HonorsThesisApp
{
    public partial class PriceResultsForm : Form
    {
        private List<string> selectedStores;

        //holds all the info for a a store: key string is the name of the store,
        //ProductStoreInfo is a class taht has the total price and list of products.
        Dictionary<string, ProductStoreInfo> map;
        List<string> noProductsAvailable;

        // Set the starting position for labels
        int startX = 20; // X-coordinate
        int startY = 100; // Y-coordinate
        int spacing = 50; // Space between labels

        public PriceResultsForm(Dictionary<string, ProductStoreInfo> map, List<string>noProducts)
        {
            InitializeComponent();
            this.map = map;
            noProductsAvailable = noProducts;

            // run the display logic: 
            DisplayStoreResults();
            DisplayNoProductsAvailable();            
        }

        private void DisplayStoreResults()
        {
            // Loop through the selected stores and create labels
            foreach (KeyValuePair<string, ProductStoreInfo> kvp in map)
            {
                string storeName = kvp.Key;
                ProductStoreInfo storeInfo = kvp.Value;

                // create and display the store name label:
                Label storeLabel = new Label

                {
                    Text = $"Store: {storeName} (Total Price: ${storeInfo.totalPrice:F2})",
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Location = new Point(startX, startY) // Adjust the Y-coordinate for each label
                };
                this.Controls.Add(storeLabel);

                // display the list of products for the store:
                int productY = startY + 30;
                foreach (string product in storeInfo.productNames)
                {
                    Label productLabel = new Label
                    {
                        Text = $"- {product}",
                        AutoSize = true,
                        Font = new Font("Arial", 10, FontStyle.Regular),
                        Location = new Point(startX + 20, productY)
                    };
                    this.Controls.Add(productLabel);
                    productY += 30; // Space out product labels
                }

                // Adjust startY for the next store
                startY = productY + spacing;
            }
        }

        private void DisplayNoProductsAvailable()
        {

            // Title label for unavailable products
            Label titleLabel = new Label
            {
                Text = "Products Not Available in Any Store:",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(startX, startY)
            };
            this.Controls.Add(titleLabel);

            // Display each unavailable product
            int productY = startY + 30;
            foreach (string product in noProductsAvailable)
            {
                Label productLabel = new Label
                {
                    Text = $"- {product}",
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    Location = new Point(startX + 20, productY)
                };
                this.Controls.Add(productLabel);
                productY += spacing;
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
