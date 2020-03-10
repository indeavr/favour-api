using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class switchedConsumerToProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Consumers_ConsumerId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedJobOffers_Consumers_ConsumerId",
                table: "CompletedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Consumers_ConsumerId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_PersonProviders_PersonProviderId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Favours_PersonProviders_PersonProviderId",
                table: "Favours");

            migrationBuilder.DropForeignKey(
                name: "FK_Favours_CompanyProviders_ProviderId",
                table: "Favours");

            migrationBuilder.DropForeignKey(
                name: "FK_Industries_CompanyProviders_CompanyProviderId",
                table: "Industries");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_CompanyProviders_ProviderId",
                table: "JobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingJobOffers_Consumers_ConsumerId",
                table: "OngoingJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_PersonProviders_PersonProviderId",
                table: "PhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_CompanyProviders_CompanyProviderId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_OngoingJobOffers_JobOfferId",
                table: "OngoingJobOffers");

            migrationBuilder.RenameColumn(
                name: "CompanyProviderId",
                table: "Positions",
                newName: "CompanyConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_CompanyProviderId",
                table: "Positions",
                newName: "IX_Positions_CompanyConsumerId");

            migrationBuilder.RenameColumn(
                name: "PersonProviderId",
                table: "PhoneNumbers",
                newName: "PersonConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumbers_PersonProviderId",
                table: "PhoneNumbers",
                newName: "IX_PhoneNumbers_PersonConsumerId");

            migrationBuilder.RenameColumn(
                name: "ConsumerId",
                table: "OngoingJobOffers",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "JobOffers",
                newName: "CompanyConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_JobOffers_ProviderId",
                table: "JobOffers",
                newName: "IX_JobOffers_CompanyConsumerId");

            migrationBuilder.RenameColumn(
                name: "CompanyProviderId",
                table: "Industries",
                newName: "CompanyConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Industries_CompanyProviderId",
                table: "Industries",
                newName: "IX_Industries_CompanyConsumerId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Favours",
                newName: "PersonConsumerId");

            migrationBuilder.RenameColumn(
                name: "PersonProviderId",
                table: "Favours",
                newName: "CompanyConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Favours_ProviderId",
                table: "Favours",
                newName: "IX_Favours_PersonConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Favours_PersonProviderId",
                table: "Favours",
                newName: "IX_Favours_CompanyConsumerId");

            migrationBuilder.RenameColumn(
                name: "PersonProviderId",
                table: "Emails",
                newName: "PersonConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_PersonProviderId",
                table: "Emails",
                newName: "IX_Emails_PersonConsumerId");

            migrationBuilder.RenameColumn(
                name: "ConsumerId",
                table: "Educations",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_ConsumerId",
                table: "Educations",
                newName: "IX_Educations_ProviderId");

            migrationBuilder.RenameColumn(
                name: "ConsumerId",
                table: "CompletedJobOffers",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedJobOffers_ConsumerId",
                table: "CompletedJobOffers",
                newName: "IX_CompletedJobOffers_ProviderId");

            migrationBuilder.RenameColumn(
                name: "ConsumerId",
                table: "Applications",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ConsumerId",
                table: "Applications",
                newName: "IX_Applications_ProviderId");

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OngoingJobOffers_JobOfferId_ProviderId",
                table: "OngoingJobOffers",
                columns: new[] { "JobOfferId", "ProviderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Consumers_ProviderId",
                table: "Applications",
                column: "ProviderId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedJobOffers_Consumers_ProviderId",
                table: "CompletedJobOffers",
                column: "ProviderId",
                principalTable: "Consumers",
                principalColumn: "Id",
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
                name: "FK_OngoingJobOffers_Consumers_ProviderId",
                table: "OngoingJobOffers",
                column: "ProviderId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Consumers_ProviderId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedJobOffers_Consumers_ProviderId",
                table: "CompletedJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Consumers_ProviderId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_PersonProviders_PersonConsumerId",
                table: "Emails");

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
                name: "FK_OngoingJobOffers_Consumers_ProviderId",
                table: "OngoingJobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_PersonProviders_PersonConsumerId",
                table: "PhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_CompanyProviders_CompanyConsumerId",
                table: "Positions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_OngoingJobOffers_JobOfferId_ProviderId",
                table: "OngoingJobOffers");

            migrationBuilder.RenameColumn(
                name: "CompanyConsumerId",
                table: "Positions",
                newName: "CompanyProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_CompanyConsumerId",
                table: "Positions",
                newName: "IX_Positions_CompanyProviderId");

            migrationBuilder.RenameColumn(
                name: "PersonConsumerId",
                table: "PhoneNumbers",
                newName: "PersonProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumbers_PersonConsumerId",
                table: "PhoneNumbers",
                newName: "IX_PhoneNumbers_PersonProviderId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "OngoingJobOffers",
                newName: "ConsumerId");

            migrationBuilder.RenameColumn(
                name: "CompanyConsumerId",
                table: "JobOffers",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_JobOffers_CompanyConsumerId",
                table: "JobOffers",
                newName: "IX_JobOffers_ProviderId");

            migrationBuilder.RenameColumn(
                name: "CompanyConsumerId",
                table: "Industries",
                newName: "CompanyProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Industries_CompanyConsumerId",
                table: "Industries",
                newName: "IX_Industries_CompanyProviderId");

            migrationBuilder.RenameColumn(
                name: "PersonConsumerId",
                table: "Favours",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "CompanyConsumerId",
                table: "Favours",
                newName: "PersonProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Favours_PersonConsumerId",
                table: "Favours",
                newName: "IX_Favours_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Favours_CompanyConsumerId",
                table: "Favours",
                newName: "IX_Favours_PersonProviderId");

            migrationBuilder.RenameColumn(
                name: "PersonConsumerId",
                table: "Emails",
                newName: "PersonProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_PersonConsumerId",
                table: "Emails",
                newName: "IX_Emails_PersonProviderId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Educations",
                newName: "ConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_ProviderId",
                table: "Educations",
                newName: "IX_Educations_ConsumerId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "CompletedJobOffers",
                newName: "ConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedJobOffers_ProviderId",
                table: "CompletedJobOffers",
                newName: "IX_CompletedJobOffers_ConsumerId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Applications",
                newName: "ConsumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ProviderId",
                table: "Applications",
                newName: "IX_Applications_ConsumerId");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OngoingJobOffers_JobOfferId",
                table: "OngoingJobOffers",
                column: "JobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Consumers_ConsumerId",
                table: "Applications",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedJobOffers_Consumers_ConsumerId",
                table: "CompletedJobOffers",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Consumers_ConsumerId",
                table: "Educations",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_PersonProviders_PersonProviderId",
                table: "Emails",
                column: "PersonProviderId",
                principalTable: "PersonProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favours_PersonProviders_PersonProviderId",
                table: "Favours",
                column: "PersonProviderId",
                principalTable: "PersonProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favours_CompanyProviders_ProviderId",
                table: "Favours",
                column: "ProviderId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Industries_CompanyProviders_CompanyProviderId",
                table: "Industries",
                column: "CompanyProviderId",
                principalTable: "CompanyProviders",
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
                name: "FK_OngoingJobOffers_Consumers_ConsumerId",
                table: "OngoingJobOffers",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_PersonProviders_PersonProviderId",
                table: "PhoneNumbers",
                column: "PersonProviderId",
                principalTable: "PersonProviders",
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
