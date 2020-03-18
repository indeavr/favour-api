using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class added_person_consumer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Offerings_OfferingId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Providers_ProviderId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_PersonConsumers_PersonConsumerId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Favours_PersonConsumers_PersonConsumerId",
                table: "Favours");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonConsumers_Locations_LocationId",
                table: "PersonConsumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Images_ProfilePhotoName",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId",
                table: "SavedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Offerings_OfferingId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "ProviderViewTimes");

            migrationBuilder.DropIndex(
                name: "IX_Skills_OfferingId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Providers_ProfilePhotoName",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_PersonConsumers_LocationId",
                table: "PersonConsumers");

            migrationBuilder.DropIndex(
                name: "IX_Favours_PersonConsumerId",
                table: "Favours");

            migrationBuilder.DropIndex(
                name: "IX_Emails_PersonConsumerId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Educations_ProviderId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "OfferingId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ProfilePhotoName",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "PersonConsumers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "PersonConsumers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "PersonConsumers");

            migrationBuilder.DropColumn(
                name: "PersonConsumerId",
                table: "Favours");

            migrationBuilder.DropColumn(
                name: "PersonConsumerId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Educations");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "PersonConsumers",
                newName: "SexValue");

            migrationBuilder.RenameColumn(
                name: "OfferingId",
                table: "Applications",
                newName: "ActiveOfferingId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_OfferingId",
                table: "Applications",
                newName: "IX_Applications_ActiveOfferingId");

            migrationBuilder.AddColumn<Guid>(
                name: "ConsumerId1",
                table: "SavedJobOffers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompletedOfferingId",
                table: "Results",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SexValue",
                table: "PersonConsumers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OngoingOfferingId",
                table: "Periods",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResultId",
                table: "Offerings",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonConsumerId",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OfferingId",
                table: "JobPhotos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonConsumerId",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActiveOfferings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProviderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveOfferings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveOfferings_Offerings_Id",
                        column: x => x.Id,
                        principalTable: "Offerings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiveOfferings_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompletedOfferings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedOfferings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedOfferings_Offerings_Id",
                        column: x => x.Id,
                        principalTable: "Offerings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerViewTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Applications = table.Column<DateTime>(nullable: false),
                    OngoingJobOffers = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerViewTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OngoingOfferings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonConsumerId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OngoingOfferings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OngoingOfferings_Offerings_Id",
                        column: x => x.Id,
                        principalTable: "Offerings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OngoingOfferings_PersonConsumers_PersonConsumerId",
                        column: x => x.PersonConsumerId,
                        principalTable: "PersonConsumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobOffers_ConsumerId1",
                table: "SavedJobOffers",
                column: "ConsumerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Results_CompletedOfferingId",
                table: "Results",
                column: "CompletedOfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonConsumers_SexValue",
                table: "PersonConsumers",
                column: "SexValue");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_OngoingOfferingId",
                table: "Periods",
                column: "OngoingOfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_Offerings_ResultId",
                table: "Offerings",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_PersonConsumerId",
                table: "Locations",
                column: "PersonConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPhotos_OfferingId",
                table: "JobPhotos",
                column: "OfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PersonConsumerId",
                table: "Images",
                column: "PersonConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProviderId",
                table: "Images",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveOfferings_ProviderId",
                table: "ActiveOfferings",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_OngoingOfferings_PersonConsumerId",
                table: "OngoingOfferings",
                column: "PersonConsumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ActiveOfferings_ActiveOfferingId",
                table: "Applications",
                column: "ActiveOfferingId",
                principalTable: "ActiveOfferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_PersonConsumers_PersonConsumerId",
                table: "Images",
                column: "PersonConsumerId",
                principalTable: "PersonConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Providers_ProviderId",
                table: "Images",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPhotos_Offerings_OfferingId",
                table: "JobPhotos",
                column: "OfferingId",
                principalTable: "Offerings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_PersonConsumers_PersonConsumerId",
                table: "Locations",
                column: "PersonConsumerId",
                principalTable: "PersonConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offerings_Results_ResultId",
                table: "Offerings",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_OngoingOfferings_OngoingOfferingId",
                table: "Periods",
                column: "OngoingOfferingId",
                principalTable: "OngoingOfferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonConsumers_Sexes_SexValue",
                table: "PersonConsumers",
                column: "SexValue",
                principalTable: "Sexes",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_CompletedOfferings_CompletedOfferingId",
                table: "Results",
                column: "CompletedOfferingId",
                principalTable: "CompletedOfferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId1",
                table: "SavedJobOffers",
                column: "ConsumerId1",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ActiveOfferings_ActiveOfferingId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_PersonConsumers_PersonConsumerId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Providers_ProviderId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPhotos_Offerings_OfferingId",
                table: "JobPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_PersonConsumers_PersonConsumerId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Offerings_Results_ResultId",
                table: "Offerings");

            migrationBuilder.DropForeignKey(
                name: "FK_Periods_OngoingOfferings_OngoingOfferingId",
                table: "Periods");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonConsumers_Sexes_SexValue",
                table: "PersonConsumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_CompletedOfferings_CompletedOfferingId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId1",
                table: "SavedJobOffers");

            migrationBuilder.DropTable(
                name: "ActiveOfferings");

            migrationBuilder.DropTable(
                name: "CompletedOfferings");

            migrationBuilder.DropTable(
                name: "ConsumerViewTime");

            migrationBuilder.DropTable(
                name: "OngoingOfferings");

            migrationBuilder.DropIndex(
                name: "IX_SavedJobOffers_ConsumerId1",
                table: "SavedJobOffers");

            migrationBuilder.DropIndex(
                name: "IX_Results_CompletedOfferingId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_PersonConsumers_SexValue",
                table: "PersonConsumers");

            migrationBuilder.DropIndex(
                name: "IX_Periods_OngoingOfferingId",
                table: "Periods");

            migrationBuilder.DropIndex(
                name: "IX_Offerings_ResultId",
                table: "Offerings");

            migrationBuilder.DropIndex(
                name: "IX_Locations_PersonConsumerId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_JobPhotos_OfferingId",
                table: "JobPhotos");

            migrationBuilder.DropIndex(
                name: "IX_Images_PersonConsumerId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProviderId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ConsumerId1",
                table: "SavedJobOffers");

            migrationBuilder.DropColumn(
                name: "CompletedOfferingId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "OngoingOfferingId",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Offerings");

            migrationBuilder.DropColumn(
                name: "PersonConsumerId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "OfferingId",
                table: "JobPhotos");

            migrationBuilder.DropColumn(
                name: "PersonConsumerId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "SexValue",
                table: "PersonConsumers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ActiveOfferingId",
                table: "Applications",
                newName: "OfferingId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ActiveOfferingId",
                table: "Applications",
                newName: "IX_Applications_OfferingId");

            migrationBuilder.AddColumn<Guid>(
                name: "OfferingId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfilePhotoName",
                table: "Providers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "PersonConsumers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "PersonConsumers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "PersonConsumers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "PersonConsumers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonConsumerId",
                table: "Favours",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonConsumerId",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "Educations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProviderViewTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Applications = table.Column<DateTime>(nullable: false),
                    OngoingJobOffers = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderViewTimes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_OfferingId",
                table: "Skills",
                column: "OfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ProfilePhotoName",
                table: "Providers",
                column: "ProfilePhotoName");

            migrationBuilder.CreateIndex(
                name: "IX_PersonConsumers_LocationId",
                table: "PersonConsumers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Favours_PersonConsumerId",
                table: "Favours",
                column: "PersonConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_PersonConsumerId",
                table: "Emails",
                column: "PersonConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ProviderId",
                table: "Educations",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Offerings_OfferingId",
                table: "Applications",
                column: "OfferingId",
                principalTable: "Offerings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Providers_ProviderId",
                table: "Educations",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_PersonConsumers_PersonConsumerId",
                table: "Emails",
                column: "PersonConsumerId",
                principalTable: "PersonConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favours_PersonConsumers_PersonConsumerId",
                table: "Favours",
                column: "PersonConsumerId",
                principalTable: "PersonConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonConsumers_Locations_LocationId",
                table: "PersonConsumers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Images_ProfilePhotoName",
                table: "Providers",
                column: "ProfilePhotoName",
                principalTable: "Images",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId",
                table: "SavedJobOffers",
                column: "ConsumerId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Offerings_OfferingId",
                table: "Skills",
                column: "OfferingId",
                principalTable: "Offerings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
