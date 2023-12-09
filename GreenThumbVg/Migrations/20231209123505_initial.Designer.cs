﻿// <auto-generated />
using GreenThumbVg.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenThumbVg.Migrations
{
    [DbContext(typeof(GreenThumbVgDbContext))]
    [Migration("20231209123505_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GreenThumbVg.Models.GardenModel", b =>
                {
                    b.Property<int>("GardenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GardenId"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GardenId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Gardens");

                    b.HasData(
                        new
                        {
                            GardenId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("GreenThumbVg.Models.GardenPlant", b =>
                {
                    b.Property<int>("GardenId")
                        .HasColumnType("int");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.HasKey("GardenId", "PlantId");

                    b.HasIndex("PlantId");

                    b.ToTable("GardenPlants");

                    b.HasData(
                        new
                        {
                            GardenId = 1,
                            PlantId = 1
                        });
                });

            modelBuilder.Entity("GreenThumbVg.Models.InstructionModel", b =>
                {
                    b.Property<int>("InstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructionId"), 1L, 1);

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfInstruction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.HasKey("InstructionId");

                    b.HasIndex("PlantId");

                    b.ToTable("Instructions");

                    b.HasData(
                        new
                        {
                            InstructionId = 1,
                            Instruction = "Undvik att övervattna eller låta jorden bli för torr. Stick ner fingret i jorden för att känna om den behöver vatten.",
                            NameOfInstruction = "Vattning",
                            PlantId = 1
                        },
                        new
                        {
                            InstructionId = 2,
                            Instruction = "Placera växter på platser där de får tillräckligt med ljus enligt deras specifika krav.",
                            NameOfInstruction = "Ljus",
                            PlantId = 2
                        },
                        new
                        {
                            InstructionId = 3,
                            Instruction = "Placering: Soligt till halvskugga. Bevattning: Måttlig, undvik vattenloggning i jorden.",
                            NameOfInstruction = "Jord och Gödsel",
                            PlantId = 3
                        },
                        new
                        {
                            InstructionId = 4,
                            Instruction = "Klipp bort döda eller sjuka blad och kvistar för att främja tillväxt och hålla växterna friska. Det kan också bidra till att forma växten på ett snyggt sätt.",
                            NameOfInstruction = "Beskärning",
                            PlantId = 2
                        });
                });

            modelBuilder.Entity("GreenThumbVg.Models.PlantModel", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantId"), 1L, 1);

                    b.Property<string>("NameOfPlant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlantId");

                    b.ToTable("Plants");

                    b.HasData(
                        new
                        {
                            PlantId = 1,
                            NameOfPlant = "Sunflower"
                        },
                        new
                        {
                            PlantId = 2,
                            NameOfPlant = "Roses"
                        },
                        new
                        {
                            PlantId = 3,
                            NameOfPlant = "Tulips"
                        });
                });

            modelBuilder.Entity("GreenThumbVg.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "q52AHJxFaoKjrpR57MFWAQ==",
                            Username = "användarnamn"
                        });
                });

            modelBuilder.Entity("GreenThumbVg.Models.GardenModel", b =>
                {
                    b.HasOne("GreenThumbVg.User.User", "User")
                        .WithOne("Garden")
                        .HasForeignKey("GreenThumbVg.Models.GardenModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenThumbVg.Models.GardenPlant", b =>
                {
                    b.HasOne("GreenThumbVg.Models.GardenModel", "Garden")
                        .WithMany("GardenPlants")
                        .HasForeignKey("GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenThumbVg.Models.PlantModel", "Plant")
                        .WithMany("GardenPlants")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garden");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumbVg.Models.InstructionModel", b =>
                {
                    b.HasOne("GreenThumbVg.Models.PlantModel", "Plant")
                        .WithMany("Instructions")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumbVg.Models.GardenModel", b =>
                {
                    b.Navigation("GardenPlants");
                });

            modelBuilder.Entity("GreenThumbVg.Models.PlantModel", b =>
                {
                    b.Navigation("GardenPlants");

                    b.Navigation("Instructions");
                });

            modelBuilder.Entity("GreenThumbVg.User.User", b =>
                {
                    b.Navigation("Garden")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}