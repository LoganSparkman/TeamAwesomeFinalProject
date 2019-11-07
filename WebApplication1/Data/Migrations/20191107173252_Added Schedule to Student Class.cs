using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class AddedScheduletoStudentClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass",
                columns: new[] { "ClassID", "StudentID" });
        }
    }
}
