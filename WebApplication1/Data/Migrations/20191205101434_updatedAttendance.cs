using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class updatedAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Class_ClassID",
                table: "Attendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_StudentID",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "TimeOut",
                table: "Attendance");

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Attendance",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                columns: new[] { "StudentID", "Date" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Attendance");

            migrationBuilder.AddColumn<int>(
                name: "ClassID",
                table: "Attendance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOut",
                table: "Attendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                columns: new[] { "ClassID", "StudentID", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_StudentID",
                table: "Attendance",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Class_ClassID",
                table: "Attendance",
                column: "ClassID",
                principalTable: "Class",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
