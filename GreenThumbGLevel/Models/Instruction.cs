using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbGLevel.Models
{
    public class Instruction
    {
        [Key]
        public int InstructionId { get; set; }
        //Skötselråd
        public string? Description{ get; set; }
        [ForeignKey(nameof(Plant))]
        public string PlantName { get; set; } = null!;
        public Plant Plant { get; set; } = null!;
    }
}

