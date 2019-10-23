using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class Assessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assessment",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 50000, nullable: true),
                    PointsPossible = table.Column<int>(nullable: false),
                    ClassID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessment", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK_Assessment_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssessment",
                columns: table => new
                {
                    StudentAssessmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PointsAwarded = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 5000, nullable: true),
                    AssessnentID = table.Column<int>(nullable: false),
                    AssessmentID = table.Column<int>(nullable: true),
                    StudentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssessment", x => x.StudentAssessmentID);
                    table.ForeignKey(
                        name: "FK_StudentAssessment_Assessment_AssessmentID",
                        column: x => x.AssessmentID,
                        principalTable: "Assessment",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAssessment_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_ClassID",
                table: "Assessment",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessment_AssessmentID",
                table: "StudentAssessment",
                column: "AssessmentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessment_StudentID",
                table: "StudentAssessment",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssessment");

            migrationBuilder.DropTable(
                name: "Assessment");
        }
    }
}
