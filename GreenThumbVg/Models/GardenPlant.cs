using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbVg.Models
{
   public class GardenPlant
    {
        public int GardenId { get; set; }
        public GardenModel Garden { get; set; }

        public int PlantId { get; set; }
        public PlantModel Plant { get; set; }

     
    }
}
