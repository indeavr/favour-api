using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class PhoneVerificationSession : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "PhoneVerificationSession",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("094b9642-317e-46de-88c3-282d47b3a929"), null, "Test industry 1" },
                    { new Guid("7a56ae6b-614a-4b67-912f-56a2ec377e02"), null, "Test industry 2" },
                    { new Guid("7880c437-d06d-4230-ad6d-0466c600cba5"), null, "Test industry 3" },
                    { new Guid("cdefe7c8-1c4c-49c3-8bf1-1cbf3c34aa7e"), null, "Test industry 4" },
                    { new Guid("5ddffae3-3112-42fd-923f-5f8946cc4001"), null, "Test industry 5" },
                    { new Guid("c51e3c97-7b43-46b3-9a2a-f35fa5f6c5bc"), null, "Test industry 6" },
                    { new Guid("0100850d-838b-482e-b373-b6486b0638d2"), null, "Test industry 7" },
                    { new Guid("c4792e18-ea29-4232-8363-1f6d9e5ee97f"), null, "Test industry 8" },
                    { new Guid("6cad9664-376c-4e45-8962-08b41fa9490a"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "ConsumerId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("f560f43c-b18f-4551-8909-e8c9a8d54248"), null, null, null, "Test position 7" },
                    { new Guid("101a6618-f8c9-425c-81c6-cdda3efc8172"), null, null, null, "Test position 6" },
                    { new Guid("e5d70cb4-c0d4-482b-b7ae-41230c98c046"), null, null, null, "Test position 5" },
                    { new Guid("00024788-08b6-4562-a3fd-1d7e147f2bf3"), null, null, null, "Test position 2" },
                    { new Guid("f93216a1-390d-41b4-9957-ebe92efceede"), null, null, null, "Test position 3" },
                    { new Guid("46e52d31-0c35-4cd7-be27-e4a25ade20d4"), null, null, null, "Test position 1" },
                    { new Guid("4e8ec70b-40f4-48fa-94c7-e81262c62b20"), null, null, null, "Test position 4" }
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

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("0100850d-838b-482e-b373-b6486b0638d2"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("094b9642-317e-46de-88c3-282d47b3a929"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("5ddffae3-3112-42fd-923f-5f8946cc4001"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("6cad9664-376c-4e45-8962-08b41fa9490a"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("7880c437-d06d-4230-ad6d-0466c600cba5"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("7a56ae6b-614a-4b67-912f-56a2ec377e02"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("c4792e18-ea29-4232-8363-1f6d9e5ee97f"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("c51e3c97-7b43-46b3-9a2a-f35fa5f6c5bc"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("cdefe7c8-1c4c-49c3-8bf1-1cbf3c34aa7e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("00024788-08b6-4562-a3fd-1d7e147f2bf3"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("101a6618-f8c9-425c-81c6-cdda3efc8172"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("46e52d31-0c35-4cd7-be27-e4a25ade20d4"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("4e8ec70b-40f4-48fa-94c7-e81262c62b20"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("e5d70cb4-c0d4-482b-b7ae-41230c98c046"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f560f43c-b18f-4551-8909-e8c9a8d54248"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f93216a1-390d-41b4-9957-ebe92efceede"));

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

            migrationBuilder.DropColumn(
                name: "PhoneVerificationSession",
                table: "AspNetUsers");

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
