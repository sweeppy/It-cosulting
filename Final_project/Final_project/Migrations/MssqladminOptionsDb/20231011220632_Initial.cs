using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_project.Migrations.MssqladminOptionsDb
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogSection",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    photo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BlogSect__3213E83FBC314320", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ContactSection",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ContactS__3213E83F3821F8F0", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FooterSection",
                columns: table => new
                {
                    locationPhoto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    textAbout = table.Column<string>(type: "text", nullable: false),
                    contactsId = table.Column<int>(type: "int", nullable: false),
                    contactsPath = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HeaderSection",
                columns: table => new
                {
                    Header = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MainInfo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ProjectsSection",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    photo = table.Column<string>(type: "varchar(200)", maxLength: 30, nullable: false),
                    header = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Projects__3213E83F80FFA181", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ServicesSection",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    HeaderOfService = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Services__3213E83FF5D9647E", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogSection");

            migrationBuilder.DropTable(
                name: "ContactSection");

            migrationBuilder.DropTable(
                name: "FooterSection");

            migrationBuilder.DropTable(
                name: "HeaderSection");

            migrationBuilder.DropTable(
                name: "ProjectsSection");

            migrationBuilder.DropTable(
                name: "ServicesSection");
        }
    }
}
