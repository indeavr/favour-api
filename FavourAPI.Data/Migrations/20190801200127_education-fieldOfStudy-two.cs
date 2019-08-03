using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class educationfieldOfStudytwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("1188241b-5ceb-471e-97b8-99c38fbb4eeb"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("356e4425-3c4c-42e1-a741-75de8b2a6bc3"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("3c4f76c4-cbcf-4120-b268-4272978f4bd7"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("4692675c-7d03-457a-9741-058c98499f29"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("483c1e5a-2320-42af-b904-b4bc1e6ea274"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("932dbff0-f73b-4a34-811b-ef9feef0d6e7"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("af245469-c800-4a2d-9fb2-94159e7b60a5"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("cde0eed9-b15b-438a-9e4e-9f9537c9ad5a"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e2c87cd6-a7dc-4018-b076-e7b195b82aa8"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("065bf4c2-1713-4c02-b4ba-25a41ddcfde0"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("09b4b37e-5769-421d-aff5-7c09de74f687"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0e6d5136-3170-4aee-a682-fa00806c61b8"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("3c6b8345-e661-46cb-ad48-ec7ed502cf7b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("93270c14-315b-439d-ab14-eb4817689026"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("9e516698-9e8b-4be1-84bf-d528c63fbf32"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("fd953fb3-d301-4fde-a0e2-7d33c3efcf5d"));

            migrationBuilder.AddColumn<Guid>(
                name: "FieldOfStudyId",
                table: "Positions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FieldsOfStudy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldsOfStudy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldId = table.Column<Guid>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_FieldsOfStudy_FieldId",
                        column: x => x.FieldId,
                        principalTable: "FieldsOfStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Positions_FieldOfStudyId",
                table: "Positions",
                column: "FieldOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_FieldId",
                table: "Educations",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_FieldsOfStudy_FieldOfStudyId",
                table: "Positions",
                column: "FieldOfStudyId",
                principalTable: "FieldsOfStudy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_FieldsOfStudy_FieldOfStudyId",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "FieldsOfStudy");

            migrationBuilder.DropIndex(
                name: "IX_Positions_FieldOfStudyId",
                table: "Positions");

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

            migrationBuilder.DropColumn(
                name: "FieldOfStudyId",
                table: "Positions");

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("356e4425-3c4c-42e1-a741-75de8b2a6bc3"), null, "Test industry 1" },
                    { new Guid("cde0eed9-b15b-438a-9e4e-9f9537c9ad5a"), null, "Test industry 2" },
                    { new Guid("3c4f76c4-cbcf-4120-b268-4272978f4bd7"), null, "Test industry 3" },
                    { new Guid("483c1e5a-2320-42af-b904-b4bc1e6ea274"), null, "Test industry 4" },
                    { new Guid("932dbff0-f73b-4a34-811b-ef9feef0d6e7"), null, "Test industry 5" },
                    { new Guid("1188241b-5ceb-471e-97b8-99c38fbb4eeb"), null, "Test industry 6" },
                    { new Guid("af245469-c800-4a2d-9fb2-94159e7b60a5"), null, "Test industry 7" },
                    { new Guid("4692675c-7d03-457a-9741-058c98499f29"), null, "Test industry 8" },
                    { new Guid("e2c87cd6-a7dc-4018-b076-e7b195b82aa8"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("09b4b37e-5769-421d-aff5-7c09de74f687"), null, "Test position 1" },
                    { new Guid("3c6b8345-e661-46cb-ad48-ec7ed502cf7b"), null, "Test position 2" },
                    { new Guid("fd953fb3-d301-4fde-a0e2-7d33c3efcf5d"), null, "Test position 3" },
                    { new Guid("0e6d5136-3170-4aee-a682-fa00806c61b8"), null, "Test position 4" },
                    { new Guid("93270c14-315b-439d-ab14-eb4817689026"), null, "Test position 5" },
                    { new Guid("065bf4c2-1713-4c02-b4ba-25a41ddcfde0"), null, "Test position 6" },
                    { new Guid("9e516698-9e8b-4be1-84bf-d528c63fbf32"), null, "Test position 7" }
                });
        }
    }
}
