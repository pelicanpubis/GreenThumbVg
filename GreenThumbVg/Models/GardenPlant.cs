using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbVg.Models
{ //many to many
   public class GardenPlant // En klass som representerar en koppling mellan trädgård och växt
    {
        public int GardenId { get; set; }  // Egenskap för trädgårds-ID
        public GardenModel Garden { get; set; }  // Navigationsegenskap för trädgård

        public int PlantId { get; set; }
        public PlantModel Plant { get; set; }

        public GardenPlant()
        {
            
        }

        public GardenPlant(int gardenId, GardenModel garden, int plantId, PlantModel plant)
        {
            GardenId = gardenId;
            Garden = garden;
            PlantId = plantId;
            Plant = plant;
        }
    }
}
