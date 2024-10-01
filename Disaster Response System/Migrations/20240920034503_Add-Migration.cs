using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disaster_Response_System.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequestItems_RequestID",
                table: "RequestItems");

            migrationBuilder.DropIndex(
                name: "IX_RequestEvaluations_RequestID",
                table: "RequestEvaluations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_DonorID",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_AffectedIndividuals_RequestID",
                table: "AffectedIndividuals");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_RequestID",
                table: "RequestItems",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestEvaluations_RequestID",
                table: "RequestEvaluations",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonorID",
                table: "Donations",
                column: "DonorID");

            migrationBuilder.CreateIndex(
                name: "IX_AffectedIndividuals_RequestID",
                table: "AffectedIndividuals",
                column: "RequestID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequestItems_RequestID",
                table: "RequestItems");

            migrationBuilder.DropIndex(
                name: "IX_RequestEvaluations_RequestID",
                table: "RequestEvaluations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_DonorID",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_AffectedIndividuals_RequestID",
                table: "AffectedIndividuals");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_RequestID",
                table: "RequestItems",
                column: "RequestID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestEvaluations_RequestID",
                table: "RequestEvaluations",
                column: "RequestID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonorID",
                table: "Donations",
                column: "DonorID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AffectedIndividuals_RequestID",
                table: "AffectedIndividuals",
                column: "RequestID",
                unique: true);
        }
    }
}
