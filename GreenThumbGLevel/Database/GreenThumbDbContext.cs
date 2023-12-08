using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using GreenThumbGLevel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbGLevel.Database
{
    public class GreenThumbDbContext : DbContext
    {
    
        public GreenThumbDbContext()
        {
 
        }

        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Plant> Plants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbGLevel;Trusted_Connection=True;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeda data
            modelBuilder.
                Entity<Plant>()
                .HasData(
    new Plant()
    {
        //källa: https://www.plantagen.se/vit-papegojblomma-hojd-140-cm-gron-547499.html
        PlantName = "Vit Papegojblomma",
        PlantDescription = "Stor och vacker planta med stora gröna blad som växer i solfjäderform.",
        PlantOrigin = "Danmark"
    },
    new Plant()
    {
        //Källa: https://www.plantagen.se/monstera-hojd-70-cm-gron-521144.html
        PlantName = "Monstera",
        PlantDescription = "Mycket lättskött och populär planta med stora, blanka, gröna blad och långa luftrötter.",
        PlantOrigin = "Nederländerna"
    },
    new Plant()
    {
        //källa: https://www.plantagen.se/guldpalm-hojd-120-cm-gron-520896.html
        PlantName = "Guldpalm",
        PlantDescription = "Frodig, lättskött och populär palm med vackra blad som ger inredningen en tropisk touch.",
        PlantOrigin = "Danmark"
    },
    new Plant()
    {
        //källa https://www.plantagen.se/fiolfikus-hojd-100-cm-gron-530535.html
        PlantName = "Fiolfikus",
        PlantDescription = "Trendig växt med fiolformade, glänsande, stora blad. En populär och lättskött planta som trivs i ljusa förhållanden, undvik direkt solljus.",
        PlantOrigin = "Danmark"
    });

            //Seedar Instruktioner till
            //seedar utan instruktioner för Monstera för att kolla om 1-M fungerar som det ska.Därav har monstera inga instruktioner.
            modelBuilder.Entity<Instruction>().HasData(
               new Instruction()
               {
                   InstructionId = 1,
                   Description = "undvik direkt solljus",
                   PlantName = "Fiolfikus",
               },
               new Instruction()
               {
                   InstructionId = 2,
                   Description = "Låt den torka lätt mellan vattningarna för att undvika rotröta.",
                   PlantName = "Fiolfikus",
               },
               new Instruction()
               {
                   InstructionId = 3,
                   Description = "Duscha den gärna regelbundet på bladen för att bibehålla hög luftfuktighet",
                   PlantName = "Fiolfikus",
               },
               new Instruction()
               {
                   InstructionId = 4,
                   Description = "Guldpalmen trivs i omgivningar utan direkt solljus.",
                   PlantName = "Guldpalm",
               },
               new Instruction()
               {
                   InstructionId = 5,
                   Description = "Under vinterhalvåret behöver den mindre näring.",
                   PlantName = "Guldpalm",
               },
               new Instruction()
               {
                   InstructionId = 6,
                   Description = "Sätt gärna ut på den på balkongen eller terrassen om sommaren i skuggan.",
                   PlantName = "Guldpalm",
               },
               new Instruction()
               {
                   InstructionId = 7,
                   Description = "Papegojblomma trivs i miljöer med god tillgång till ljus",
                   PlantName = "Vit Papegojblomma",
               },
               new Instruction()
               {
                   InstructionId = 8,
                   Description = "Undvik direkt solljus som kan bränna bladen.",
                   PlantName = "Vit Papegojblomma",
               },
               new Instruction()
               {
                   InstructionId = 9,
                   Description = "Låt den torka lätt mellan vattningarna, men duscha den gärna ofta på bladen för att bibehålla hög luftfuktighet. ",
                   PlantName = "Vit Papegojblomma",
               });
            //------------------------------------------------------//

        }
    }
}
