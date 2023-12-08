using GreenThumbVg.Models;
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


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GardenPlant>()
                .HasKey(gp => new { gp.GardenId, gp.PlantId });


        //    modelBuilder.Entity<GardenPlant>()
        //.HasOne(gp => gp.Garden)
        //.WithMany(g => g.GardenPlants)
        //.HasForeignKey(gp => gp.GardenId);

        //    modelBuilder.Entity<GardenPlant>()
        //        .HasOne(gp => gp.Plant)
        //        .WithMany(p => p.GardenPlants)
        //        .HasForeignKey(gp => gp.PlantId);


            //modelBuilder.Entity<GardenPlant>()
            //    .HasOne(gp => gp.Garden)
            //    .WithMany(g => g.GardenPlants)
            //    .HasForeignKey(gp => gp.GardenId);

            //modelBuilder.Entity<GardenPlant>()
            //    .HasOne(gp => gp.Plant)
            //    .WithMany(p => p.GardenPlants)
            //    .HasForeignKey(gp => gp.PlantId);

            //modelBuilder.Entity<GardenModel>()
            //    .HasOne(g => g.User)
            //    .WithOne(u => u.Garden)
            //    .HasForeignKey<User.User>(u => u.Id);

            //modelBuilder.Entity<InstructionModel>()
            //    .HasOne(i => i.Plant)
            //    .WithMany(p => p.Instructions)
            //    .HasForeignKey(i => i.PlantId);

            //modelBuilder.Entity<PlantModel>()
            //    .HasIndex(p => p.NameOfPlant)
            //    .IsUnique();

            modelBuilder.Entity<PlantModel>().HasData(
                new PlantModel("Sunflower") { PlantId = 1 },
                new PlantModel("Roses") { PlantId = 2 },
                new PlantModel("Tulips") { PlantId = 3 }
            );

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
                    PlantId = 2
                }
            );

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

