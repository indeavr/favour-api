using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class added_offerings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Consumers_ConsumerId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Consumers_ConsumerId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "ConsumerId",
                table: "Skills",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_ConsumerId",
                table: "Skills",
                newName: "IX_Skills_ProviderId");

            migrationBuilder.RenameColumn(
                name: "ConsumerId",
                table: "Results",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_ConsumerId",
                table: "Results",
                newName: "IX_Results_ProviderId");

            migrationBuilder.AddColumn<Guid>(
                name: "OfferingId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OfferingId",
                table: "Periods",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Offerings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true),
                    TimePosted = table.Column<DateTime>(nullable: false),
                    ProviderId = table.Column<Guid>(nullable: true),
                    Money = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offerings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offerings_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offerings_Consumers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_OfferingId",
                table: "Skills",
                column: "OfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_OfferingId",
                table: "Periods",
                column: "OfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_Offerings_LocationId",
                table: "Offerings",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Offerings_ProviderId",
                table: "Offerings",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_Offerings_OfferingId",
                table: "Periods",
                column: "OfferingId",
                principalTable: "Offerings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Consumers_ProviderId",
                table: "Results",
                column: "ProviderId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Offerings_OfferingId",
                table: "Skills",
                column: "OfferingId",
                principalTable: "Offerings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Consumers_ProviderId",
                table: "Skills",
                column: "ProviderId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Periods_Offerings_OfferingId",
                table: "Periods");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Consumers_ProviderId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Offerings_OfferingId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Consumers_ProviderId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Offerings");

            migrationBuilder.DropIndex(
                name: "IX_Skills_OfferingId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Periods_OfferingId",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "OfferingId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "OfferingId",
                table: "Periods");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Skills",
                newName: "ConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_ProviderId",
                table: "Skills",
                newName: "IX_Skills_ConsumerId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Results",
                newName: "ConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_ProviderId",
                table: "Results",
                newName: "IX_Results_ConsumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Consumers_ConsumerId",
                table: "Results",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Consumers_ConsumerId",
                table: "Skills",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
