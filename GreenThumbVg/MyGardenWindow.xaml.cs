using GreenThumbVg.Database;
using GreenThumbVg.Models;
using GreenThumbVg.User;
using Microsoft.EntityFrameworkCore;
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
using System.Xml.Linq;


namespace GreenThumbVg
{
    /// <summary>
    /// Interaction logic for MyGardenWindow.xaml
    /// </summary>
    public partial class MyGardenWindow : Window
    {


        public MyGardenWindow()
        {
            InitializeComponent();


            LoadCurrentUserPlants(); // Laddar användarens växter när fönstret öppnas

        }






        private void LoadCurrentUserPlants()
        {


            // Hämtar den inloggade användaren
            GreenThumbVg.User.User currentUser = UserManager.SignedInUser;

            if (currentUser != null)
            {
                using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
                {
                    // Hämtar användarens växter med relaterad information från databasen
                    var gardenPlantList = context.GardenPlants
                        .Include(g => g.Garden)
                        .Include(g => g.Plant)
                        .Where(gp => gp.Garden.UserId == currentUser.Id)
                        .ToList();

                    // Lägger till växternas namn i ListView
                    foreach (var gardenPlant in gardenPlantList)
                    {
                        ListViewItem gardenPlantItem = new ListViewItem();
                        gardenPlantItem.Tag = gardenPlant;
                        gardenPlantItem.Content = gardenPlant.Plant.NameOfPlant;
                        lstMyGardenPlants.Items.Add(gardenPlantItem);
                    }
                }
            }

        }



        public void AddPlantToList(PlantModel plant)
        {

           
            lstMyGardenPlants.Items.Add(plant.NameOfPlant);
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            // Öppna AddPlant-orderfönstret här
            PlantWindow plantWindow = new PlantWindow();
            plantWindow.Show();

            this.Close();
        }

            }
        }
    



