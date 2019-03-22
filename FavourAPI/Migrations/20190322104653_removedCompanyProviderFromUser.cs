using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class removedCompanyProviderFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProvider_Users_Id",
                table: "CompanyProvider");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CompanyProvider",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProvider_UserId",
                table: "CompanyProvider",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProvider_Users_UserId",
                table: "CompanyProvider",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProvider_Users_UserId",
                table: "CompanyProvider");

            migrationBuilder.DropIndex(
                name: "IX_CompanyProvider_UserId",
                table: "CompanyProvider");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CompanyProvider");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProvider_Users_Id",
                table: "CompanyProvider",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
