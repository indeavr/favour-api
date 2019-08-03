using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class educationconsumer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("2cdea15e-1b95-419c-b561-df006afbbddd"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("73bbb6fd-1f70-4341-9f8e-0062f1700c81"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("7ea6d224-bff9-4d6e-94fc-d4dbda7cab5c"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a196a0bf-7de9-426c-b1c7-df5b60b59f61"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a9d1cc96-b999-496e-b629-a103ca299646"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("b2c77080-eeaf-4d94-86a8-5a337e5256c8"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("d36b5f67-81fd-44f0-9931-850b403a0628"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("da48ad45-6ae9-4c01-ae99-8bd5977f22b2"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e1d56a60-6219-4034-8fce-64c6c78f4c36"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("66cf63c8-14cb-4ebc-966b-555e0f826859"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("7c9c872b-b8c1-48f5-b17c-647cf42fc412"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("949e1ec6-804d-4ad2-93d5-1f683e19af4a"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b978c22b-06c7-4fe0-931f-f179ac42a5ea"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("c6563fc1-4c6f-49c3-9ca9-5377ca20108c"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("cdca0047-616e-4688-980f-8953a4895298"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("de4b3b39-5fdd-4de5-8858-358aa77aca74"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConsumerId",
                table: "Educations",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("d4ab85bf-ed88-4188-a20a-c86caca9d5ec"), null, "Test industry 1" },
                    { new Guid("0bde52da-8c4c-4fef-9381-48eb3139aa13"), null, "Test industry 2" },
                    { new Guid("a47378e8-20c7-45f5-a451-5c8b3aa8ef08"), null, "Test industry 3" },
                    { new Guid("a068f373-bc7e-45be-8768-b9bb5690175b"), null, "Test industry 4" },
                    { new Guid("e62851e1-8ee5-4504-8e6e-7cd8027d04b6"), null, "Test industry 5" },
                    { new Guid("e36ca0b9-48c8-449e-bc50-73f576336710"), null, "Test industry 6" },
                    { new Guid("57da91d8-86b4-4814-9203-e04b9ddbdb59"), null, "Test industry 7" },
                    { new Guid("ccc69dc8-5231-4c01-a452-2efec093c5d3"), null, "Test industry 8" },
                    { new Guid("0c1fed62-ac00-486b-964c-b2a8adcf8954"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("a8ccb9d7-bc32-4336-81b1-90184308ba84"), null, null, "Test position 1" },
                    { new Guid("423d3b42-0b31-4deb-bc49-d29d051b143d"), null, null, "Test position 2" },
                    { new Guid("39c8f25b-75ed-4b16-bcc3-4a043efe41e5"), null, null, "Test position 3" },
                    { new Guid("7730f416-7eeb-439a-9eff-588a38b5ea32"), null, null, "Test position 4" },
                    { new Guid("b5483fbd-2311-41dd-a9e1-de03e37a2b26"), null, null, "Test position 5" },
                    { new Guid("d3a65080-00a5-4f62-b625-7cace455f5e2"), null, null, "Test position 6" },
                    { new Guid("79e4dd6a-5088-4c38-b7b3-d1e529a4351a"), null, null, "Test position 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ConsumerId",
                table: "Educations",
                column: "ConsumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Consumers_ConsumerId",
                table: "Educations",
                column: "ConsumerId",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Consumers_ConsumerId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_ConsumerId",
                table: "Educations");

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("0bde52da-8c4c-4fef-9381-48eb3139aa13"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("0c1fed62-ac00-486b-964c-b2a8adcf8954"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("57da91d8-86b4-4814-9203-e04b9ddbdb59"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a068f373-bc7e-45be-8768-b9bb5690175b"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a47378e8-20c7-45f5-a451-5c8b3aa8ef08"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("ccc69dc8-5231-4c01-a452-2efec093c5d3"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("d4ab85bf-ed88-4188-a20a-c86caca9d5ec"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e36ca0b9-48c8-449e-bc50-73f576336710"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e62851e1-8ee5-4504-8e6e-7cd8027d04b6"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("39c8f25b-75ed-4b16-bcc3-4a043efe41e5"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("423d3b42-0b31-4deb-bc49-d29d051b143d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("7730f416-7eeb-439a-9eff-588a38b5ea32"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("79e4dd6a-5088-4c38-b7b3-d1e529a4351a"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a8ccb9d7-bc32-4336-81b1-90184308ba84"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b5483fbd-2311-41dd-a9e1-de03e37a2b26"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d3a65080-00a5-4f62-b625-7cace455f5e2"));

            migrationBuilder.DropColumn(
                name: "ConsumerId",
                table: "Educations");

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("73bbb6fd-1f70-4341-9f8e-0062f1700c81"), null, "Test industry 1" },
                    { new Guid("2cdea15e-1b95-419c-b561-df006afbbddd"), null, "Test industry 2" },
                    { new Guid("a196a0bf-7de9-426c-b1c7-df5b60b59f61"), null, "Test industry 3" },
                    { new Guid("7ea6d224-bff9-4d6e-94fc-d4dbda7cab5c"), null, "Test industry 4" },
                    { new Guid("e1d56a60-6219-4034-8fce-64c6c78f4c36"), null, "Test industry 5" },
                    { new Guid("d36b5f67-81fd-44f0-9931-850b403a0628"), null, "Test industry 6" },
                    { new Guid("da48ad45-6ae9-4c01-ae99-8bd5977f22b2"), null, "Test industry 7" },
                    { new Guid("b2c77080-eeaf-4d94-86a8-5a337e5256c8"), null, "Test industry 8" },
                    { new Guid("a9d1cc96-b999-496e-b629-a103ca299646"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "FieldOfStudyId", "Name" },
                values: new object[,]
                {
                    { new Guid("b978c22b-06c7-4fe0-931f-f179ac42a5ea"), null, null, "Test position 1" },
                    { new Guid("949e1ec6-804d-4ad2-93d5-1f683e19af4a"), null, null, "Test position 2" },
                    { new Guid("de4b3b39-5fdd-4de5-8858-358aa77aca74"), null, null, "Test position 3" },
                    { new Guid("cdca0047-616e-4688-980f-8953a4895298"), null, null, "Test position 4" },
                    { new Guid("7c9c872b-b8c1-48f5-b17c-647cf42fc412"), null, null, "Test position 5" },
                    { new Guid("66cf63c8-14cb-4ebc-966b-555e0f826859"), null, null, "Test position 6" },
                    { new Guid("c6563fc1-4c6f-49c3-9ca9-5377ca20108c"), null, null, "Test position 7" }
                });
        }
    }
}
