using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class PhoneConfirmed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "PhoneVerified",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("e28e3822-6952-495c-baf7-618eec97f776"), null, "Test industry 1" },
                    { new Guid("12ca432e-af3a-49c7-bc2e-cd6f61ae5694"), null, "Test industry 2" },
                    { new Guid("4f7d2fc5-1be8-4316-9f99-d24766bed1c6"), null, "Test industry 3" },
                    { new Guid("27eea4dd-ec56-4f7b-9d75-8dacde4df532"), null, "Test industry 4" },
                    { new Guid("3222cc30-0f8b-4264-9d9b-040ecdea8b6e"), null, "Test industry 5" },
                    { new Guid("adfa62ad-a201-44d6-b315-a2e13b27f0f9"), null, "Test industry 6" },
                    { new Guid("6fc0db2f-f80a-4c38-b1b5-ae16574d9d84"), null, "Test industry 7" },
                    { new Guid("69e5cce5-704f-4b2b-a8bc-dc7d3b77b67e"), null, "Test industry 8" },
                    { new Guid("2b87ad48-5299-4ab1-94c9-5698551c9f56"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "ConsumerId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("e36b55d6-0790-45ac-940e-b6647a11cfc4"), null, null, null, "Test position 1" },
                    { new Guid("193fac19-7659-4425-a0e8-845e055964ca"), null, null, null, "Test position 2" },
                    { new Guid("0f149d0d-8134-473b-b2f1-6a5e3a5c5cf7"), null, null, null, "Test position 3" },
                    { new Guid("931abee7-6944-4ef2-b614-3bc94a44589b"), null, null, null, "Test position 4" },
                    { new Guid("61140fbc-7355-4b3d-95f0-9fef8551a3b3"), null, null, null, "Test position 5" },
                    { new Guid("7b5258b6-aa60-46d1-86d6-99ccddb7dc0e"), null, null, null, "Test position 6" },
                    { new Guid("7094f8e5-c506-4892-abf1-927d1ffc80cf"), null, null, null, "Test position 7" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("12ca432e-af3a-49c7-bc2e-cd6f61ae5694"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("27eea4dd-ec56-4f7b-9d75-8dacde4df532"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("2b87ad48-5299-4ab1-94c9-5698551c9f56"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("3222cc30-0f8b-4264-9d9b-040ecdea8b6e"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("4f7d2fc5-1be8-4316-9f99-d24766bed1c6"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("69e5cce5-704f-4b2b-a8bc-dc7d3b77b67e"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("6fc0db2f-f80a-4c38-b1b5-ae16574d9d84"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("adfa62ad-a201-44d6-b315-a2e13b27f0f9"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e28e3822-6952-495c-baf7-618eec97f776"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0f149d0d-8134-473b-b2f1-6a5e3a5c5cf7"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("193fac19-7659-4425-a0e8-845e055964ca"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("61140fbc-7355-4b3d-95f0-9fef8551a3b3"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("7094f8e5-c506-4892-abf1-927d1ffc80cf"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("7b5258b6-aa60-46d1-86d6-99ccddb7dc0e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("931abee7-6944-4ef2-b614-3bc94a44589b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("e36b55d6-0790-45ac-940e-b6647a11cfc4"));

            migrationBuilder.DropColumn(
                name: "PhoneVerified",
                table: "AspNetUsers");

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
                    { new Guid("46e52d31-0c35-4cd7-be27-e4a25ade20d4"), null, null, null, "Test position 1" },
                    { new Guid("00024788-08b6-4562-a3fd-1d7e147f2bf3"), null, null, null, "Test position 2" },
                    { new Guid("f93216a1-390d-41b4-9957-ebe92efceede"), null, null, null, "Test position 3" },
                    { new Guid("4e8ec70b-40f4-48fa-94c7-e81262c62b20"), null, null, null, "Test position 4" },
                    { new Guid("e5d70cb4-c0d4-482b-b7ae-41230c98c046"), null, null, null, "Test position 5" },
                    { new Guid("101a6618-f8c9-425c-81c6-cdda3efc8172"), null, null, null, "Test position 6" },
                    { new Guid("f560f43c-b18f-4551-8909-e8c9a8d54248"), null, null, null, "Test position 7" }
                });
        }
    }
}
