using GreenThumbVg.Database;
using GreenThumbVg.Models;
using GreenThumbVg.Respitory;
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
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        private List<PlantModel> allPlants;

        public PlantWindow()
        {
            InitializeComponent();
            LoadPlantsAsync();


            async void LoadPlantsAsync()
            {
                using (GreenThumbVgDbContext context = new())
                {
                    PlantRepository<PlantModel> plantRepository = new(context);

                    allPlants = await plantRepository.GetAll();

                    foreach (var plant in allPlants)
                    {
                        ListViewItem item = new();
                        item.Tag = plant;
                        item.Content = plant.NameOfPlant;

                        lstPlants.Items.Add(item);
                    }
                }
            }
        }

        private void lstPlants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string searchTerm = txtPlantSearch.Text.ToLower(); // Användarens inmatning

            lstPlants.Items.Clear();

            var filteredPlants = allPlants.Where(p => p.NameOfPlant.ToLower().Contains(searchTerm));

            foreach (var plant in filteredPlants)
            {
                ListViewItem item = new();
                item.Tag = plant;
                item.Content = plant.NameOfPlant;

                lstPlants.Items.Add(item);
            }
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            // Öppna AddPlant-orderfönstret här
            AddPlantWindow addPlantWindow = new AddPlantWindow();
            addPlantWindow.Show();
        }
    }
}
