using GreenThumbVg.Database;
using GreenThumbVg.Migrations;
using GreenThumbVg.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        private ObservableCollection<PlantModel> plants = new ObservableCollection<PlantModel>();



        public AddPlantWindow()

        {
            InitializeComponent();
            RefreshListView();

        }

        private void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNameOfPlant.Text) || string.IsNullOrWhiteSpace(txtInstruction.Text) || string.IsNullOrWhiteSpace(txtInstructionName.Text))
            {
                txtValidationMessage.Text = "Alla fält måste matas in.";
                return;
            }

            string name = txtNameOfPlant.Text;
            string instructionName = txtInstructionName.Text;
            string instruction = txtInstruction.Text;

            try
            {
                using (GreenThumbVgDbContext context = new())
                {
                    var existingPlant = context.Plants.Include(p => p.Instructions).FirstOrDefault(p => p.NameOfPlant == name);

                    if (existingPlant != null)
                    {
                        existingPlant.Instructions.Add(new InstructionModel { NameOfInstruction = instructionName, Instruction = instruction });
                        context.SaveChanges();
                        RefreshListView(existingPlant);
                    }
                    else
                    {
                        var newPlant = new PlantModel
                        {
                            NameOfPlant = name,
                            Instructions = new List<InstructionModel> { new InstructionModel { NameOfInstruction = instructionName, Instruction = instruction } }
                        };

                        context.Plants.Add(newPlant);
                        context.SaveChanges();
                        RefreshListView(newPlant);
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                txtValidationMessage.Text = "Växten finns redan i databasen.";
            }

  


        }

        private void btnSavePlant_Click(object sender, RoutedEventArgs e)
        {
            // Implementera logik för att spara växten med instruktioner till databasen här
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
    

        }

        private void RefreshListView(PlantModel plant = null)
        {
            lstPlants.ItemsSource = null;

            if (plant != null)
            {
                var instructions = plant.Instructions.Select(instruction => $"{instruction.NameOfInstruction}: {instruction.Instruction}").ToList();
                lstPlants.ItemsSource = instructions;
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new PlantWindow();
            plantWindow.Show();

            // För att stänga det aktuella AddPlantWindow-fönstret när du visar PlantWindow
            this.Close();
        }

        //private void RefreshListView()
        //{
        //    using (GreenThumbVgDbContext context = new())
        //    {
        //        var plantsWithInstructions = context.Plants.Include(p => p.Instructions).ToList();
        //        lstPlants.ItemsSource = plantsWithInstructions;
        //    }
        //}
    }
    }

