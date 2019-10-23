using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class Schedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<short>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "StudentPublicSchoolClass",
                columns: table => new
                {
                    StudentPublicSchoolClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(maxLength: 500, nullable: true),
                    StudentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPublicSchoolClass", x => x.StudentPublicSchoolClassID);
                    table.ForeignKey(
                        name: "FK_StudentPublicSchoolClass_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSchedule",
                columns: table => new
                {
                    ClassScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassID = table.Column<int>(nullable: false),
                    ScheduleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSchedule", x => x.ClassScheduleID);
                    table.ForeignKey(
                        name: "FK_ClassSchedule_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSchedule_Schedule_ScheduleID",
                        column: x => x.ScheduleID,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicSchoolClassSchedule",
                columns: table => new
                {
                    PublicSchoolClassScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentPublicSchoolClassID = table.Column<int>(nullable: false),
                    ScheduleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSchoolClassSchedule", x => x.PublicSchoolClassScheduleID);
                    table.ForeignKey(
                        name: "FK_PublicSchoolClassSchedule_Schedule_ScheduleID",
                        column: x => x.ScheduleID,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicSchoolClassSchedule_StudentPublicSchoolClass_StudentPublicSchoolClassID",
                        column: x => x.StudentPublicSchoolClassID,
                        principalTable: "StudentPublicSchoolClass",
                        principalColumn: "StudentPublicSchoolClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedule_ClassID",
                table: "ClassSchedule",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedule_ScheduleID",
                table: "ClassSchedule",
                column: "ScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_PublicSchoolClassSchedule_ScheduleID",
                table: "PublicSchoolClassSchedule",
                column: "ScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_PublicSchoolClassSchedule_StudentPublicSchoolClassID",
                table: "PublicSchoolClassSchedule",
                column: "StudentPublicSchoolClassID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPublicSchoolClass_StudentID",
                table: "StudentPublicSchoolClass",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassSchedule");

            migrationBuilder.DropTable(
                name: "PublicSchoolClassSchedule");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "StudentPublicSchoolClass");
        }
    }
}
