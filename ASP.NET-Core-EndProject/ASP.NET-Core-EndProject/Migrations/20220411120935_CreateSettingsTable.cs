using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_EndProject.Migrations
{
    public partial class CreateSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(nullable: false),
                    HeaderLogo = table.Column<string>(nullable: true),
                    HeaderPhone = table.Column<string>(nullable: true),
                    FooterLogo = table.Column<string>(nullable: true),
                    FooterDesc = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    FirstPhone = table.Column<string>(nullable: true),
                    SecondPhone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
