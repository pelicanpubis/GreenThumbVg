using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbVg.Migrations
{
    public partial class maskros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 12,
                column: "NameOfPlant",
                value: "Maskros");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "Password",
                value: "q52AHJxFaoKjrpR57MFWAQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 12,
                column: "NameOfPlant",
                value: "Solsikka");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "Password",
                value: "q52AHJxFaoKjrpR57MFWAQ==");
        }
    }
}
