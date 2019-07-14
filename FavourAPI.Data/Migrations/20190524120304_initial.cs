using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationStates",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStates", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "JobOfferStates",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferStates", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProviders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "PermissionMys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasSufficientInfoConsumer = table.Column<bool>(nullable: false),
                    HasSufficientInfoProvider = table.Column<bool>(nullable: false),
                    CanApplyConsumer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionMys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionMys_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CompanyProviderId = table.Column<Guid>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CompanyProviderId = table.Column<Guid>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "IndustryPositions",
                columns: table => new
                {
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryPositions", x => new { x.IndustryId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_IndustryPositions_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndustryPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    JobOfferId = table.Column<Guid>(nullable: true),
                    ConsumerId = table.Column<Guid>(nullable: true),
                    StateValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_ApplicationStates_StateValue",
                        column: x => x.StateValue,
                        principalTable: "ApplicationStates",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimePosted = table.Column<DateTime>(nullable: false),
                    ProviderId = table.Column<Guid>(nullable: true),
                    Money = table.Column<double>(nullable: false),
                    StateValue = table.Column<string>(nullable: true),
                    ResultId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_CompanyProviders_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "CompanyProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOffers_JobOfferStates_StateValue",
                        column: x => x.StateValue,
                        principalTable: "JobOfferStates",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPhotos_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    CustomInfo = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    JobOfferId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartHour = table.Column<DateTime>(nullable: false),
                    EndHour = table.Column<DateTime>(nullable: false),
                    JobOfferId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Periods_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobOfferLocations",
                columns: table => new
                {
                    JobOfferId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    JobOfferId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferLocations", x => new { x.JobOfferId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_JobOfferLocations_JobOffers_JobOfferId1",
                        column: x => x.JobOfferId1,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOfferLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true),
                    CompanyProviderId = table.Column<Guid>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Offices_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonProviders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_PersonProviders_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfficeIndustries",
                columns: table => new
                {
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeIndustries", x => new { x.IndustryId, x.OfficeId });
                    table.ForeignKey(
                        name: "FK_OfficeIndustries_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeIndustries_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    OfficeId = table.Column<Guid>(nullable: true),
                    PersonProviderId = table.Column<Guid>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Emails_PersonProviders_PersonProviderId",
                        column: x => x.PersonProviderId,
                        principalTable: "PersonProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    OfficeId = table.Column<Guid>(nullable: true),
                    PersonProviderId = table.Column<Guid>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_PersonProviders_PersonProviderId",
                        column: x => x.PersonProviderId,
                        principalTable: "PersonProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true),
                    PhoneNumberId = table.Column<Guid>(nullable: true),
                    SexValue = table.Column<string>(nullable: true),
                    CV = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consumers_PhoneNumbers_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consumers_Sexes_SexValue",
                        column: x => x.SexValue,
                        principalTable: "Sexes",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerJobOffers",
                columns: table => new
                {
                    ConsumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerJobOffers", x => new { x.ConsumerId, x.JobOfferId });
                    table.ForeignKey(
                        name: "FK_ConsumerJobOffers_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumerJobOffers_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumerId = table.Column<Guid>(nullable: true),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ConsumerId = table.Column<Guid>(nullable: true),
                    JobOfferId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PositionSkills",
                columns: table => new
                {
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionSkills", x => new { x.SkillId, x.PositionId });
                    table.UniqueConstraint("AK_PositionSkills_PositionId_SkillId", x => new { x.PositionId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_PositionSkills_Positions_PositionId1",
                        column: x => x.PositionId1,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PositionSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationStates",
                column: "Value",
                values: new object[]
                {
                    "Pending",
                    "Accepted",
                    "Rejected"
                });

            migrationBuilder.InsertData(
                table: "JobOfferStates",
                column: "Value",
                values: new object[]
                {
                    "Active",
                    "Expired",
                    "Failed",
                    "Finished",
                    "Ongoing"
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ConsumerId",
                table: "Applications",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobOfferId",
                table: "Applications",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StateValue",
                table: "Applications",
                column: "StateValue");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerJobOffers_JobOfferId",
                table: "ConsumerJobOffers",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_LocationId",
                table: "Consumers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_PhoneNumberId",
                table: "Consumers",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_SexValue",
                table: "Consumers",
                column: "SexValue");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_OfficeId",
                table: "Emails",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_PersonProviderId",
                table: "Emails",
                column: "PersonProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Industries_CompanyProviderId",
                table: "Industries",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryPositions_PositionId",
                table: "IndustryPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferLocations_JobOfferId1",
                table: "JobOfferLocations",
                column: "JobOfferId1");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferLocations_LocationId",
                table: "JobOfferLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_ProviderId",
                table: "JobOffers",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_ResultId",
                table: "JobOffers",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_StateValue",
                table: "JobOffers",
                column: "StateValue");

            migrationBuilder.CreateIndex(
                name: "IX_JobPhotos_JobOfferId",
                table: "JobPhotos",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_JobOfferId",
                table: "Locations",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeIndustries_OfficeId",
                table: "OfficeIndustries",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CompanyProviderId",
                table: "Offices",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_LocationId",
                table: "Offices",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_JobOfferId",
                table: "Periods",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProviders_LocationId",
                table: "PersonProviders",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_OfficeId",
                table: "PhoneNumbers",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonProviderId",
                table: "PhoneNumbers",
                column: "PersonProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CompanyProviderId",
                table: "Positions",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkills_PositionId1",
                table: "PositionSkills",
                column: "PositionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ConsumerId",
                table: "Results",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ConsumerId",
                table: "Skills",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_JobOfferId",
                table: "Skills",
                column: "JobOfferId");

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
                name: "FK_JobOffers_Results_ResultId",
                table: "JobOffers",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Consumers_ConsumerId",
                table: "Results");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "ConsumerJobOffers");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "IndustryPositions");

            migrationBuilder.DropTable(
                name: "JobOfferLocations");

            migrationBuilder.DropTable(
                name: "JobPhotos");

            migrationBuilder.DropTable(
                name: "OfficeIndustries");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "PermissionMys");

            migrationBuilder.DropTable(
                name: "PositionSkills");

            migrationBuilder.DropTable(
                name: "ApplicationStates");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Consumers");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Sexes");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "PersonProviders");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "CompanyProviders");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "JobOfferStates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
