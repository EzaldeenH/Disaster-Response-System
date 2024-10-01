using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disaster_Response_System.Migrations
{
    /// <inheritdoc />
    public partial class updatedDonor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactInformation",
                table: "Donors");

            migrationBuilder.AlterColumn<string>(
                name: "Organization",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Organization",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactInformation",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
