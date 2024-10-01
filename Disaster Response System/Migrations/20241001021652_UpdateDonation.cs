using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disaster_Response_System.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDonation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Rounds_RoundID",
                table: "Donations");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoundID",
                table: "Donations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Rounds_RoundID",
                table: "Donations",
                column: "RoundID",
                principalTable: "Rounds",
                principalColumn: "RoundID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Rounds_RoundID",
                table: "Donations");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoundID",
                table: "Donations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Rounds_RoundID",
                table: "Donations",
                column: "RoundID",
                principalTable: "Rounds",
                principalColumn: "RoundID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
