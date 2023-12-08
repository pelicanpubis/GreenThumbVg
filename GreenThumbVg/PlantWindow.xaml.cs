using GreenThumbVg.Database;
using GreenThumbVg.Models;
using GreenThumbVg.Respitory;
using GreenThumbVg.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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


        // En lista för alla växter
        private List<PlantModel> allPlants;

        public PlantWindow()
        {
            InitializeComponent();


            // Visa inloggad användares namn om någon är inloggad

            if (UserManager.SignedInUser != null)
            {
                txtLoggedInUser.Text = UserManager.SignedInUser.Username;
            }


            // Laddar växterna asynkront när fönstret skapas
            LoadPlantsAsync();


            async void LoadPlantsAsync() // Asynkron metod för att ladda växter från databasen
            {
                using (GreenThumbVgDbContext context = new())
                {
                    PlantRepository<PlantModel> plantRepository = new(context);

                    allPlants = await plantRepository.GetAll(); // Hämtar alla växter från databasen

                    // Lägger till växterna i listan i fönstret
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

        private void txtPlantSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
         

            string searchTerm = txtPlantSearch.Text.ToLower(); // User input

            lstPlants.Items.Clear(); // Rensar listan för att visa filtrerade växter

            // Filtrerar växter baserat på användarens sökterm
            var filteredPlants = allPlants.Where(p => p.NameOfPlant.ToLower().Contains(searchTerm));


            // Lägger till de filtrerade växterna i listan i fönstret
            foreach (var plant in filteredPlants)
            {
                ListViewItem item = new ListViewItem();
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

            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstPlants.SelectedItem != null)
            {
                // Hämta den valda växten från listan
                PlantModel selectedPlant = (PlantModel)((ListViewItem)lstPlants.SelectedItem).Tag;

                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {selectedPlant.NameOfPlant}?", "Confirmation", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    // Ta bort växten från listan
                    lstPlants.Items.Remove(lstPlants.SelectedItem);

                    // Ta bort den valda växten från databasen
                    using (GreenThumbVgDbContext context = new())
                    {
                        PlantRepository<PlantModel> plantRepository = new(context);
                        plantRepository.Delete(selectedPlant);

                      
                    }

                    MessageBox.Show($"{selectedPlant.NameOfPlant} has been deleted.");
                }
            }
            else
            {
                MessageBox.Show("Please select a plant to delete.");
            }
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {

            if (lstPlants.SelectedItem != null)
            {
                ListViewItem selectedListViewItem = (ListViewItem)lstPlants.SelectedItem;
                PlantModel selectedPlant = (PlantModel)selectedListViewItem.Tag;

                // Öppna PlantDetailsWindow och skicka med den valda växtens information
                PlantDetailsWindow plantDetailsWindow = new PlantDetailsWindow(selectedPlant);
                plantDetailsWindow.Show();
            }
            else
            {
                MessageBox.Show("Vänligen välj en växt för att visa detaljer.");
            }
        }

        private void btnMyGarden_Click(object sender, RoutedEventArgs e)
        {
         

            //Öppnar MyGardenWindow
            MyGardenWindow myGardenWindow = new MyGardenWindow();
            myGardenWindow.Show();

            this.Close();


        }


        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            UserManager.SignOutUser();
            Close();
        }
    }
}
