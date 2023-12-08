using GreenThumbVg.Database;
using GreenThumbVg.Models;
using GreenThumbVg.Respitory;
using GreenThumbVg.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
        
        private PlantModel selectedPlant; //En privat variabel för att hålla information om den valda växten




        // Konstruktor som tar emot detaljer för en specifik växt och visar dem i fönstret
        public PlantDetailsWindow(PlantModel plantDetails)
        {
            InitializeComponent();
            txtName.Text = plantDetails.NameOfPlant; // Visar växtnamnet i fönstret
            selectedPlant = plantDetails;  // Sätter den valda växten



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


        // Metod för att lägga till växter i användarens trädgård
        private void btnAddToGarden_Click(object sender, RoutedEventArgs e)
        {
            GreenThumbVg.User.User currentUser = UserManager.SignedInUser; // Hämtar den inloggade användaren

            if (currentUser != null) // Kontrollerar om användaren är inloggad
            {
                using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
                {
                    // Hämtar den valda växtens ID
                    int plantId = selectedPlant.PlantId;

                    // Hämtar användarens trädgårds-ID
                    int userGardenId = context.Gardens
                        .Where(g => g.UserId == currentUser.Id)
                        .Select(g => g.GardenId)
                        .FirstOrDefault();

                    if (userGardenId != 0) // Kontrollerar om giltigt trädgårds-ID hämtades
                    {
                        // Kontrollerar om växten redan finns i användarens trädgård
                        bool plantExistsInGarden = context.GardenPlants
                            .Any(gp => gp.GardenId == userGardenId && gp.PlantId == plantId);

                        if (!plantExistsInGarden) // Lägger till växten om den inte redan finns
                        {
                            GardenPlant gardenPlant = new GardenPlant
                            {
                                GardenId = userGardenId, // Använder det hämtade trädgårds-ID:t
                                PlantId = plantId
                            };

                            context.GardenPlants.Add(gardenPlant); // Använder det hämtade trädgårds-ID:t
                            context.SaveChanges();// Lägger till växten i trädgårdslistan

                            MyGardenWindow myGardenWindow = new MyGardenWindow();
                           // myGardenWindow.AddPlantToList(selectedPlant);
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



