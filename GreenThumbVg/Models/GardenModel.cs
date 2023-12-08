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

        public List<GardenPlant> GardenPlants { get; set; } = new();



  


        public int UserId { get; set; } // Foreign key


        [ForeignKey("UserId")]

        public User.User User { get; set; } // Navigation property



        public GardenModel()
        {

        }

        public GardenModel(int gardenId, int userId, List<GardenPlant> gardenPlants)
        {
            GardenId = gardenId;
            UserId = userId; // Set the UserId here
            GardenPlants = gardenPlants;
        }

        public GardenModel(int gardenId, List<GardenPlant> gardenPlants)
        {
            GardenId = gardenId;
            GardenPlants = gardenPlants;
        }
    }
}
