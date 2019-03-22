using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class oneOneCompanyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyProviderId",
                table: "Positions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyProviderId",
                table: "Offices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyProviderId",
                table: "Industries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyProviders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FoundedYear = table.Column<DateTime>(nullable: false),
                    Picture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NumberOfEmployees = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProviders_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CompanyProviderId",
                table: "Positions",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CompanyProviderId",
                table: "Offices",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Industries_CompanyProviderId",
                table: "Industries",
                column: "CompanyProviderId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Industries_CompanyProviders_CompanyProviderId",
                table: "Industries");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_CompanyProviders_CompanyProviderId",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_CompanyProviders_CompanyProviderId",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "CompanyProviders");

            migrationBuilder.DropIndex(
                name: "IX_Positions_CompanyProviderId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Offices_CompanyProviderId",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Industries_CompanyProviderId",
                table: "Industries");

            migrationBuilder.DropColumn(
                name: "CompanyProviderId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "CompanyProviderId",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "CompanyProviderId",
                table: "Industries");
        }
    }
}
