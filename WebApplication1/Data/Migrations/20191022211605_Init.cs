using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    FileTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.FileTypeID);
                });

            migrationBuilder.CreateTable(
                name: "NoteType",
                columns: table => new
                {
                    NoteTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteType", x => x.NoteTypeID);
                });

            migrationBuilder.CreateTable(
                name: "StudentStatus",
                columns: table => new
                {
                    StudentStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStatus", x => x.StudentStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Village = table.Column<string>(maxLength: 50, nullable: false),
                    GPSLatitude = table.Column<decimal>(nullable: false),
                    GPSLongitude = table.Column<decimal>(nullable: false),
                    PublicSchoolLevel = table.Column<short>(nullable: false),
                    GuardianName = table.Column<string>(maxLength: 100, nullable: false),
                    GuardianType = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    StudentStatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Student_StudentStatus_StudentStatusID",
                        column: x => x.StudentStatusID,
                        principalTable: "StudentStatus",
                        principalColumn: "StudentStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 100, nullable: false),
                    StudentID = table.Column<int>(nullable: false),
                    FileTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_File_FileType_FileTypeID",
                        column: x => x.FileTypeID,
                        principalTable: "FileType",
                        principalColumn: "FileTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: false),
                    StudentID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    NoteTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_Note_NoteType_NoteTypeID",
                        column: x => x.NoteTypeID,
                        principalTable: "NoteType",
                        principalColumn: "NoteTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_FileTypeID",
                table: "File",
                column: "FileTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_File_StudentID",
                table: "File",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_NoteTypeID",
                table: "Note",
                column: "NoteTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_StudentID",
                table: "Note",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_UserID",
                table: "Note",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentStatusID",
                table: "Student",
                column: "StudentStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "NoteType");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "StudentStatus");
        }
    }
}
