using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class nameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobProvider_Users_Id",
                table: "JobProvider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobProvider",
                table: "JobProvider");

            migrationBuilder.RenameTable(
                name: "JobProvider",
                newName: "JobProviders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobProviders",
                table: "JobProviders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobProviders_Users_Id",
                table: "JobProviders",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobProviders_Users_Id",
                table: "JobProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobProviders",
                table: "JobProviders");

            migrationBuilder.RenameTable(
                name: "JobProviders",
                newName: "JobProvider");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobProvider",
                table: "JobProvider",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobProvider_Users_Id",
                table: "JobProvider",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
