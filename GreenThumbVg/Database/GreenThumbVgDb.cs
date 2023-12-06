﻿using GreenThumbVg.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumbVg.Database
{
    public class GreenThumbVgDbContext : DbContext
    {



        // Konstruktör för att skapa en instans av kontexten
        public GreenThumbVgDbContext()
        {

        }

        // DbSet för varje entitet som ska ingå i databasen
        public DbSet<GardenModel> Gardens { get; set; }

        public DbSet<PlantModel> Plants { get; set; }

        public DbSet<InstructionModel> Instructions { get; set; }

        public DbSet<GardenPlant> GardenPlants { get; set; }


        // Metod som konfigurerar anslutningssträngen till databasen
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbVgDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GardenPlant>()
               .HasKey(gp => new { gp.GardenId, gp.PlantId }); // Primärnyckel för GardenPlant

            // Konfigurera primärnycklar och relationer mellan tabellerna
            modelBuilder.Entity<GardenPlant>()
                .HasOne(gp => gp.Garden)
                .WithMany(g => g.GardenPlants)
                .HasForeignKey(gp => gp.GardenId);

            modelBuilder.Entity<GardenPlant>()
                .HasOne(gp => gp.Plant)
                .WithMany(p => p.GardenPlants)
                .HasForeignKey(gp => gp.PlantId); 
            

            //nyligen tillagds
            modelBuilder.Entity<InstructionModel>()
    .HasOne(i => i.Plant)
    .WithMany(p => p.Instructions) // En växt kan ha flera instruktioner
    .HasForeignKey(i => i.PlantId); // Foreign key för Plant i InstructionModel

            modelBuilder.Entity<PlantModel>()
        .HasIndex(p => p.NameOfPlant)
        .IsUnique();

            modelBuilder.Entity<PlantModel>().HasData(new PlantModel("Sunflower") { PlantId = 1 },
                                            new PlantModel("Roses") { PlantId = 2 },
                                            new PlantModel("Tulips") { PlantId = 3 });

            modelBuilder.Entity<InstructionModel>().HasData(
       new InstructionModel {
           InstructionId = 1,
           NameOfInstruction = "Vattning",
           Instruction = "Undvik att övervattna eller låta jorden bli för torr. Stick ner fingret i jorden för att känna om den behöver vatten.",
           PlantId = 1 },

       new InstructionModel { 
           InstructionId = 2,
           NameOfInstruction = "Ljus", 
           Instruction = "Placera växter på platser där de får tillräckligt med ljus enligt deras specifika krav.",
           PlantId = 2 },
       new InstructionModel { 
           InstructionId = 3,
           NameOfInstruction = "Jord och Gödsel",
           Instruction = "Placering: Soligt till halvskugga. Bevattning: Måttlig, undvik vattenloggning i jorden.", 
           PlantId = 3 },
       new InstructionModel
       {
           InstructionId = 4,
           NameOfInstruction = "Beskärning",
           Instruction = "Klipp bort döda eller sjuka blad och kvistar för att främja tillväxt och hålla växterna friska. Det kan också bidra till att forma växten på ett snyggt sätt.",
           PlantId = 2
       }
   );

            modelBuilder.Entity<GardenModel>().HasData(
    new GardenModel { GardenId = 1 }, // Lägg till önskade egenskaper för varje trädgård här
    new GardenModel { GardenId = 2 }
    // ... Fortsätt med fler exempel på trädgårdar om det behövs
);

            modelBuilder.Entity<GardenPlant>().HasData(
    new GardenPlant { GardenId = 1, PlantId = 1 }, // Lägg till önskade egenskaper för varje GardenPlant här
    new GardenPlant { GardenId = 2, PlantId = 2 }
    // ... Fortsätt med fler exempel på GardenPlant om det behövs
);




        }
    }
}

