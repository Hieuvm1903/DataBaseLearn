using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDB.Migrations
{
    /// <inheritdoc />
    public partial class RmCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentStudent");

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentId1",
                table: "Students",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Students_StudentId1",
                table: "Students",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Students_StudentId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "StudentStudent",
                columns: table => new
                {
                    FriendsStudentId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStudent", x => new { x.FriendsStudentId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentStudent_Students_FriendsStudentId",
                        column: x => x.FriendsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudent_StudentId",
                table: "StudentStudent",
                column: "StudentId");
        }
    }
}
