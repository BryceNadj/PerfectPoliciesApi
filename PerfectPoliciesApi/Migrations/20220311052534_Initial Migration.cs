using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfectPoliciesApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassingGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.QuizId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_Option_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Quiz",
                columns: new[] { "QuizId", "Author", "DateCreated", "PassingGrade", "Title", "Topic" },
                values: new object[] { 1, "Me", new DateTime(2022, 3, 11, 5, 25, 34, 556, DateTimeKind.Utc).AddTicks(2711), 5, "BeetleJuice", "English" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Image", "QuestionText", "QuizId", "Topic" },
                values: new object[] { 1, null, "How do you spell \"Red\"?", 1, "English" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Image", "QuestionText", "QuizId", "Topic" },
                values: new object[] { 2, null, "What colour is a carrot?", 1, "English" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "OptionId", "IsCorrect", "OptionText", "Order", "QuestionId" },
                values: new object[,]
                {
                    { 1, false, "L-S-T-E-R", "A", 1 },
                    { 2, false, "16", "B", 1 },
                    { 3, true, "R-E-D", "C", 1 },
                    { 4, false, "Purple", "A", 2 },
                    { 5, true, "Orange", "B", 2 },
                    { 6, false, "Pineapple", "C", 2 },
                    { 7, false, "I don't know", "D", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Option_QuestionId",
                table: "Option",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quiz");
        }
    }
}
