using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class removedCompanyProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProviders_Users_Id",
                table: "CompanyProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_Industries_CompanyProviders_CompanyProviderId",
                table: "Industries");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_CompanyProviders_CompanyProviderId",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_CompanyProviders_CompanyProviderId",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyProviders",
                table: "CompanyProviders");

            migrationBuilder.RenameTable(
                name: "CompanyProviders",
                newName: "CompanyProvider");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyProvider",
                table: "CompanyProvider",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProvider_Users_Id",
                table: "CompanyProvider",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Industries_CompanyProvider_CompanyProviderId",
                table: "Industries",
                column: "CompanyProviderId",
                principalTable: "CompanyProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_CompanyProvider_CompanyProviderId",
                table: "Offices",
                column: "CompanyProviderId",
                principalTable: "CompanyProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_CompanyProvider_CompanyProviderId",
                table: "Positions",
                column: "CompanyProviderId",
                principalTable: "CompanyProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProvider_Users_Id",
                table: "CompanyProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_Industries_CompanyProvider_CompanyProviderId",
                table: "Industries");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_CompanyProvider_CompanyProviderId",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_CompanyProvider_CompanyProviderId",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyProvider",
                table: "CompanyProvider");

            migrationBuilder.RenameTable(
                name: "CompanyProvider",
                newName: "CompanyProviders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyProviders",
                table: "CompanyProviders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProviders_Users_Id",
                table: "CompanyProviders",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Industries_CompanyProviders_CompanyProviderId",
                table: "Industries",
                column: "CompanyProviderId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_CompanyProviders_CompanyProviderId",
                table: "Offices",
                column: "CompanyProviderId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_CompanyProviders_CompanyProviderId",
                table: "Positions",
                column: "CompanyProviderId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
