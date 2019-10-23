using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class AddfirstCompositeKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass");

            migrationBuilder.DropIndex(
                name: "IX_StudentClass_ClassID",
                table: "StudentClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassInstructor",
                table: "ClassInstructor");

            migrationBuilder.DropIndex(
                name: "IX_ClassInstructor_ClassID",
                table: "ClassInstructor");

            migrationBuilder.DropColumn(
                name: "StudentClassID",
                table: "StudentClass");

            migrationBuilder.DropColumn(
                name: "ClassInstructorID",
                table: "ClassInstructor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass",
                columns: new[] { "ClassID", "StudentID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassInstructor",
                table: "ClassInstructor",
                columns: new[] { "ClassID", "UserID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassInstructor",
                table: "ClassInstructor");

            migrationBuilder.AddColumn<int>(
                name: "StudentClassID",
                table: "StudentClass",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ClassInstructorID",
                table: "ClassInstructor",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass",
                column: "StudentClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassInstructor",
                table: "ClassInstructor",
                column: "ClassInstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_ClassID",
                table: "StudentClass",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassInstructor_ClassID",
                table: "ClassInstructor",
                column: "ClassID");
        }
    }
}
