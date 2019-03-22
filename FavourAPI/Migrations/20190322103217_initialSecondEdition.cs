using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class initialSecondEdition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyProviderId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyProviderId",
                table: "Users",
                column: "CompanyProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CompanyProviders_CompanyProviderId",
                table: "Users",
                column: "CompanyProviderId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CompanyProviders_CompanyProviderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyProviderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyProviderId",
                table: "Users");
        }
    }
}
