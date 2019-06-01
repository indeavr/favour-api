using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class AddedForeinKeysIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Consumers_ConsumerId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobOffers_JobOfferId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationStates_StateValue",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Locations_LocationId",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_PhoneNumbers_PhoneNumberId",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_CompanyProviders_ProviderId",
                table: "JobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_CompanyProviders_CompanyProviderId",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Locations_LocationId",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Periods_JobOffers_JobOfferId",
                table: "Periods");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProviders_Locations_LocationId",
                table: "PersonProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Consumers_ConsumerId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Consumers_ConsumerId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Results_ConsumerId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "CompanyProviderId",
                table: "Offices",
                newName: "CompanyProviderID");

            migrationBuilder.RenameIndex(
                name: "IX_Offices_CompanyProviderId",
                table: "Offices",
                newName: "IX_Offices_CompanyProviderID");

            migrationBuilder.RenameColumn(
                name: "StateValue",
                table: "Applications",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_StateValue",
                table: "Applications",
                newName: "IX_Applications_StateId");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyProviderId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConsumerId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PermissionMyId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonProviderId",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsumerId",
                table: "Skills",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConsumerId",
                table: "Results",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConsumerId1",
                table: "Results",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "PersonProviders",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JobOfferId",
                table: "Periods",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Offices",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyProviderID",
                table: "Offices",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyProviderId",
                table: "JobOffers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserProviderId",
                table: "JobOffers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PhoneNumberId",
                table: "Consumers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Consumers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JobOfferId",
                table: "Applications",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsumerId",
                table: "Applications",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_ConsumerId1",
                table: "Results",
                column: "ConsumerId1");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyProviderId",
                table: "JobOffers",
                column: "CompanyProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Consumers_ConsumerId",
                table: "Applications",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobOffers_JobOfferId",
                table: "Applications",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationStates_StateId",
                table: "Applications",
                column: "StateId",
                principalTable: "ApplicationStates",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_Locations_LocationId",
                table: "Consumers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_PhoneNumbers_PhoneNumberId",
                table: "Consumers",
                column: "PhoneNumberId",
                principalTable: "PhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_CompanyProviders_CompanyProviderId",
                table: "JobOffers",
                column: "CompanyProviderId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Users_ProviderId",
                table: "JobOffers",
                column: "ProviderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_CompanyProviders_CompanyProviderID",
                table: "Offices",
                column: "CompanyProviderID",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Locations_LocationId",
                table: "Offices",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_JobOffers_JobOfferId",
                table: "Periods",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProviders_Locations_LocationId",
                table: "PersonProviders",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Consumers_ConsumerId1",
                table: "Results",
                column: "ConsumerId1",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Consumers_ConsumerId",
                table: "Skills",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Consumers_ConsumerId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobOffers_JobOfferId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationStates_StateId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Locations_LocationId",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_PhoneNumbers_PhoneNumberId",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_CompanyProviders_CompanyProviderId",
                table: "JobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Users_ProviderId",
                table: "JobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_CompanyProviders_CompanyProviderID",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Locations_LocationId",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Periods_JobOffers_JobOfferId",
                table: "Periods");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProviders_Locations_LocationId",
                table: "PersonProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Consumers_ConsumerId1",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Consumers_ConsumerId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Results_ConsumerId1",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_CompanyProviderId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CompanyProviderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConsumerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PermissionMyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonProviderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConsumerId1",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "CompanyProviderId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "UserProviderId",
                table: "JobOffers");

            migrationBuilder.RenameColumn(
                name: "CompanyProviderID",
                table: "Offices",
                newName: "CompanyProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Offices_CompanyProviderID",
                table: "Offices",
                newName: "IX_Offices_CompanyProviderId");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Applications",
                newName: "StateValue");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_StateId",
                table: "Applications",
                newName: "IX_Applications_StateValue");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsumerId",
                table: "Skills",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsumerId",
                table: "Results",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "PersonProviders",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "JobOfferId",
                table: "Periods",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Offices",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyProviderId",
                table: "Offices",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "PhoneNumberId",
                table: "Consumers",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Consumers",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "JobOfferId",
                table: "Applications",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsumerId",
                table: "Applications",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Results_ConsumerId",
                table: "Results",
                column: "ConsumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Consumers_ConsumerId",
                table: "Applications",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobOffers_JobOfferId",
                table: "Applications",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationStates_StateValue",
                table: "Applications",
                column: "StateValue",
                principalTable: "ApplicationStates",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_Locations_LocationId",
                table: "Consumers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_PhoneNumbers_PhoneNumberId",
                table: "Consumers",
                column: "PhoneNumberId",
                principalTable: "PhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_CompanyProviders_ProviderId",
                table: "JobOffers",
                column: "ProviderId",
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
                name: "FK_Offices_Locations_LocationId",
                table: "Offices",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_JobOffers_JobOfferId",
                table: "Periods",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProviders_Locations_LocationId",
                table: "PersonProviders",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
