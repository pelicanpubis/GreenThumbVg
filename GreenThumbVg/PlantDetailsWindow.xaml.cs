using GreenThumbVg.Database;
using GreenThumbVg.Models;
using GreenThumbVg.Respitory;
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
            GreenThumbVg.User.User currentUser = UserManager.SignedInUser;

            if (currentUser != null)
            {
                using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
                {
                    int plantId = selectedPlant.PlantId;

                    // Retrieve the user's garden ID
                    int userGardenId = context.Gardens
                        .Where(g => g.UserId == currentUser.Id)
                        .Select(g => g.GardenId)
                        .FirstOrDefault();

                    if (userGardenId != 0) // Ensure a valid garden ID is retrieved
                    {
                        // Check if the plant already exists in the current user's garden
                        bool plantExistsInGarden = context.GardenPlants
                            .Any(gp => gp.GardenId == userGardenId && gp.PlantId == plantId);

                        if (!plantExistsInGarden)
                        {
                            GardenPlant gardenPlant = new GardenPlant
                            {
                                GardenId = userGardenId, // Use the retrieved garden ID
                                PlantId = plantId
                            };

                            context.GardenPlants.Add(gardenPlant);
                            context.SaveChanges();

                            MyGardenWindow myGardenWindow = new MyGardenWindow();
                            myGardenWindow.AddPlantToList(selectedPlant);
                            myGardenWindow.Show();

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("This plant is already in the garden.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User's garden not found.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No user signed in.");
            }


            //orginal
            //// Get the signed-in user
            //GreenThumbVg.User.User currentUser = UserManager.SignedInUser;

            //if (currentUser != null)
            //{
            //    using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
            //    {
            //        int plantId = selectedPlant.PlantId;

            //        // Check if the plant already exists in the current user's garden
            //        bool plantExistsInGarden = context.GardenPlants
            //            .Any(gp => gp.Garden.UserId == currentUser.Id && gp.PlantId == plantId);

            //        if (!plantExistsInGarden)
            //        {
            //            GardenPlant gardenPlant = new GardenPlant
            //            {

            //                //vill hämta garden id
            //                GardenId = currentUser.Id, // Use the current user's garden ID

            //                //GardenId = currentUser.Garden.GardenId, // Use the current user's garden ID
            //                PlantId = plantId
            //            };

            //            context.GardenPlants.Add(gardenPlant);
            //            context.SaveChanges();

            //            // Open MyGardenWindow and pass the selected plant
            //            MyGardenWindow myGardenWindow = new MyGardenWindow();
            //            myGardenWindow.AddPlantToList(selectedPlant);
            //            myGardenWindow.Show();

            //            this.Close();
            //        }
            //        else
            //        {
            //            MessageBox.Show("This plant is already in the garden.");
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No user signed in.");
            //}



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







            }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Öppna AddPlant-orderfönstret här
            PlantWindow PlantWindow = new PlantWindow();
            PlantWindow.Show();

            this.Close();

        }
    }

    }



