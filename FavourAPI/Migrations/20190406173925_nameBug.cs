using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class nameBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAdress",
                table: "Emails",
                newName: "EmailAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Emails",
                newName: "EmailAdress");
        }
    }
}
