using GreenThumbVg.Database;
using GreenThumbVg.Models;
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

namespace GreenThumbVg
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        private PlantModel selectedPlant;



        // Konstruktor som tar emot detaljer för en specifik växt och visar dem i fönstret
        public PlantDetailsWindow(PlantModel plantDetails)
        {
            InitializeComponent();
            txtName.Text = plantDetails.NameOfPlant;
            selectedPlant = plantDetails;


            // Hämtar instruktioner för den specifika växten från databasen och visar dem i fönstret
            using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
            {
                var instructionsForPlant = context.Instructions
                    .Where(instruction => instruction.PlantId == plantDetails.PlantId)
                    .ToList();

                // Skapar en text av instruktionerna och visar dem i textrutan i fönstret
                string instructionsText = string.Join(Environment.NewLine, instructionsForPlant.Select(instruction => instruction.Instruction));
                txtInstructions.Text = instructionsText;
            }




        }


        private void btnAddToGarden_Click(object sender, RoutedEventArgs e)
        {

            using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
            {
                int gardenId = 1; // Replace with the actual garden ID
                int plantId = selectedPlant.PlantId;

                bool plantExistsInGarden = context.GardenPlants.Any(gp => gp.GardenId == gardenId && gp.PlantId == plantId);

                if (!plantExistsInGarden)
                {
                    GardenPlant gardenPlant = new GardenPlant
                    {
                        GardenId = gardenId,
                        PlantId = plantId
                    };

                    context.GardenPlants.Add(gardenPlant);
                    context.SaveChanges();

                    // Open MyGardenWindow and pass the selected plant
                    MyGardenWindow myGardenWindow = new MyGardenWindow();
                    myGardenWindow.AddPlantToList(selectedPlant);
                    myGardenWindow.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("This plant is already in the garden.");
                }

                //using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
                //{
                //    int gardenId = 1; // Replace with the actual garden ID
                //    int plantId = selectedPlant.PlantId;

                //    // Check if the entry already exists
                //    bool plantExistsInGarden = context.GardenPlants.Any(gp => gp.GardenId == gardenId && gp.PlantId == plantId);

                //    if (!plantExistsInGarden)
                //    {
                //        GardenPlant gardenPlant = new GardenPlant
                //        {
                //            GardenId = gardenId,
                //            PlantId = plantId
                //        };

                //        context.GardenPlants.Add(gardenPlant);
                //        context.SaveChanges();
                //    }
                //    else
                //    {
                //        // Handle the case where the entry already exists (perhaps show a message)
                //        MessageBox.Show("This plant is already in the garden.");
                //    }
                //}

                //// Assume you have a gardenId available or retrieved from somewhere
                //int gardenId = 1; // Replace with the actual garden ID

                //using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
                //{
                //    GardenPlant gardenPlant = new GardenPlant
                //    {
                //        GardenId = gardenId,
                //        PlantId = selectedPlant.PlantId // Assuming PlantId is the identifier of the selected plant
                //    };

                //    context.GardenPlants.Add(gardenPlant);
                //    context.SaveChanges();
                //}

                //MyGardenWindow myGardenWindow = new MyGardenWindow();
                //myGardenWindow.Show();

                //this.Close();


            }

        }

            public void AddPlantAndInstructionsToGarden(PlantModel plant) //ändra till plantmodel
            {
                using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
                {
                    // Lägg till växten i listan i MyGardenWindow
                    // listViewPlants.Items.Add(plant);

                    // Spara växten i databasen
                    context.Plants.Add(plant);
                    context.SaveChanges();
                }




                //using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
                //{
                //    context.GardenPlants.Add(plant); // Använd context.GardenPlants.Add(plant) istället för context.Plants.Add(plant)

                //    context.SaveChanges();
                //}



            }
        }

    }



