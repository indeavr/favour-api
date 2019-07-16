using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class renamedreviewsforconsumer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Review",
                table: "Results",
                newName: "ReviewForProvider");

            migrationBuilder.AddColumn<string>(
                name: "ReviewForConsumer",
                table: "Results",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewForConsumer",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "ReviewForProvider",
                table: "Results",
                newName: "Review");
        }
    }
}
