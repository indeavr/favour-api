using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class uniquepermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOfferLocations_JobOffers_JobOfferId1",
                table: "JobOfferLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_JobOffers_JobOfferId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_PermissionNames_PermissionNameName",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_UserId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Locations_JobOfferId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_JobOfferLocations_JobOfferId1",
                table: "JobOfferLocations");

            migrationBuilder.DropColumn(
                name: "JobOfferId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "JobOfferId1",
                table: "JobOfferLocations");

            migrationBuilder.RenameColumn(
                name: "PermissionNameName",
                table: "Permissions",
                newName: "PermissionNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_PermissionNameName",
                table: "Permissions",
                newName: "IX_Permissions_PermissionNameId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Permissions",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserId_PermissionNameId",
                table: "Permissions",
                columns: new[] { "UserId", "PermissionNameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobOfferLocations_JobOffers_JobOfferId",
                table: "JobOfferLocations",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_PermissionNames_PermissionNameId",
                table: "Permissions",
                column: "PermissionNameId",
                principalTable: "PermissionNames",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOfferLocations_JobOffers_JobOfferId",
                table: "JobOfferLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_PermissionNames_PermissionNameId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_UserId_PermissionNameId",
                table: "Permissions");

            migrationBuilder.RenameColumn(
                name: "PermissionNameId",
                table: "Permissions",
                newName: "PermissionNameName");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_PermissionNameId",
                table: "Permissions",
                newName: "IX_Permissions_PermissionNameName");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Permissions",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "JobOfferId",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobOfferId1",
                table: "JobOfferLocations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserId",
                table: "Permissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_JobOfferId",
                table: "Locations",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferLocations_JobOfferId1",
                table: "JobOfferLocations",
                column: "JobOfferId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOfferLocations_JobOffers_JobOfferId1",
                table: "JobOfferLocations",
                column: "JobOfferId1",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_JobOffers_JobOfferId",
                table: "Locations",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_PermissionNames_PermissionNameName",
                table: "Permissions",
                column: "PermissionNameName",
                principalTable: "PermissionNames",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
