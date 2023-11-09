using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_project.Migrations.ApplicationsDb
{
    /// <inheritdoc />
    public partial class ApplicationsInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    FullName = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
