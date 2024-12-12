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

        public PriceResultsForm(List<String> selectedStores)
        {
            InitializeComponent();
            this.selectedStores = selectedStores;

            runAndDisplay();

        }

        private void runAndDisplay()
        {
            CalculatePrices();
            DisplaySelectedStores();
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
    }
}
