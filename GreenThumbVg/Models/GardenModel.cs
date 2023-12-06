using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


    }
}
