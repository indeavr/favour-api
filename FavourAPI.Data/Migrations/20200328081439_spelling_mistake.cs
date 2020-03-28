using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class spelling_mistake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastAccoutSide",
                table: "AspNetUsers",
                newName: "LastAccountSide");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastAccountSide",
                table: "AspNetUsers",
                newName: "LastAccoutSide");
        }
    }
}
