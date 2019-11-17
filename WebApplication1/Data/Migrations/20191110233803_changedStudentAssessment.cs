using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class changedStudentAssessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssessment_Assessment_AssessmentID",
                table: "StudentAssessment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssessment",
                table: "StudentAssessment");

            migrationBuilder.DropColumn(
                name: "AssessnentID",
                table: "StudentAssessment");

            migrationBuilder.AlterColumn<int>(
                name: "AssessmentID",
                table: "StudentAssessment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssessment",
                table: "StudentAssessment",
                columns: new[] { "StudentID", "AssessmentID" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssessment_Assessment_AssessmentID",
                table: "StudentAssessment",
                column: "AssessmentID",
                principalTable: "Assessment",
                principalColumn: "AssessmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssessment_Assessment_AssessmentID",
                table: "StudentAssessment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssessment",
                table: "StudentAssessment");

            migrationBuilder.AlterColumn<int>(
                name: "AssessmentID",
                table: "StudentAssessment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AssessnentID",
                table: "StudentAssessment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssessment",
                table: "StudentAssessment",
                columns: new[] { "StudentID", "AssessnentID" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssessment_Assessment_AssessmentID",
                table: "StudentAssessment",
                column: "AssessmentID",
                principalTable: "Assessment",
                principalColumn: "AssessmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
