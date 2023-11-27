using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDB.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Students",
                newName: "StudentId");
        }
    }
}
