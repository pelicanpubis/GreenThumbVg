using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbVg.Migrations
{
    public partial class flerblommor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "Instruction", "NameOfInstruction", "PlantId" },
                values: new object[,]
                {
                    { 5, "Vattna regelbundet och se till ordentlig dränering.", "Vattning", 5 },
                    { 6, "Placera i väldränerad jord och delvis solsken.", "Sol", 6 },
                    { 7, "Plantera i soligt läge och väldränerad jord.", "Placering och Jord", 7 },
                    { 8, "Ljus och Skugga", "Placera i ljus men undvik direkt solljus.", 8 }
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "NameOfPlant" },
                values: new object[,]
                {
                    { 9, "Dahlia" },
                    { 10, "Fuschia" },
                    { 11, "Hortensia" },
                    { 12, "Solsikka" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "Password",
                value: "q52AHJxFaoKjrpR57MFWAQ==");

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "Instruction", "NameOfInstruction", "PlantId" },
                values: new object[,]
                {
                    { 9, "Vattning", "Vattna regelbundet och undvik att övervattna.", 9 },
                    { 10, "Ljus och skugga", "Placera i soligt eller delvis skuggigt läge.", 10 },
                    { 11, "Jord och placering", "Kräver fuktig jord och undvik direkt solljus.", 11 },
                    { 12, "Jord och Vattning", "Trivs i sur jord och behöver regelbunden vattning.", 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "Password",
                value: "q52AHJxFaoKjrpR57MFWAQ==");
        }
    }
}
