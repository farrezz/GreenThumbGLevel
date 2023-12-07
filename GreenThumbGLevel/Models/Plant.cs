using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbGLevel.Models
{
    public class Plant
    {
        //En planta har flera instruktioner - En instruktion har en planta
        //En Instruktion tillhör en planta, och en planta har flera Instruktioner. 
        //En planta tillhör till en Garden, och en Garden har flera plantor.
        //1-M

        //PlantName är Key då det kan underlätta att det inte blir dubletter när man skriver namnen på plantan.
        [Key]
        public string PlantName { get; set; } = null!;
        //En kort beskrivning om plantan.
        public string? PlantDescription { get; set; }
        //Plantans Urpsrung. 
        public string? PlantOrigin { get; set; }

        //En planta flera instruktioner
        public List<Instruction> Instruction { get; set; } = new();
    }
}
