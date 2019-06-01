using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class makingTheIndexUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_UserId_PermissionNameId",
                table: "Permissions");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserId_PermissionNameId",
                table: "Permissions",
                columns: new[] { "UserId", "PermissionNameId" },
                unique: true,
                filter: "[PermissionNameId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_UserId_PermissionNameId",
                table: "Permissions");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserId_PermissionNameId",
                table: "Permissions",
                columns: new[] { "UserId", "PermissionNameId" });
        }
    }
}
