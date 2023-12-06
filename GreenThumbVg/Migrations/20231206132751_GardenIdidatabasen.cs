using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbVg.Migrations
{
    /// <inheritdoc />
    public partial class GardenIdidatabasen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gardens",
                column: "GardenId",
                values: new object[]
                {
                    1,
                    2
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gardens",
                keyColumn: "GardenId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gardens",
                keyColumn: "GardenId",
                keyValue: 2);
        }
    }
}
