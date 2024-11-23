using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreValidatorExample.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Update20241122 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appraisals",
                keyColumn: "AppraisalId",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 40, 3, 534, DateTimeKind.Local).AddTicks(641));

            migrationBuilder.UpdateData(
                table: "Appraisals",
                keyColumn: "AppraisalId",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 40, 3, 534, DateTimeKind.Local).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "DecisionId",
                keyValue: 1,
                column: "DecisionDate",
                value: new DateTime(2024, 11, 23, 17, 40, 3, 534, DateTimeKind.Local).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "DecisionId",
                keyValue: 2,
                column: "DecisionDate",
                value: new DateTime(2024, 11, 23, 17, 40, 3, 534, DateTimeKind.Local).AddTicks(4271));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "ProposalId",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 40, 3, 528, DateTimeKind.Local).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "ProposalId",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2024, 11, 23, 17, 40, 3, 533, DateTimeKind.Local).AddTicks(8657));
        }
    }
}
