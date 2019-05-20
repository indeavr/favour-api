using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Migrations
{
    public partial class SingleNamesOfTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "ConsumerJobOffers");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "IndustryPositions");

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
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "JobOfferStates");

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
                name: "CompanyProviders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "ApplicationState",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationState", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "JobOfferState",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferState", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProvider",
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
                    table.PrimaryKey("PK_CompanyProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProvider_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionMy",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    HasSufficientInfoConsumer = table.Column<bool>(nullable: false),
                    HasSufficientInfoProvider = table.Column<bool>(nullable: false),
                    CanApplyConsumer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionMy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionMy_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonProvider",
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
                    table.PrimaryKey("PK_PersonProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonProvider_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Industry",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    CompanyProviderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industry", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Industry_CompanyProvider_CompanyProviderId",
                        column: x => x.CompanyProviderId,
                        principalTable: "CompanyProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    CompanyProviderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Office_CompanyProvider_CompanyProviderId",
                        column: x => x.CompanyProviderId,
                        principalTable: "CompanyProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CompanyProviderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_CompanyProvider_CompanyProviderId",
                        column: x => x.CompanyProviderId,
                        principalTable: "CompanyProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    OfficeId = table.Column<string>(nullable: true),
                    PersonProviderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Email_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Email_PersonProvider_PersonProviderId",
                        column: x => x.PersonProviderId,
                        principalTable: "PersonProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfficeIndustry",
                columns: table => new
                {
                    OfficeId = table.Column<string>(nullable: false),
                    IndustryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeIndustry", x => new { x.IndustryId, x.OfficeId });
                    table.ForeignKey(
                        name: "FK_OfficeIndustry_Industry_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industry",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeIndustry_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    OfficeId = table.Column<string>(nullable: true),
                    PersonProviderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_PersonProvider_PersonProviderId",
                        column: x => x.PersonProviderId,
                        principalTable: "PersonProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndustryPosition",
                columns: table => new
                {
                    IndustryId = table.Column<string>(nullable: false),
                    PositionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryPosition", x => new { x.IndustryId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_IndustryPosition_Industry_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industry",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndustryPosition_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumer",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    PhoneNumberId = table.Column<string>(nullable: true),
                    SexValue = table.Column<string>(nullable: true),
                    CV = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumer_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumer_PhoneNumber_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consumer_Sex_SexValue",
                        column: x => x.SexValue,
                        principalTable: "Sex",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConsumerId = table.Column<string>(nullable: true),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_Consumer_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobOffer",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    TimePosted = table.Column<DateTime>(nullable: false),
                    ProviderId = table.Column<string>(nullable: true),
                    Money = table.Column<double>(nullable: false),
                    StateValue = table.Column<string>(nullable: true),
                    ResultId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffer_CompanyProvider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "CompanyProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOffer_Result_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Result",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOffer_JobOfferState_StateValue",
                        column: x => x.StateValue,
                        principalTable: "JobOfferState",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    JobOfferId = table.Column<string>(nullable: true),
                    ConsumerId = table.Column<string>(nullable: true),
                    StateValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application_Consumer_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_JobOffer_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_ApplicationState_StateValue",
                        column: x => x.StateValue,
                        principalTable: "ApplicationState",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerJobOffer",
                columns: table => new
                {
                    ConsumerId = table.Column<string>(nullable: false),
                    JobOfferId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerJobOffer", x => new { x.ConsumerId, x.JobOfferId });
                    table.ForeignKey(
                        name: "FK_ConsumerJobOffer_Consumer_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumerJobOffer_JobOffer_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartHour = table.Column<DateTime>(nullable: false),
                    EndHour = table.Column<DateTime>(nullable: false),
                    JobOfferId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Period_JobOffer_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ConsumerId = table.Column<string>(nullable: true),
                    JobOfferId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Consumer_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skill_JobOffer_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PositionSkill",
                columns: table => new
                {
                    PositionId = table.Column<string>(nullable: false),
                    SkillId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionSkill", x => new { x.SkillId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_PositionSkill_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationState",
                column: "Value",
                values: new object[]
                {
                    "Pending",
                    "Accepted",
                    "Rejected"
                });

            migrationBuilder.InsertData(
                table: "JobOfferState",
                column: "Value",
                values: new object[]
                {
                    "Available",
                    "Expired",
                    "Failed",
                    "Finished",
                    "Ongoing"
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_ConsumerId",
                table: "Application",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobOfferId",
                table: "Application",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_StateValue",
                table: "Application",
                column: "StateValue");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_PhoneNumberId",
                table: "Consumer",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_SexValue",
                table: "Consumer",
                column: "SexValue");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerJobOffer_JobOfferId",
                table: "ConsumerJobOffer",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_OfficeId",
                table: "Email",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_PersonProviderId",
                table: "Email",
                column: "PersonProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Industry_CompanyProviderId",
                table: "Industry",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryPosition_PositionId",
                table: "IndustryPosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_ProviderId",
                table: "JobOffer",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_ResultId",
                table: "JobOffer",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_StateValue",
                table: "JobOffer",
                column: "StateValue");

            migrationBuilder.CreateIndex(
                name: "IX_Office_CompanyProviderId",
                table: "Office",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeIndustry_OfficeId",
                table: "OfficeIndustry",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Period_JobOfferId",
                table: "Period",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_OfficeId",
                table: "PhoneNumber",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_PersonProviderId",
                table: "PhoneNumber",
                column: "PersonProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_CompanyProviderId",
                table: "Position",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkill_PositionId",
                table: "PositionSkill",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_ConsumerId",
                table: "Result",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_ConsumerId",
                table: "Skill",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_JobOfferId",
                table: "Skill",
                column: "JobOfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "ConsumerJobOffer");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "IndustryPosition");

            migrationBuilder.DropTable(
                name: "OfficeIndustry");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "PermissionMy");

            migrationBuilder.DropTable(
                name: "PositionSkill");

            migrationBuilder.DropTable(
                name: "ApplicationState");

            migrationBuilder.DropTable(
                name: "Industry");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "JobOffer");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "JobOfferState");

            migrationBuilder.DropTable(
                name: "Consumer");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "PersonProvider");

            migrationBuilder.DropTable(
                name: "CompanyProvider");

            migrationBuilder.DropTable(
                name: "User");

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
                    Id = table.Column<string>(nullable: false),
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
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FoundedYear = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    Picture = table.Column<byte[]>(nullable: true)
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
                    Id = table.Column<string>(nullable: false),
                    CanApplyConsumer = table.Column<bool>(nullable: false),
                    HasSufficientInfoConsumer = table.Column<bool>(nullable: false),
                    HasSufficientInfoProvider = table.Column<bool>(nullable: false)
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
                name: "PersonProviders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
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
                name: "Industries",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    CompanyProviderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Industries_CompanyProviders_CompanyProviderId",
                        column: x => x.CompanyProviderId,
                        principalTable: "CompanyProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyProviderId = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyProviderId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    OfficeId = table.Column<string>(nullable: true),
                    PersonProviderId = table.Column<string>(nullable: true)
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
                name: "OfficeIndustries",
                columns: table => new
                {
                    IndustryId = table.Column<string>(nullable: false),
                    OfficeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeIndustries", x => new { x.IndustryId, x.OfficeId });
                    table.ForeignKey(
                        name: "FK_OfficeIndustries_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeIndustries_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    OfficeId = table.Column<string>(nullable: true),
                    PersonProviderId = table.Column<string>(nullable: true)
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
                name: "IndustryPositions",
                columns: table => new
                {
                    IndustryId = table.Column<string>(nullable: false),
                    PositionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryPositions", x => new { x.IndustryId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_IndustryPositions_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndustryPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CV = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    PhoneNumberId = table.Column<string>(nullable: true),
                    SexValue = table.Column<string>(nullable: true)
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
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConsumerId = table.Column<string>(nullable: true),
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
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Money = table.Column<double>(nullable: false),
                    ProviderId = table.Column<string>(nullable: true),
                    ResultId = table.Column<string>(nullable: true),
                    StateValue = table.Column<string>(nullable: true),
                    TimePosted = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
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
                        name: "FK_JobOffers_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
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
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConsumerId = table.Column<string>(nullable: true),
                    JobOfferId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    StateValue = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_ApplicationStates_StateValue",
                        column: x => x.StateValue,
                        principalTable: "ApplicationStates",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerJobOffers",
                columns: table => new
                {
                    ConsumerId = table.Column<string>(nullable: false),
                    JobOfferId = table.Column<string>(nullable: false)
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
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EndHour = table.Column<DateTime>(nullable: false),
                    JobOfferId = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StartHour = table.Column<DateTime>(nullable: false)
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
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConsumerId = table.Column<string>(nullable: true),
                    JobOfferId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
                    SkillId = table.Column<string>(nullable: false),
                    PositionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionSkills", x => new { x.SkillId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_PositionSkills_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    "Available",
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
                name: "IX_OfficeIndustries_OfficeId",
                table: "OfficeIndustries",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CompanyProviderId",
                table: "Offices",
                column: "CompanyProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_JobOfferId",
                table: "Periods",
                column: "JobOfferId");

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
                name: "IX_PositionSkills_PositionId",
                table: "PositionSkills",
                column: "PositionId");

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
        }
    }
}
