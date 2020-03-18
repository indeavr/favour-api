using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class nameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Consumers_ProviderId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProviders_AspNetUsers_Id",
                table: "CompanyProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProviders_Images_ProfilePhotoName",
                table: "CompanyProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedJobOffers_Consumers_ProviderId",
                table: "CompletedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_AspNetUsers_Id",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Locations_LocationId",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_PhoneNumbers_PhoneNumberId",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Images_ProfilePhotoName",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Sexes_SexValue",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Consumers_ProviderId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_PersonProviders_PersonConsumerId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Consumers_ConsumerId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Favours_CompanyProviders_CompanyConsumerId",
                table: "Favours");

            migrationBuilder.DropForeignKey(
                name: "FK_Favours_PersonProviders_PersonConsumerId",
                table: "Favours");

            migrationBuilder.DropForeignKey(
                name: "FK_Industries_CompanyProviders_CompanyConsumerId",
                table: "Industries");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_CompanyProviders_CompanyConsumerId",
                table: "JobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offerings_Consumers_ProviderId",
                table: "Offerings");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_CompanyProviders_CompanyProviderId",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingJobOffers_Consumers_ProviderId",
                table: "OngoingJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProviders_AspNetUsers_Id",
                table: "PersonProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProviders_Locations_LocationId",
                table: "PersonProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_PersonProviders_PersonConsumerId",
                table: "PhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_CompanyProviders_CompanyConsumerId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Consumers_ConsumerId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Consumers_ProviderId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffers_Consumers_ConsumerId",
                table: "SavedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Consumers_ProviderId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonProviders",
                table: "PersonProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consumers",
                table: "Consumers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyProviders",
                table: "CompanyProviders");

            migrationBuilder.RenameTable(
                name: "PersonProviders",
                newName: "PersonConsumers");

            migrationBuilder.RenameTable(
                name: "Consumers",
                newName: "Providers");

            migrationBuilder.RenameTable(
                name: "CompanyProviders",
                newName: "CompanyConsumers");

            migrationBuilder.RenameIndex(
                name: "IX_PersonProviders_LocationId",
                table: "PersonConsumers",
                newName: "IX_PersonConsumers_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Consumers_SexValue",
                table: "Providers",
                newName: "IX_Providers_SexValue");

            migrationBuilder.RenameIndex(
                name: "IX_Consumers_ProfilePhotoName",
                table: "Providers",
                newName: "IX_Providers_ProfilePhotoName");

            migrationBuilder.RenameIndex(
                name: "IX_Consumers_PhoneNumberId",
                table: "Providers",
                newName: "IX_Providers_PhoneNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_Consumers_LocationId",
                table: "Providers",
                newName: "IX_Providers_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyProviders_ProfilePhotoName",
                table: "CompanyConsumers",
                newName: "IX_CompanyConsumers_ProfilePhotoName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonConsumers",
                table: "PersonConsumers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Providers",
                table: "Providers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyConsumers",
                table: "CompanyConsumers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Providers_ProviderId",
                table: "Applications",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyConsumers_AspNetUsers_Id",
                table: "CompanyConsumers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyConsumers_Images_ProfilePhotoName",
                table: "CompanyConsumers",
                column: "ProfilePhotoName",
                principalTable: "Images",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedJobOffers_Providers_ProviderId",
                table: "CompletedJobOffers",
                column: "ProviderId",
                principalTable: "Providers",
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
                name: "FK_Experiences_Providers_ConsumerId",
                table: "Experiences",
                column: "ConsumerId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favours_CompanyConsumers_CompanyConsumerId",
                table: "Favours",
                column: "CompanyConsumerId",
                principalTable: "CompanyConsumers",
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
                name: "FK_Industries_CompanyConsumers_CompanyConsumerId",
                table: "Industries",
                column: "CompanyConsumerId",
                principalTable: "CompanyConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_CompanyConsumers_CompanyConsumerId",
                table: "JobOffers",
                column: "CompanyConsumerId",
                principalTable: "CompanyConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offerings_Providers_ProviderId",
                table: "Offerings",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_CompanyConsumers_CompanyProviderId",
                table: "Offices",
                column: "CompanyProviderId",
                principalTable: "CompanyConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingJobOffers_Providers_ProviderId",
                table: "OngoingJobOffers",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonConsumers_AspNetUsers_Id",
                table: "PersonConsumers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonConsumers_Locations_LocationId",
                table: "PersonConsumers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_PersonConsumers_PersonConsumerId",
                table: "PhoneNumbers",
                column: "PersonConsumerId",
                principalTable: "PersonConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_CompanyConsumers_CompanyConsumerId",
                table: "Positions",
                column: "CompanyConsumerId",
                principalTable: "CompanyConsumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Providers_ConsumerId",
                table: "Positions",
                column: "ConsumerId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_AspNetUsers_Id",
                table: "Providers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Locations_LocationId",
                table: "Providers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_PhoneNumbers_PhoneNumberId",
                table: "Providers",
                column: "PhoneNumberId",
                principalTable: "PhoneNumbers",
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
                name: "FK_Providers_Sexes_SexValue",
                table: "Providers",
                column: "SexValue",
                principalTable: "Sexes",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Providers_ProviderId",
                table: "Results",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId",
                table: "SavedJobOffers",
                column: "ConsumerId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Providers_ProviderId",
                table: "Skills",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Providers_ProviderId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyConsumers_AspNetUsers_Id",
                table: "CompanyConsumers");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyConsumers_Images_ProfilePhotoName",
                table: "CompanyConsumers");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedJobOffers_Providers_ProviderId",
                table: "CompletedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Providers_ProviderId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_PersonConsumers_PersonConsumerId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Providers_ConsumerId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Favours_CompanyConsumers_CompanyConsumerId",
                table: "Favours");

            migrationBuilder.DropForeignKey(
                name: "FK_Favours_PersonConsumers_PersonConsumerId",
                table: "Favours");

            migrationBuilder.DropForeignKey(
                name: "FK_Industries_CompanyConsumers_CompanyConsumerId",
                table: "Industries");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_CompanyConsumers_CompanyConsumerId",
                table: "JobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offerings_Providers_ProviderId",
                table: "Offerings");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_CompanyConsumers_CompanyProviderId",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingJobOffers_Providers_ProviderId",
                table: "OngoingJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonConsumers_AspNetUsers_Id",
                table: "PersonConsumers");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonConsumers_Locations_LocationId",
                table: "PersonConsumers");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_PersonConsumers_PersonConsumerId",
                table: "PhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_CompanyConsumers_CompanyConsumerId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Providers_ConsumerId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_AspNetUsers_Id",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Locations_LocationId",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_PhoneNumbers_PhoneNumberId",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Images_ProfilePhotoName",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Sexes_SexValue",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Providers_ProviderId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobOffers_Providers_ConsumerId",
                table: "SavedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Providers_ProviderId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Providers",
                table: "Providers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonConsumers",
                table: "PersonConsumers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyConsumers",
                table: "CompanyConsumers");

            migrationBuilder.RenameTable(
                name: "Providers",
                newName: "Consumers");

            migrationBuilder.RenameTable(
                name: "PersonConsumers",
                newName: "PersonProviders");

            migrationBuilder.RenameTable(
                name: "CompanyConsumers",
                newName: "CompanyProviders");

            migrationBuilder.RenameIndex(
                name: "IX_Providers_SexValue",
                table: "Consumers",
                newName: "IX_Consumers_SexValue");

            migrationBuilder.RenameIndex(
                name: "IX_Providers_ProfilePhotoName",
                table: "Consumers",
                newName: "IX_Consumers_ProfilePhotoName");

            migrationBuilder.RenameIndex(
                name: "IX_Providers_PhoneNumberId",
                table: "Consumers",
                newName: "IX_Consumers_PhoneNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_Providers_LocationId",
                table: "Consumers",
                newName: "IX_Consumers_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonConsumers_LocationId",
                table: "PersonProviders",
                newName: "IX_PersonProviders_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyConsumers_ProfilePhotoName",
                table: "CompanyProviders",
                newName: "IX_CompanyProviders_ProfilePhotoName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consumers",
                table: "Consumers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonProviders",
                table: "PersonProviders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyProviders",
                table: "CompanyProviders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Consumers_ProviderId",
                table: "Applications",
                column: "ProviderId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProviders_AspNetUsers_Id",
                table: "CompanyProviders",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProviders_Images_ProfilePhotoName",
                table: "CompanyProviders",
                column: "ProfilePhotoName",
                principalTable: "Images",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedJobOffers_Consumers_ProviderId",
                table: "CompletedJobOffers",
                column: "ProviderId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_AspNetUsers_Id",
                table: "Consumers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Consumers_Images_ProfilePhotoName",
                table: "Consumers",
                column: "ProfilePhotoName",
                principalTable: "Images",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_Sexes_SexValue",
                table: "Consumers",
                column: "SexValue",
                principalTable: "Sexes",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Consumers_ProviderId",
                table: "Educations",
                column: "ProviderId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_PersonProviders_PersonConsumerId",
                table: "Emails",
                column: "PersonConsumerId",
                principalTable: "PersonProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Consumers_ConsumerId",
                table: "Experiences",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favours_CompanyProviders_CompanyConsumerId",
                table: "Favours",
                column: "CompanyConsumerId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favours_PersonProviders_PersonConsumerId",
                table: "Favours",
                column: "PersonConsumerId",
                principalTable: "PersonProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Industries_CompanyProviders_CompanyConsumerId",
                table: "Industries",
                column: "CompanyConsumerId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_CompanyProviders_CompanyConsumerId",
                table: "JobOffers",
                column: "CompanyConsumerId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offerings_Consumers_ProviderId",
                table: "Offerings",
                column: "ProviderId",
                principalTable: "Consumers",
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
                name: "FK_OngoingJobOffers_Consumers_ProviderId",
                table: "OngoingJobOffers",
                column: "ProviderId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProviders_AspNetUsers_Id",
                table: "PersonProviders",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProviders_Locations_LocationId",
                table: "PersonProviders",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_PersonProviders_PersonConsumerId",
                table: "PhoneNumbers",
                column: "PersonConsumerId",
                principalTable: "PersonProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_CompanyProviders_CompanyConsumerId",
                table: "Positions",
                column: "CompanyConsumerId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Consumers_ConsumerId",
                table: "Positions",
                column: "ConsumerId",
                principalTable: "Consumers",
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
                name: "FK_SavedJobOffers_Consumers_ConsumerId",
                table: "SavedJobOffers",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Consumers_ProviderId",
                table: "Skills",
                column: "ProviderId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
