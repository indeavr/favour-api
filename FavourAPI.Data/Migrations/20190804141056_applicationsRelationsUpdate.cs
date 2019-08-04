using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class applicationsRelationsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ActiveJobOffers_ActiveJobOfferId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobOffers_JobOfferId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ActiveJobOfferId",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("10786b67-1bf7-4462-bcd6-763cb7531a34"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("13b08251-8304-43b4-9345-b6af35122b00"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("149768a4-c6e8-4eb3-b939-38f35cf3c5ba"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("36c26a60-a276-44d2-b7dc-74bdadc147af"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("7178aea7-60e6-4877-8bbf-5ca88bf030e5"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("b06b1408-e7cd-4d6f-9bd8-c632ebfcebd7"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("bb807399-d35c-4944-801d-d3a371a08d8e"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("d9c03e7c-0d7a-4f83-82bd-8b1fea577859"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e44d1159-ee89-494a-8658-411b2cfe0ea6"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0b43d3eb-c943-462e-8922-2e7c3ad224a3"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("1fb6e675-5474-4b5c-9584-513f81861b5d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("50a0e256-62ef-4691-a14b-37e4ff790967"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("754c1a2f-834f-44c7-8af7-de3c6be86c7d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("c3ee903a-3a5a-4ea2-9389-04ca3a2ad1d1"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f26695a4-34f2-42fa-bfca-ef80b1526f14"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("fbf77dd7-c056-448d-a103-a39c88b2a935"));

            migrationBuilder.DropColumn(
                name: "ActiveJobOfferId",
                table: "Applications");

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("997163a9-52ab-4043-95ce-c81d3aa33c39"), null, "Test industry 1" },
                    { new Guid("44ec62a0-8b22-4ba2-8763-1eed27524f9e"), null, "Test industry 2" },
                    { new Guid("45c228f4-669d-4523-9f2c-c87e60f8b899"), null, "Test industry 3" },
                    { new Guid("92cf3d59-eef9-4347-a845-5467701ee78a"), null, "Test industry 4" },
                    { new Guid("219efd7a-bbad-4d53-b83f-6594450e105e"), null, "Test industry 5" },
                    { new Guid("3cbf2543-e45a-4466-b6e2-4dffd27605e2"), null, "Test industry 6" },
                    { new Guid("015abf17-3be9-4d6b-a70d-f67cb3ddcc8a"), null, "Test industry 7" },
                    { new Guid("a182aa6f-8e8a-44a3-af3c-4db69ef15a70"), null, "Test industry 8" },
                    { new Guid("c57365fe-27bf-4f59-84a4-c6c2ccecc31c"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("19032a8e-00bc-4a18-ac99-dc5edb18a4e0"), null, null, "Test position 1" },
                    { new Guid("32418dae-8137-4f12-aef7-d21edbf5579d"), null, null, "Test position 2" },
                    { new Guid("9b972c59-144e-4184-9023-ac4cfd9ae2f9"), null, null, "Test position 3" },
                    { new Guid("bac34a9f-9145-4b81-8858-c41d4329c505"), null, null, "Test position 4" },
                    { new Guid("34c02830-49d0-4423-b2a5-5f623356f93e"), null, null, "Test position 5" },
                    { new Guid("3cafc1ad-9812-4a31-9cf4-3ac06b8ed53f"), null, null, "Test position 6" },
                    { new Guid("84cbcc7b-83eb-4966-b903-64941c45bff7"), null, null, "Test position 7" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ActiveJobOffers_JobOfferId",
                table: "Applications",
                column: "JobOfferId",
                principalTable: "ActiveJobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ActiveJobOffers_JobOfferId",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("015abf17-3be9-4d6b-a70d-f67cb3ddcc8a"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("219efd7a-bbad-4d53-b83f-6594450e105e"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("3cbf2543-e45a-4466-b6e2-4dffd27605e2"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("44ec62a0-8b22-4ba2-8763-1eed27524f9e"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("45c228f4-669d-4523-9f2c-c87e60f8b899"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("92cf3d59-eef9-4347-a845-5467701ee78a"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("997163a9-52ab-4043-95ce-c81d3aa33c39"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a182aa6f-8e8a-44a3-af3c-4db69ef15a70"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("c57365fe-27bf-4f59-84a4-c6c2ccecc31c"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("19032a8e-00bc-4a18-ac99-dc5edb18a4e0"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("32418dae-8137-4f12-aef7-d21edbf5579d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("34c02830-49d0-4423-b2a5-5f623356f93e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("3cafc1ad-9812-4a31-9cf4-3ac06b8ed53f"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("84cbcc7b-83eb-4966-b903-64941c45bff7"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("9b972c59-144e-4184-9023-ac4cfd9ae2f9"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("bac34a9f-9145-4b81-8858-c41d4329c505"));

            migrationBuilder.AddColumn<Guid>(
                name: "ActiveJobOfferId",
                table: "Applications",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("36c26a60-a276-44d2-b7dc-74bdadc147af"), null, "Test industry 1" },
                    { new Guid("d9c03e7c-0d7a-4f83-82bd-8b1fea577859"), null, "Test industry 2" },
                    { new Guid("bb807399-d35c-4944-801d-d3a371a08d8e"), null, "Test industry 3" },
                    { new Guid("13b08251-8304-43b4-9345-b6af35122b00"), null, "Test industry 4" },
                    { new Guid("e44d1159-ee89-494a-8658-411b2cfe0ea6"), null, "Test industry 5" },
                    { new Guid("b06b1408-e7cd-4d6f-9bd8-c632ebfcebd7"), null, "Test industry 6" },
                    { new Guid("149768a4-c6e8-4eb3-b939-38f35cf3c5ba"), null, "Test industry 7" },
                    { new Guid("10786b67-1bf7-4462-bcd6-763cb7531a34"), null, "Test industry 8" },
                    { new Guid("7178aea7-60e6-4877-8bbf-5ca88bf030e5"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("f26695a4-34f2-42fa-bfca-ef80b1526f14"), null, null, "Test position 1" },
                    { new Guid("0b43d3eb-c943-462e-8922-2e7c3ad224a3"), null, null, "Test position 2" },
                    { new Guid("fbf77dd7-c056-448d-a103-a39c88b2a935"), null, null, "Test position 3" },
                    { new Guid("754c1a2f-834f-44c7-8af7-de3c6be86c7d"), null, null, "Test position 4" },
                    { new Guid("c3ee903a-3a5a-4ea2-9389-04ca3a2ad1d1"), null, null, "Test position 5" },
                    { new Guid("50a0e256-62ef-4691-a14b-37e4ff790967"), null, null, "Test position 6" },
                    { new Guid("1fb6e675-5474-4b5c-9584-513f81861b5d"), null, null, "Test position 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ActiveJobOfferId",
                table: "Applications",
                column: "ActiveJobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ActiveJobOffers_ActiveJobOfferId",
                table: "Applications",
                column: "ActiveJobOfferId",
                principalTable: "ActiveJobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobOffers_JobOfferId",
                table: "Applications",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
