using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disaster_Response_System.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AffectedIndividuals");

            migrationBuilder.DropTable(
                name: "FinancialTransactions");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "RequestEvaluations");

            migrationBuilder.DropTable(
                name: "RequestItems");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "DonationPurpose",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "DonationType",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "EstimatedValue",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "ItemDescription",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "Requests",
                newName: "SubmissionDate");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Requests",
                newName: "ApplicantName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Requests",
                newName: "ApplicantContact");

            migrationBuilder.AddColumn<decimal>(
                name: "EvaluationScore",
                table: "Requests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "RoundID",
                table: "Requests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<decimal>(
                name: "DonationAmount",
                table: "Donations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoundID",
                table: "Donations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoundName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoundStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RoundID",
                table: "Requests",
                column: "RoundID");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_RoundID",
                table: "Donations",
                column: "RoundID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Rounds_RoundID",
                table: "Donations",
                column: "RoundID",
                principalTable: "Rounds",
                principalColumn: "RoundID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Rounds_RoundID",
                table: "Requests",
                column: "RoundID",
                principalTable: "Rounds",
                principalColumn: "RoundID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Rounds_RoundID",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Rounds_RoundID",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RoundID",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Donations_RoundID",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "EvaluationScore",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RoundID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RoundID",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "SubmissionDate",
                table: "Requests",
                newName: "RequestDate");

            migrationBuilder.RenameColumn(
                name: "ApplicantName",
                table: "Requests",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "ApplicantContact",
                table: "Requests",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Donors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<decimal>(
                name: "DonationAmount",
                table: "Donations",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "DonationPurpose",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DonationType",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedValue",
                table: "Donations",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Donations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AffectedIndividuals",
                columns: table => new
                {
                    AffectedIndividualID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffectedIndividuals", x => x.AffectedIndividualID);
                    table.ForeignKey(
                        name: "FK_AffectedIndividuals_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialTransactions",
                columns: table => new
                {
                    FinancialTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialTransactions", x => x.FinancialTransactionID);
                    table.ForeignKey(
                        name: "FK_FinancialTransactions_Donors_DonorID",
                        column: x => x.DonorID,
                        principalTable: "Donors",
                        principalColumn: "DonorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    InventoryItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.InventoryItemID);
                });

            migrationBuilder.CreateTable(
                name: "RequestEvaluations",
                columns: table => new
                {
                    RequestEvaluationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvaluatorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImpactScore = table.Column<int>(type: "int", nullable: false),
                    NeedScore = table.Column<int>(type: "int", nullable: false),
                    ResourceAvailabilityScore = table.Column<int>(type: "int", nullable: false),
                    UrgencyScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestEvaluations", x => x.RequestEvaluationID);
                    table.ForeignKey(
                        name: "FK_RequestEvaluations_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestItems",
                columns: table => new
                {
                    RequestItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestItems", x => x.RequestItemID);
                    table.ForeignKey(
                        name: "FK_RequestItems_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AffectedIndividuals_RequestID",
                table: "AffectedIndividuals",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_DonorID",
                table: "FinancialTransactions",
                column: "DonorID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestEvaluations_RequestID",
                table: "RequestEvaluations",
                column: "RequestID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestItems_RequestID",
                table: "RequestItems",
                column: "RequestID");
        }
    }
}
