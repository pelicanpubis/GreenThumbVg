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

          
            LoadCurrentUserPlants();
          // LoadAllPlantsInGarden();

        }



       
        

        private void LoadCurrentUserPlants()
        {


            // Get the signed-in user
            GreenThumbVg.User.User currentUser = UserManager.SignedInUser;

            if (currentUser != null)
            {
                using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
                {
                    var gardenPlantList = context.GardenPlants
                        .Include(g => g.Garden)
                        .Include(g => g.Plant)
                        .Where(gp => gp.Garden.UserId == currentUser.Id)
                        .ToList();

                    // Add the plant names to the ListView
                    foreach (var gardenPlant in gardenPlantList)
                    {
                        ListViewItem gardenPlantItem = new ListViewItem();
                        gardenPlantItem.Tag = gardenPlant;
                        gardenPlantItem.Content = gardenPlant.Plant.NameOfPlant;
                        lstMyGardenPlants.Items.Add(gardenPlantItem);
                    }
                }
            }



            //orginal
            //// Get the signed-in user
            //GreenThumbVg.User.User currentUser = UserManager.SignedInUser;

            //List<GardenPlant> userGardenPlants;

            //if (currentUser != null)
            //{
            //    // Clear the existing items in the ListView
            //    lstMyGardenPlants.Items.Clear();
            //    using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
            //    {
            //        //// Retrieve garden plants for the current user
            //        //userGardenPlants = context.GardenPlants
            //        //    .Include(gp => gp.Plant)
            //        //    .Where(gp => gp.Garden.UserId == currentUser.Id)
            //        //    .ToList();

            //        var gardenPlantList = context.GardenPlants.Include(g => g.Garden).Include(g => g.Plant).Where(gp => gp.Garden.UserId ==UserManager.SignedInUser.Id).ToList();

            //        // Add the plant names to the ListView
            //        foreach (var gardenPlant in gardenPlantList)
            //        {
            //            ListViewItem gardenPlantItem = new ListViewItem();
            //            gardenPlantItem.Tag = gardenPlant;
            //            gardenPlantItem.Content = gardenPlant.Plant.NameOfPlant;
            //            lstMyGardenPlants.Items.Add(gardenPlantItem);


            //            //// Access the associated PlantModel to display its name
            //            //lstMyGardenPlants.Items.Add(gardenPlant.Plant.NameOfPlant);
            //        }
            //    }




            //}
        }




        //nu visar denna metoden alla plantor till fönstret
        private void LoadAllPlantsInGarden()
        {

            List<GardenPlant> gardenPlants;

            using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
            {
                // Retrieve all garden plants including related plant information
                gardenPlants = context.GardenPlants.Include(gp => gp.Plant).ToList();
            }

            // Add the plant names to the ListView
            foreach (var gardenPlant in gardenPlants)
            {
                // Access the associated PlantModel to display its name
                lstMyGardenPlants.Items.Add(gardenPlant.Plant.NameOfPlant);
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
    



