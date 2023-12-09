

using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using GreenThumbVg.Models;
using GreenThumbVg.User;
using Microsoft.EntityFrameworkCore;

namespace GreenThumbVg.Database
{
    public class GreenThumbVgDbContext : DbContext // Skapar en DbContext-klass för databasåtkomst
    {

        private readonly IEncryptionProvider _provider;


        // Konstruktör för att skapa en instans av kontexten
        public GreenThumbVgDbContext()
        {

            _provider = new GenerateEncryptionProvider(KeyManager.GetEncryptionKey());


        }

        // DbSet för varje entitet som ska ingå i databasen
        public DbSet<User.User> Users { get; set; }

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

            modelBuilder.UseEncryption(_provider);


            // Definierar nycklar och relationer mellan Garden och Plant i GardenPlant-tabellen
            modelBuilder.Entity<GardenPlant>()
                .HasKey(gp => new { gp.GardenId, gp.PlantId });

    

            // Seedar databasen med  data för PlantModel och InstructionModel
            modelBuilder.Entity<PlantModel>().HasData(
                new PlantModel("Sunflower") { PlantId = 1 },
                new PlantModel("Roses") { PlantId = 2 },
                new PlantModel("Tulips") { PlantId = 3 },
                new PlantModel("Lavendel") { PlantId = 4 },
                new PlantModel("Prästkrage") { PlantId = 5 },
                new PlantModel("Pioner") { PlantId = 6 },
                new PlantModel("Orkideer") { PlantId = 7 },
                new PlantModel("Solsikka") { PlantId = 8 },
                new PlantModel("Dahlia") { PlantId = 9 },
                new PlantModel("Fuschia") { PlantId = 10 },
                new PlantModel("Hortensia") { PlantId = 11 },
                new PlantModel("Maskros") { PlantId = 12 }


            );

            // Fördefinierade instruktioner för växter
            modelBuilder.Entity<InstructionModel>().HasData(
                new InstructionModel
                {
                    InstructionId = 1,
                    NameOfInstruction = "Vattning",
                    Instruction = "Undvik att övervattna eller låta jorden bli för torr. Stick ner fingret i jorden för att känna om den behöver vatten.",
                    PlantId = 1
                },

                new InstructionModel
                {
                    InstructionId = 2,
                    NameOfInstruction = "Ljus",
                    Instruction = "Placera växter på platser där de får tillräckligt med ljus enligt deras specifika krav.",
                    PlantId = 2
                },
                new InstructionModel
                {
                    InstructionId = 3,
                    NameOfInstruction = "Jord och Gödsel",
                    Instruction = "Placering: Soligt till halvskugga. Bevattning: Måttlig, undvik vattenloggning i jorden.",
                    PlantId = 3
                },
                new InstructionModel
                {
                    InstructionId = 4,
                    NameOfInstruction = "Beskärning",
                    Instruction = "Klipp bort döda eller sjuka blad och kvistar för att främja tillväxt och hålla växterna friska. Det kan också bidra till att forma växten på ett snyggt sätt.",
                    PlantId = 4
                },
                   new InstructionModel
                   {
                       InstructionId = 5,
                       NameOfInstruction = "Vattning",
                       Instruction = "Vattna regelbundet och se till ordentlig dränering.",
                       PlantId = 5
                   },

                        new InstructionModel
                        {
                            InstructionId = 6,
                            NameOfInstruction = "Sol",
                            Instruction = "Placera i väldränerad jord och delvis solsken.",
                            PlantId = 6
                        },

                            new InstructionModel
                            {
                                InstructionId = 7,
                                NameOfInstruction = "Placering och Jord",
                                Instruction = "Plantera i soligt läge och väldränerad jord.",
                                PlantId = 7
                            },

                                 new InstructionModel
                               {
                                     InstructionId = 8,
                                     NameOfInstruction = "Placera i ljus men undvik direkt solljus.",
                                     Instruction = "Ljus och Skugga",
                                     PlantId = 8
                                 },

                                      new InstructionModel
                                      {
                                          InstructionId = 9,
                                          NameOfInstruction = "Vattna regelbundet och undvik att övervattna.",
                                          Instruction = "Vattning",
                                          PlantId = 9
                                      },




                                      new InstructionModel
                                      {
                                          InstructionId = 10,
                                          NameOfInstruction = "Placera i soligt eller delvis skuggigt läge.",
                                          Instruction = "Ljus och skugga",
                                          PlantId = 10
                                      },

                                           new InstructionModel
                                           {
                                               InstructionId = 11,
                                               NameOfInstruction = "Kräver fuktig jord och undvik direkt solljus.",
                                               Instruction = "Jord och placering",
                                               PlantId = 11
                                           },

                                                      new InstructionModel
                                                      {
                                                          InstructionId = 12,
                                                          NameOfInstruction = "Trivs i sur jord och behöver regelbunden vattning.",
                                                          Instruction = "Jord och Vattning",
                                                          PlantId = 12
                                                      }





            );

            // Seedar databasen med  data för GardenModel och GardenPlant
            modelBuilder.Entity<GardenModel>().HasData(
                new GardenModel { GardenId = 1, UserId = 1 } // Associate with User 1
            );

            modelBuilder.Entity<GardenPlant>().HasData(
                new GardenPlant { GardenId = 1, PlantId = 1 } // Associate with Garden 1
            );

            modelBuilder.Entity<User.User>().HasData(
    new User.User
    {
        Id = 1, // Ange användarens ID här
        Username = "användarnamn", // Användarnamnet för den fördefinierade användaren
        Password = "lösenord", // Lösenordet för den fördefinierade användaren
    }
);



        }
    }
}

