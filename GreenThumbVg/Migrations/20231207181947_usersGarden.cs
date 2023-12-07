using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumbVg.Migrations
{
    /// <inheritdoc />
    public partial class usersGarden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GardenId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GardenId",
                table: "Users");
        }
    }
}
