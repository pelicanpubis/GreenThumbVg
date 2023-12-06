using GreenThumbVg.Database;
using GreenThumbVg.Migrations;
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

