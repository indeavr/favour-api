using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class efIsShit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Applications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Applications");
        }
    }
}
