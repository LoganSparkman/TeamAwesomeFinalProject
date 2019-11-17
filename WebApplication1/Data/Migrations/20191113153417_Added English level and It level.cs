using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class AddedEnglishlevelandItlevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_Schedule_ScheduleID",
                table: "StudentClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass");

            migrationBuilder.DropIndex(
                name: "IX_StudentClass_ScheduleID",
                table: "StudentClass");

            migrationBuilder.DropColumn(
                name: "ScheduleID",
                table: "StudentClass");

            migrationBuilder.AddColumn<short>(
                name: "EnglishLevel",
                table: "Student",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "ITLevel",
                table: "Student",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass",
                columns: new[] { "ClassID", "StudentID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass");

            migrationBuilder.DropColumn(
                name: "EnglishLevel",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ITLevel",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleID",
                table: "StudentClass",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass",
                columns: new[] { "ClassID", "StudentID", "ScheduleID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_ScheduleID",
                table: "StudentClass",
                column: "ScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_Schedule_ScheduleID",
                table: "StudentClass",
                column: "ScheduleID",
                principalTable: "Schedule",
                principalColumn: "ScheduleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
