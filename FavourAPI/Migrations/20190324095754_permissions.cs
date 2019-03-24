using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class permissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanProceedAfterLogin",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "PermissionsId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Positions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    HasSufficientInfoConsumer = table.Column<bool>(nullable: false),
                    HasSufficientInfoProvider = table.Column<bool>(nullable: false),
                    CanApplyConsumer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PermissionsId",
                table: "Users",
                column: "PermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Permissions_PermissionsId",
                table: "Users",
                column: "PermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Permissions_PermissionsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Users_PermissionsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PermissionsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Positions");

            migrationBuilder.AddColumn<bool>(
                name: "CanProceedAfterLogin",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }
    }
}
