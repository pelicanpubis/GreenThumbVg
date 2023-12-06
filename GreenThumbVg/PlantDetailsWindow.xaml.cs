using GreenThumbVg.Database;
using GreenThumbVg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GreenThumbVg
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        public PlantDetailsWindow(PlantModel plantDetails)
        {
            InitializeComponent();
            txtName.Text = plantDetails.NameOfPlant;
           


            using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
            {
                var instructionsForPlant = context.Instructions
                    .Where(instruction => instruction.PlantId == plantDetails.PlantId)
                    .ToList();

                string instructionsText = string.Join(Environment.NewLine, instructionsForPlant.Select(instruction => instruction.Instruction));
                txtInstructions.Text = instructionsText;
            }

        }

        private void btnAddToGarden_Click(object sender, RoutedEventArgs e)
        {
            // Öppna MygardenWindowPlant-orderfönstret här
            MyGardenWindow myGardenWindow = new MyGardenWindow();
            myGardenWindow.Show();

            this.Close();
        }
    }
}
