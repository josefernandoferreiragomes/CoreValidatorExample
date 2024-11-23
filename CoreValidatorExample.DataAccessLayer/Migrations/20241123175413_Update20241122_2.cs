using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreValidatorExample.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Update20241122_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appraisals",
                keyColumn: "AppraisalId",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 54, 12, 724, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.UpdateData(
                table: "Appraisals",
                keyColumn: "AppraisalId",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 54, 12, 724, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "DecisionId",
                keyValue: 1,
                column: "DecisionDate",
                value: new DateTime(2024, 11, 23, 17, 54, 12, 724, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "DecisionId",
                keyValue: 2,
                column: "DecisionDate",
                value: new DateTime(2024, 11, 23, 17, 54, 12, 725, DateTimeKind.Local).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "ProposalId",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 54, 12, 718, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "ProposalId",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 54, 12, 724, DateTimeKind.Local).AddTicks(885));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appraisals",
                keyColumn: "AppraisalId",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 50, 18, 955, DateTimeKind.Local).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "Appraisals",
                keyColumn: "AppraisalId",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 50, 18, 955, DateTimeKind.Local).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "DecisionId",
                keyValue: 1,
                column: "DecisionDate",
                value: new DateTime(2024, 11, 23, 17, 50, 18, 956, DateTimeKind.Local).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "DecisionId",
                keyValue: 2,
                column: "DecisionDate",
                value: new DateTime(2024, 11, 23, 17, 50, 18, 956, DateTimeKind.Local).AddTicks(640));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "ProposalId",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 50, 18, 950, DateTimeKind.Local).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "ProposalId",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 50, 18, 955, DateTimeKind.Local).AddTicks(4983));
        }
    }
}
