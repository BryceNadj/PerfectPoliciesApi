using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfectPoliciesApi.Migrations
{
    public partial class AddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserInfoID);
                });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "QuestionText",
                value: "How do you spell 'Red'?");

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QuizId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 25, 23, 32, 54, 286, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserInfoID", "Password", "Username" },
                values: new object[] { 1, "abc_1234", "Shaun" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "QuestionText",
                value: "How do you spell \"Red\"?");

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QuizId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 29, 1, 16, 24, 440, DateTimeKind.Utc).AddTicks(5613));
        }
    }
}
