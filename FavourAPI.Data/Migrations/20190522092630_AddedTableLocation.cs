using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class AddedTableLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "PersonProvider");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Office");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Consumer");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "PersonProvider",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Office",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "JobOffer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Consumer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    CustomInfo = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonProvider_LocationId",
                table: "PersonProvider",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_LocationId",
                table: "Office",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_LocationId",
                table: "JobOffer",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_LocationId",
                table: "Consumer",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumer_Location_LocationId",
                table: "Consumer",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Location_LocationId",
                table: "JobOffer",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Office_Location_LocationId",
                table: "Office",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProvider_Location_LocationId",
                table: "PersonProvider",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumer_Location_LocationId",
                table: "Consumer");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Location_LocationId",
                table: "JobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_Office_Location_LocationId",
                table: "Office");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProvider_Location_LocationId",
                table: "PersonProvider");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_PersonProvider_LocationId",
                table: "PersonProvider");

            migrationBuilder.DropIndex(
                name: "IX_Office_LocationId",
                table: "Office");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_LocationId",
                table: "JobOffer");

            migrationBuilder.DropIndex(
                name: "IX_Consumer_LocationId",
                table: "Consumer");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "PersonProvider");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Office");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Consumer");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "PersonProvider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Office",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "JobOffer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Consumer",
                nullable: true);
        }
    }
}
