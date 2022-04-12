using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_EndProject.Migrations
{
    public partial class CreateSkillsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Communication",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Development",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Innovation",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "TeamLeader",
                table: "TeacherSkills");

            migrationBuilder.AddColumn<int>(
                name: "Percent",
                table: "TeacherSkills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillsId",
                table: "TeacherSkills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSkills_SkillsId",
                table: "TeacherSkills",
                column: "SkillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSkills_Skills_SkillsId",
                table: "TeacherSkills",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkills_Skills_SkillsId",
                table: "TeacherSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSkills_SkillsId",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "Percent",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "TeacherSkills");

            migrationBuilder.AddColumn<int>(
                name: "Communication",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Design",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Development",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Innovation",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamLeader",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
