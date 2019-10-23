using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class MinorFixesAndCompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssessment",
                table: "StudentAssessment");

            migrationBuilder.DropIndex(
                name: "IX_StudentAssessment_StudentID",
                table: "StudentAssessment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule");

            migrationBuilder.DropIndex(
                name: "IX_ClassSchedule_ClassID",
                table: "ClassSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_ClassID",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "StudentAssessmentID",
                table: "StudentAssessment");

            migrationBuilder.DropColumn(
                name: "ClassScheduleID",
                table: "ClassSchedule");

            migrationBuilder.DropColumn(
                name: "AttendaneID",
                table: "Attendance");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Term",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "NoteType",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Course",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Assessment",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "ApplicantRating",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssessment",
                table: "StudentAssessment",
                columns: new[] { "StudentID", "AssessnentID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule",
                columns: new[] { "ClassID", "ScheduleID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                columns: new[] { "ClassID", "StudentID", "Date" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssessment",
                table: "StudentAssessment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Term",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentAssessmentID",
                table: "StudentAssessment",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "NoteType",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Course",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "ClassScheduleID",
                table: "ClassSchedule",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "AttendaneID",
                table: "Attendance",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Assessment",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "ApplicantRating",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssessment",
                table: "StudentAssessment",
                column: "StudentAssessmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule",
                column: "ClassScheduleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "AttendaneID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessment_StudentID",
                table: "StudentAssessment",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedule_ClassID",
                table: "ClassSchedule",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ClassID",
                table: "Attendance",
                column: "ClassID");
        }
    }
}
