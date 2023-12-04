using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbVg.Models
{
    public class InstructionModel
    {
        [Key]
        public int InstructionId { get; set; }

        public string? NameOfInstruction { get; set; }
        public string Instruction { get; set; } = null!;

        public int PlantId { get; set; }
        public PlantModel Plant { get; set; } = null!;
    }
}
