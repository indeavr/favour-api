using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class providerNewConcept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobProviders");

            migrationBuilder.AddColumn<string>(
                name: "CompanyProviderId",
                table: "Users",
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
                });

            migrationBuilder.CreateTable(
                name: "PersonProviders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonProviders_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    CompanyProviderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_CompanyProviders_CompanyProviderId",
                        column: x => x.CompanyProviderId,
                        principalTable: "CompanyProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    EmailAdress = table.Column<string>(nullable: true),
                    OfficeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CompanyProviderId = table.Column<string>(nullable: true),
                    OfficeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Industries_CompanyProviders_CompanyProviderId",
                        column: x => x.CompanyProviderId,
                        principalTable: "CompanyProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Industries_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    OfficeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IndustryId = table.Column<string>(nullable: true),
                    CompanyProviderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_CompanyProviders_CompanyProviderId",
                        column: x => x.CompanyProviderId,
                        principalTable: "CompanyProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Positions_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PositionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyProviderId",
                table: "Users",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_OfficeId",
                table: "Emails",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Industries_CompanyProviderId",
                table: "Industries",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Industries_OfficeId",
                table: "Industries",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CompanyProviderId",
                table: "Offices",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_OfficeId",
                table: "PhoneNumbers",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CompanyProviderId",
                table: "Positions",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_IndustryId",
                table: "Positions",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PositionId",
                table: "Skills",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CompanyProviders_CompanyProviderId",
                table: "Users",
                column: "CompanyProviderId",
                principalTable: "CompanyProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CompanyProviders_CompanyProviderId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "PersonProviders");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "CompanyProviders");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyProviderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyProviderId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "JobProviders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyLocation = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobProviders_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
