using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbVg.Models
{
    public class PlantModel
    {
        [Key]
        public int PlantId { get; set; }

        public string NameOfPlant { get; set; } = null!;

        // Lista av 'InstructionModel' för växtens skötselinstruktioner
        public List<InstructionModel> Instructions { get; set; } = new();

        // Lista av 'GardenPlant' för olika trädgårdsinstallationer av växten
        public List<GardenPlant> GardenPlants { get; set; } = new();


        public PlantModel()
        {
            
        }

        // Konstruktor för 'PlantModel' som tar emot ett växtnamn

        public PlantModel(string nameOfPlant)
        {
            NameOfPlant = nameOfPlant;

        }


        public PlantModel(string nameOfPlant, int plantId, List<InstructionModel> instructions, List<GardenPlant> gardenPlants)
        {
            NameOfPlant = nameOfPlant; // Tilldelar det inkommande namnet till 'NameOfPlant'
            PlantId = plantId; // Tilldelar det inkommande ID:t till 'PlantId'
            Instructions = instructions; // Tilldelar den inkommande listan av instruktioner till 'Instructions'
            GardenPlants = gardenPlants; // Tilldelar den inkommande listan av trädgårdsinstallationer till 'GardenPlants'
        }
    }
}
