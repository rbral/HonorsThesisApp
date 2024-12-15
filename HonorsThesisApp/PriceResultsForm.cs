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

        //holds all the info for a a store: key string is the name of the store, ProductStoreInfo is a class taht has the total price and list of products.
        Dictionary<string, ProductStoreInfo> map;
        List<string> noProductsAvailable;


        public PriceResultsForm(List<String> selectedStores)
        {
            InitializeComponent();
            this.selectedStores = selectedStores;

            runAndDisplay();

        }

        public PriceResultsForm(Dictionary<string, ProductStoreInfo> map, List<string>noProducts)
        {
            InitializeComponent();
            this.map = map;
            noProductsAvailable = noProducts;

            runAndDisplay();

        }

        private void runAndDisplay()
        {
            CalculatePrices();
            //   DisplaySelectedStores();
            DisplayStoreResults();
            DisplayNoProductsAvailable();
        }

        private void DisplayNoProductsAvailable()
        {
            int startX = 200;
            int startY = 20;
            int spacing = 30;
            Label noproducts = new Label
            {
                Text = "These Products are not available in any stores: \n " + noProductsAvailable.ToString(),
                AutoSize = true,
                Location = new Point(startX, startY + (3 * spacing)) // Adjust the Y-coordinate for each label
            };
        }

        private void DisplayStoreResults()
        {
            // Set the starting position for labels
            int startX = 20; // X-coordinate
            int startY = 20; // Y-coordinate
            int spacing = 30; // Space between labels

            // Loop through the selected stores and create labels
            foreach (KeyValuePair<string, ProductStoreInfo> kvp in map)
            {
                Label storeLabel = new Label

                {
                    Text = kvp.Key,
                    AutoSize = true,
                    Location = new Point(startX, startY + (2 * spacing)) // Adjust the Y-coordinate for each label
                };

                Label resultsLabel = new Label
                {
                    Text = kvp.Value.productNames.ToString(),
                    AutoSize=true,
                    Location = new Point(startX, startY + (2 * spacing)) // Adjust the Y-coordinate for each label

                };

                // Add the label to the form
                this.Controls.Add(storeLabel);
            }
        }

        // calculations for which store has best prices can go here:
        private void CalculatePrices()
        {

        }

        // this GUI still needs to be adjusted with the correct layout
        private void DisplaySelectedStores()
        {
            // Set the starting position for labels
            int startX = 20; // X-coordinate
            int startY = 20; // Y-coordinate
            int spacing = 30; // Space between labels

            // Loop through the selected stores and create labels
            for (int i = 0; i < selectedStores.Count; i++)
            {
                Label storeLabel = new Label
                {
                    Text = selectedStores[i],
                    AutoSize = true,
                    Location = new Point(startX, startY + (i * spacing)) // Adjust the Y-coordinate for each label
                };

                // Add the label to the form
                this.Controls.Add(storeLabel);
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
