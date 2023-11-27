using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDB.Migrations
{
    /// <inheritdoc />
    public partial class removeID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.CreateTable(
                name: "StdC",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_StdC_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StdC_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StdC_CourseID",
                table: "StdC",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StdC_StudentID",
                table: "StdC",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StdC");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "ID");

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesCourseID = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesCourseID, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesCourseID",
                        column: x => x.CoursesCourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsStudentId",
                table: "CourseStudent",
                column: "StudentsStudentId");
        }
    }
}
