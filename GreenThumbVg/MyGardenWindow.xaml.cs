using GreenThumbVg.Database;
using GreenThumbVg.Migrations;
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

            LoadAllPlantsInGarden();

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


            //List<GardenPlant> gardenPlants;

            //using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
            //{
            //    // Retrieve all plants considered part of the garden
            //    gardenPlants = context.GardenPlants.ToList(); // Adjust query as per your database structure
            //}

            //// Add the plant names to the ListView
            //foreach (var plant in gardenPlants)
            //{
            //    lstMyGardenPlants.Items.Add(plant.NameOfPlant);
            //}
        }

        public void AddPlantToList(PlantModel plant)
        {
            lstMyGardenPlants.Items.Add(plant.NameOfPlant);
        }

        //public void AddPlantToList(PlantModel plant)
        //{
        //    string plantName = plant.NameOfPlant;
        //    lstMyGardenPlants.Items.Add(plantName);
        //}


        //public void AddPlantToList(GardenPlant gardenPlant)
        //{
        //    // Extract the name of the plant from the GardenPlant object
        //    string plantName = gardenPlant.Plant.NameOfPlant;
           

        //    // Add the plant name to the ListView
        //    lstMyGardenPlants.Items.Add(plantName);
        //}

        //public void AddPlantToList(GardenPlant plant)
        //{
        //    lstMyGardenPlants.Items.Add(plant); // Lägg till växten i listan (listview)
        //}

    }


}

