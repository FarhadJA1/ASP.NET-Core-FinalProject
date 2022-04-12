using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_EndProject.Migrations
{
    public partial class UpdateBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostImage",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostImage",
                table: "Blogs");
        }
    }
}
