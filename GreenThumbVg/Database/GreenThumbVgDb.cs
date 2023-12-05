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

    //        //kanske onödig
    //        modelBuilder.Entity<InstructionModel>()
    //.HasOne(i => i.Plant)
    //.WithMany(p => p.Instructions)
    //.HasForeignKey(i => i.PlantId);

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



        }
    }
}

