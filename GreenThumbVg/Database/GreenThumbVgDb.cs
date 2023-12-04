using GreenThumbVg.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumbVg.Database
{
    public class GreenThumbVgDbContext : DbContext
    {

        public GreenThumbVgDbContext()
        {

        }

        public DbSet<PlantModel> Plants { get; set; }

        public DbSet<InstructionModel> Instructions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbVgDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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


            //modelBuilder.Entity<InstructionModel>()
            //         .HasData(new InstructionModel()
            //         {
            //             InstructionId = 1,
            //             NameOfInstruction = "Vattning",
            //             Instruction = " Undvik att övervattna eller låta jorden bli för torr. Anpassa vattningen efter växtens behov och jordens fuktighet. Stick ner fingret i jorden för att känna om den behöver vatten.",
            //             PlantId = 1


            //         },
            //         new InstructionModel()
            //         {
            //             InstructionId = 2,
            //             NameOfInstruction = "Ljus",
            //             Instruction = "Placera växter på platser där de får tillräckligt med ljus enligt deras specifika krav. Vissa behöver direkt solljus medan andra trivs bättre i skugga.",
            //             PlantId = 2


            //         },

            //            new InstructionModel()
            //            {
            //                InstructionId = 3,
            //                NameOfInstruction = "Skötselråd:",
            //                Instruction = "Placering: Soligt till halvskugga. Bevattning: Måttlig, undvik vattenloggning i jorden. Efter blomning: Klipp av blomstjälken och låt löken vila för nästa säsong.",
            //                PlantId = 3


            //            }

            //         );

        }
    }
}









//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            modelBuilder.Entity<PlantModel>()
//        .HasIndex(p => p.NameOfPlant)
//        .IsUnique();

//            //modelBuilder.Entity<PlantModel>()
//            //          .HasData(new PlantModel()
//            //          {
//            //              PlantId = 1,
//            //              NameOfPlant = "Sunflower",


//            //          },

//            //          new PlantModel()
//            //          {
//            //              PlantId = 2,
//            //              NameOfPlant = "Roses"
//            //          },
//            //             new PlantModel()
//            //             {
//            //                 PlantId = 3,
//            //                 NameOfPlant = "Tulips"
//            //             }

//            //          );


//            modelBuilder.Entity<InstructionModel>()
//                     .HasData(new InstructionModel()
//                     {
//                         InstructionId = 1,
//                         NameOfInstruction = "Vattning",
//                         Instruction = "Placering: Soligt läge med direkt solljus. Bevattning: Regelbunden, särskilt under torra perioder. Jorden: Väldränerad och näringsrik jord.",
//                         PlantId = 1


//                     },
//                     new InstructionModel()
//                     {
//                         InstructionId = 2,
//                         NameOfInstruction = "Skötselråd:",
//                         Instruction = "Placering: Soligt läge. Bevattning: Regelbunden, undvik blöta blad. Beskärning: Ta bort döda eller skadade grenar regelbundet.",
//                         PlantId = 2


//                     },

//                        new InstructionModel()
//                        {
//                            InstructionId = 3,
//                            NameOfInstruction = "Skötselråd:",
//                            Instruction = "Placering: Soligt till halvskugga. Bevattning: Måttlig, undvik vattenloggning i jorden. Efter blomning: Klipp av blomstjälken och låt löken vila för nästa säsong.",
//                            PlantId = 3


//                        }

//                     );

//        }
//    }
//}

