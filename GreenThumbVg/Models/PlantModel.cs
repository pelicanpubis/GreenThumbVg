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

       public List<InstructionModel> Instructions { get; set; } = new();

      //  public List<PlantInstructionModel> PlantInstructions { get; set; } = new();



        public PlantModel(string nameOfPlant)
        {
            NameOfPlant = nameOfPlant;
        }

    }
}
