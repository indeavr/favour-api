using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class university : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ActiveJobOffers_JobOfferId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId1",
                table: "IndustryPositions");

            migrationBuilder.DropIndex(
                name: "IX_IndustryPositions_IndustryId1",
                table: "IndustryPositions");

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

            migrationBuilder.DropColumn(
                name: "IndustryId1",
                table: "IndustryPositions");

            migrationBuilder.RenameColumn(
                name: "JobOfferId",
                table: "Applications",
                newName: "ActiveJobOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobOfferId",
                table: "Applications",
                newName: "IX_Applications_ActiveJobOfferId");

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("613482e8-2385-4b41-83be-80e23761a73a"), null, "Test industry 1" },
                    { new Guid("9a8b1c86-0add-44b2-bf5f-506304a8c7a8"), null, "Test industry 2" },
                    { new Guid("643c7d2d-b210-4213-a8fa-e4741ac340b8"), null, "Test industry 3" },
                    { new Guid("391be373-1143-437e-a2eb-d9ec4149733a"), null, "Test industry 4" },
                    { new Guid("5dd23bf8-6894-48ca-9a9a-b7be749d47b9"), null, "Test industry 5" },
                    { new Guid("1ceb8b08-374a-43ad-8a58-a5d0c273b12d"), null, "Test industry 6" },
                    { new Guid("c38ff25d-49f0-4720-a73f-f7bd5f92d736"), null, "Test industry 7" },
                    { new Guid("7870c8d5-4e23-45b6-9fbd-56f773435b05"), null, "Test industry 8" },
                    { new Guid("f9b11fc0-913c-47e7-8d82-9f3b95159c9e"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "ConsumerId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("1d038418-7d0b-4fb8-bdc8-f7303a4f0be5"), null, null, null, "Test position 7" },
                    { new Guid("8eec0e43-9e56-44b8-992e-14265495601d"), null, null, null, "Test position 6" },
                    { new Guid("d149199c-44ec-4fd5-980b-18219b188bcc"), null, null, null, "Test position 5" },
                    { new Guid("78cc97aa-93ae-4568-b0d2-7daa10425e4b"), null, null, null, "Test position 2" },
                    { new Guid("131b8d7a-c537-4f1e-b7e1-899c103825a9"), null, null, null, "Test position 3" },
                    { new Guid("cceb7697-e496-406f-a8e9-34f305890293"), null, null, null, "Test position 1" },
                    { new Guid("34bed7a3-a8b0-4aee-8076-0c77b8e78382"), null, null, null, "Test position 4" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name", "ConsumerId", "JobOfferId" },
                values: new object[,]
                {
                    { "Test skill 4", null, null },
                    { "Test skill 1", null, null },
                    { "Test skill 2", null, null },
                    { "Test skill 3", null, null },
                    { "Test skill 5", null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ActiveJobOffers_ActiveJobOfferId",
                table: "Applications",
                column: "ActiveJobOfferId",
                principalTable: "ActiveJobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId",
                table: "IndustryPositions",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ActiveJobOffers_ActiveJobOfferId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId",
                table: "IndustryPositions");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("1ceb8b08-374a-43ad-8a58-a5d0c273b12d"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("391be373-1143-437e-a2eb-d9ec4149733a"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("5dd23bf8-6894-48ca-9a9a-b7be749d47b9"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("613482e8-2385-4b41-83be-80e23761a73a"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("643c7d2d-b210-4213-a8fa-e4741ac340b8"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("7870c8d5-4e23-45b6-9fbd-56f773435b05"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("9a8b1c86-0add-44b2-bf5f-506304a8c7a8"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("c38ff25d-49f0-4720-a73f-f7bd5f92d736"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("f9b11fc0-913c-47e7-8d82-9f3b95159c9e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("131b8d7a-c537-4f1e-b7e1-899c103825a9"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("1d038418-7d0b-4fb8-bdc8-f7303a4f0be5"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("34bed7a3-a8b0-4aee-8076-0c77b8e78382"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("78cc97aa-93ae-4568-b0d2-7daa10425e4b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("8eec0e43-9e56-44b8-992e-14265495601d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("cceb7697-e496-406f-a8e9-34f305890293"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d149199c-44ec-4fd5-980b-18219b188bcc"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Name",
                keyValue: "Test skill 1");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Name",
                keyValue: "Test skill 2");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Name",
                keyValue: "Test skill 3");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Name",
                keyValue: "Test skill 4");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Name",
                keyValue: "Test skill 5");

            migrationBuilder.RenameColumn(
                name: "ActiveJobOfferId",
                table: "Applications",
                newName: "JobOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ActiveJobOfferId",
                table: "Applications",
                newName: "IX_Applications_JobOfferId");

            migrationBuilder.AddColumn<Guid>(
                name: "IndustryId1",
                table: "IndustryPositions",
                nullable: true);

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
                columns: new[] { "Id", "CompanyProviderId", "ConsumerId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("19032a8e-00bc-4a18-ac99-dc5edb18a4e0"), null, null, null, "Test position 1" },
                    { new Guid("32418dae-8137-4f12-aef7-d21edbf5579d"), null, null, null, "Test position 2" },
                    { new Guid("9b972c59-144e-4184-9023-ac4cfd9ae2f9"), null, null, null, "Test position 3" },
                    { new Guid("bac34a9f-9145-4b81-8858-c41d4329c505"), null, null, null, "Test position 4" },
                    { new Guid("34c02830-49d0-4423-b2a5-5f623356f93e"), null, null, null, "Test position 5" },
                    { new Guid("3cafc1ad-9812-4a31-9cf4-3ac06b8ed53f"), null, null, null, "Test position 6" },
                    { new Guid("84cbcc7b-83eb-4966-b903-64941c45bff7"), null, null, null, "Test position 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndustryPositions_IndustryId1",
                table: "IndustryPositions",
                column: "IndustryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ActiveJobOffers_JobOfferId",
                table: "Applications",
                column: "JobOfferId",
                principalTable: "ActiveJobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndustryPositions_Industries_IndustryId1",
                table: "IndustryPositions",
                column: "IndustryId1",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
