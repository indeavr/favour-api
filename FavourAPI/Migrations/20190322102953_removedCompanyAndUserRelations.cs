using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class removedCompanyAndUserRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CompanyProviders_CompanyProviderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyProviderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyProviderId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "PersonProviderId",
                table: "PhoneNumbers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonProviderId",
                table: "Emails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonProviderId",
                table: "PhoneNumbers",
                column: "PersonProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_PersonProviderId",
                table: "Emails",
                column: "PersonProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_PersonProviders_PersonProviderId",
                table: "Emails",
                column: "PersonProviderId",
                principalTable: "PersonProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_PersonProviders_PersonProviderId",
                table: "PhoneNumbers",
                column: "PersonProviderId",
                principalTable: "PersonProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_PersonProviders_PersonProviderId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_PersonProviders_PersonProviderId",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_PersonProviderId",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Emails_PersonProviderId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "PersonProviderId",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "PersonProviderId",
                table: "Emails");

            migrationBuilder.AddColumn<string>(
                name: "CompanyProviderId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyProviderId",
                table: "Users",
                column: "CompanyProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CompanyProviders_CompanyProviderId",
                table: "Users",
                column: "CompanyProviderId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
