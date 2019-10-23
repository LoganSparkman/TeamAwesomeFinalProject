using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class AddedRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RatingCriterium",
                columns: table => new
                {
                    RatingCriteriumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    MaxScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingCriterium", x => x.RatingCriteriumID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantRating",
                columns: table => new
                {
                    ApplicantRatingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScoreAssigned = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true),
                    StudentID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    RatingCriteriumID = table.Column<int>(nullable: false),
                    TermID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantRating", x => x.ApplicantRatingID);
                    table.ForeignKey(
                        name: "FK_ApplicantRating_RatingCriterium_RatingCriteriumID",
                        column: x => x.RatingCriteriumID,
                        principalTable: "RatingCriterium",
                        principalColumn: "RatingCriteriumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantRating_StudentStatus_StudentID",
                        column: x => x.StudentID,
                        principalTable: "StudentStatus",
                        principalColumn: "StudentStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantRating_Term_TermID",
                        column: x => x.TermID,
                        principalTable: "Term",
                        principalColumn: "TermID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantRating_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantRating_RatingCriteriumID",
                table: "ApplicantRating",
                column: "RatingCriteriumID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantRating_StudentID",
                table: "ApplicantRating",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantRating_TermID",
                table: "ApplicantRating",
                column: "TermID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantRating_UserID",
                table: "ApplicantRating",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantRating");

            migrationBuilder.DropTable(
                name: "RatingCriterium");
        }
    }
}
