using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disaster_Response_System.Migrations
{
    /// <inheritdoc />
    public partial class updatedRound : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoundStatus",
                table: "Rounds");

            migrationBuilder.AddColumn<bool>(
                name: "RoundActive",
                table: "Rounds",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoundActive",
                table: "Rounds");

            migrationBuilder.AddColumn<string>(
                name: "RoundStatus",
                table: "Rounds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
