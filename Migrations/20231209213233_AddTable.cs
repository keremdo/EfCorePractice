using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InstructorName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InstructorSurName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InstructorEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_courseRegistrations_CourseId",
                table: "courseRegistrations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_courseRegistrations_StudentId",
                table: "courseRegistrations",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_courseRegistrations_Courses_CourseId",
                table: "courseRegistrations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_courseRegistrations_Students_StudentId",
                table: "courseRegistrations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courseRegistrations_Courses_CourseId",
                table: "courseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_courseRegistrations_Students_StudentId",
                table: "courseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_courseRegistrations_CourseId",
                table: "courseRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_courseRegistrations_StudentId",
                table: "courseRegistrations");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Courses");
        }
    }
}
