using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GreenThumbVg.Models
{
   public class GardenModel
    {
        [Key]

        public int GardenId { get; set; }

        public List<GardenPlant> GardenPlants { get; set; } = new();  // Lista över växter i trädgården






        public int UserId { get; set; } // Främmande nyckel för användarrelation



        [ForeignKey("UserId")] // Anger en främmande nyckelrelation

        public User.User User { get; set; }  // Navigationsegenskap till användaren



        public GardenModel()
        {

        }

        public GardenModel(int gardenId, int userId, List<GardenPlant> gardenPlants) // Konstruktor som tar emot trädgårds-ID, användar-ID och lista över växter
        {
            GardenId = gardenId; // Tilldelar trädgårds-ID
            UserId = userId; // Tilldelar användar-ID
            GardenPlants = gardenPlants; // Tilldelar listan över växter
        }

        public GardenModel(int gardenId, List<GardenPlant> gardenPlants)
        {
            GardenId = gardenId;
            GardenPlants = gardenPlants;
        }
    }
}
