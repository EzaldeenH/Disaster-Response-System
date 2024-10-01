using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disaster_Response_System.Migrations
{
    /// <inheritdoc />
    public partial class AddMigratonDBUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequestEvaluations_RequestID",
                table: "RequestEvaluations");

            migrationBuilder.CreateIndex(
                name: "IX_RequestEvaluations_RequestID",
                table: "RequestEvaluations",
                column: "RequestID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequestEvaluations_RequestID",
                table: "RequestEvaluations");

            migrationBuilder.CreateIndex(
                name: "IX_RequestEvaluations_RequestID",
                table: "RequestEvaluations",
                column: "RequestID");
        }
    }
}
