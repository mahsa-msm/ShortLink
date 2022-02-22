using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortLink.EfCore.Migrations
{
    public partial class CreateLinkEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitCount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
