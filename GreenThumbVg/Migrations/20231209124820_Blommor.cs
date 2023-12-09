using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbVg.Migrations
{
    public partial class Blommor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "NameOfPlant" },
                values: new object[,]
                {
                    { 4, "Lavendel" },
                    { 5, "Prästkrage" },
                    { 6, "Pioner" },
                    { 7, "Orkideer" },
                    { 8, "Solsikka" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "Password",
                value: "q52AHJxFaoKjrpR57MFWAQ==");

            migrationBuilder.UpdateData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 4,
                column: "PlantId",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 4,
                column: "PlantId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "Password",
                value: "q52AHJxFaoKjrpR57MFWAQ==");
        }
    }
}
