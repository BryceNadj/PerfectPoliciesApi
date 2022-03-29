using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfectPoliciesApi.Migrations
{
    public partial class FinishControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QuizId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 29, 1, 16, 24, 440, DateTimeKind.Utc).AddTicks(5613));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QuizId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 11, 7, 0, 58, 456, DateTimeKind.Utc).AddTicks(1968));
        }
    }
}
