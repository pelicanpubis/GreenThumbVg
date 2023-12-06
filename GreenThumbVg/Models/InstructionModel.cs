using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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

        // Egenskap för växtens ID kopplat till denna instruktion
        public int PlantId { get; set; } 
        public PlantModel Plant { get; set; } = null!;

        public InstructionModel()
        {
            
        }

        public InstructionModel(int instructionId, string nameOfInstruction, string instruction, int plantId, PlantModel plant)
        {
            InstructionId = instructionId;
            NameOfInstruction = nameOfInstruction;
            Instruction = instruction;
            PlantId = plantId;
            Plant = plant;
        }

        //kanske ha en metod som retunerar name och instruction som en string
        public override string ToString()
        {
            return $"{Plant} - {Instruction}";
        }
    }
}
