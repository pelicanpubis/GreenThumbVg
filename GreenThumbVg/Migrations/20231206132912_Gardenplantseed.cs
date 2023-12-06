using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenThumbVg.Migrations
{
    /// <inheritdoc />
    public partial class Gardenplantseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GardenPlants",
                columns: new[] { "GardenId", "PlantId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GardenPlants",
                keyColumns: new[] { "GardenId", "PlantId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GardenPlants",
                keyColumns: new[] { "GardenId", "PlantId" },
                keyValues: new object[] { 2, 2 });
        }
    }
}
