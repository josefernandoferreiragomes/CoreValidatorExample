using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreValidatorExample.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    ProposalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProponentBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.ProposalId);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loans_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Decisions",
                columns: table => new
                {
                    DecisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Outcome = table.Column<int>(type: "int", nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProposalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decisions", x => x.DecisionId);
                    table.ForeignKey(
                        name: "FK_Decisions_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "ProposalId");
                });

            migrationBuilder.CreateTable(
                name: "Collaterals",
                columns: table => new
                {
                    CollateralId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollateralDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollateralValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaterals", x => x.CollateralId);
                    table.ForeignKey(
                        name: "FK_Collaterals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Collaterals_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Collaterals_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "LoanId");
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CollateralId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Assets_Collaterals_CollateralId",
                        column: x => x.CollateralId,
                        principalTable: "Collaterals",
                        principalColumn: "CollateralId");
                });

            migrationBuilder.CreateTable(
                name: "Appraisals",
                columns: table => new
                {
                    AppraisalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MandatoryField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppraiserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProposalId = table.Column<int>(type: "int", nullable: false),
                    AppraisalScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appraisals", x => x.AppraisalId);
                    table.ForeignKey(
                        name: "FK_Appraisals_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId");
                    table.ForeignKey(
                        name: "FK_Appraisals_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "ProposalId");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerName" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "ProposalId", "Amount", "ProponentBirthDate", "Status", "SubmissionDate", "Title" },
                values: new object[,]
                {
                    { 1, 100000m, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 11, 23, 17, 40, 3, 528, DateTimeKind.Local).AddTicks(81), "Proposal 1" },
                    { 2, 200000m, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 11, 23, 17, 40, 3, 533, DateTimeKind.Local).AddTicks(8657), "Proposal 2" }
                });

            migrationBuilder.InsertData(
                table: "Decisions",
                columns: new[] { "DecisionId", "DecisionDate", "Outcome", "ProposalId", "Reason" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 23, 17, 40, 3, 534, DateTimeKind.Local).AddTicks(3756), 2, 1, "Reason 1" },
                    { 2, new DateTime(2024, 11, 23, 17, 40, 3, 534, DateTimeKind.Local).AddTicks(4271), 3, 2, "Reason 2" }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanId", "CustomerId", "LoanDescription", "LoanValue" },
                values: new object[,]
                {
                    { 1, 1, "Home Loan", 250000m },
                    { 2, 2, "Car Loan", 30000m }
                });

            migrationBuilder.InsertData(
                table: "Collaterals",
                columns: new[] { "CollateralId", "CollateralDescription", "CollateralValue", "CustomerId", "CustomerId1", "LoanId" },
                values: new object[,]
                {
                    { 1, "House", 300000m, 1, null, 1 },
                    { 2, "Car", 35000m, 2, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "AssetName", "AssetValue", "CollateralId" },
                values: new object[,]
                {
                    { 1, "House Asset", 300000m, 1 },
                    { 2, "Car Asset", 35000m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Appraisals",
                columns: new[] { "AppraisalId", "AppraisalScore", "AppraiserName", "AssetId", "MandatoryField", "ProposalId", "Status", "SubmissionDate" },
                values: new object[,]
                {
                    { 1, 85.5m, "Appraiser 1", 1, "Field 1", 1, 1, new DateTime(2024, 11, 23, 17, 40, 3, 534, DateTimeKind.Local).AddTicks(641) },
                    { 2, 90.0m, "Appraiser 2", 2, "Field 2", 2, 2, new DateTime(2024, 11, 23, 17, 40, 3, 534, DateTimeKind.Local).AddTicks(2014) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appraisals_AssetId",
                table: "Appraisals",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Appraisals_ProposalId",
                table: "Appraisals",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CollateralId",
                table: "Assets",
                column: "CollateralId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaterals_CustomerId",
                table: "Collaterals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaterals_CustomerId1",
                table: "Collaterals",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Collaterals_LoanId",
                table: "Collaterals",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Decisions_ProposalId",
                table: "Decisions",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appraisals");

            migrationBuilder.DropTable(
                name: "Decisions");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Collaterals");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
