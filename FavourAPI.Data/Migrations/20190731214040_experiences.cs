using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class experiences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("1478f59a-a2b1-485a-bef5-f1c7025cf358"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("48ffce08-54ed-4c5c-9b9c-79300f297098"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("6076e068-1588-4b6b-ba01-182f743b033d"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("67f03807-e019-4df2-b9b7-7129bc65e876"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("931092ff-e7c0-4698-b4be-4ca258cc4ec4"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a0066260-96e9-49bc-aa2b-6fdffe00482c"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("db4f5b7f-2c52-4852-bdf7-36529946fa9b"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("e9a2ddf7-9450-4f15-952f-f2fa717e4f5c"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("f67736a5-d6a1-44b6-859c-480c3726192b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("40889d94-f0dd-46b4-b7f3-dded74735e07"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("41116f1e-b861-41a7-8b12-1bddf27c2088"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b21037fe-57bd-4b3d-bdb5-e9553dd60531"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b46e6e07-a7b6-472b-9a1d-7429f3797202"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b4728651-382d-4d3d-96c2-a93cbd72e980"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d567b94b-3689-453c-af9a-f79be23c2933"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d645894b-7820-4bcd-85f4-7bec4ba190f2"));

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    CurrentlyWorking = table.Column<bool>(nullable: false),
                    ConsumerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Experiences_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("ccdb8e70-fc1a-4b5b-85e7-3c81f2f6bb3e"), null, "Test industry 1" },
                    { new Guid("31649137-c730-440a-adf9-66408d40e0b5"), null, "Test industry 2" },
                    { new Guid("a9f33af7-b07b-48bd-9642-f893ad5950fe"), null, "Test industry 3" },
                    { new Guid("a71d6fdc-94ea-468f-948a-af5238aca71c"), null, "Test industry 4" },
                    { new Guid("59cd3ae8-80b1-4bbf-8877-65bab77a6886"), null, "Test industry 5" },
                    { new Guid("08fa6477-205c-47d8-bca5-32653e8bc092"), null, "Test industry 6" },
                    { new Guid("9b66ffce-2380-4e5d-8575-ef450fbe3a57"), null, "Test industry 7" },
                    { new Guid("24906b82-3665-4405-89e1-1beef734964e"), null, "Test industry 8" },
                    { new Guid("7d97fe69-40dc-4f58-8805-7419c8aa0068"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("ecbe3889-3f30-4149-b466-e9771cd5f13c"), null, "Test position 1" },
                    { new Guid("a72443c7-d61d-4ce9-bb6e-a6796cec9ce3"), null, "Test position 2" },
                    { new Guid("45be74d3-425d-4b35-84f7-d0d0be667421"), null, "Test position 3" },
                    { new Guid("d3113932-28bf-4069-a81f-f11e14060440"), null, "Test position 4" },
                    { new Guid("84ab9449-cc67-4759-a87b-e6e21b548f58"), null, "Test position 5" },
                    { new Guid("351c4899-2df1-4bfb-99e0-b3add2f980b0"), null, "Test position 6" },
                    { new Guid("dc5171a2-5725-499d-9b08-3c2f608f7472"), null, "Test position 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ConsumerId",
                table: "Experiences",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_PositionId",
                table: "Experiences",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("08fa6477-205c-47d8-bca5-32653e8bc092"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("24906b82-3665-4405-89e1-1beef734964e"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("31649137-c730-440a-adf9-66408d40e0b5"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("59cd3ae8-80b1-4bbf-8877-65bab77a6886"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("7d97fe69-40dc-4f58-8805-7419c8aa0068"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("9b66ffce-2380-4e5d-8575-ef450fbe3a57"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a71d6fdc-94ea-468f-948a-af5238aca71c"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("a9f33af7-b07b-48bd-9642-f893ad5950fe"));

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: new Guid("ccdb8e70-fc1a-4b5b-85e7-3c81f2f6bb3e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("351c4899-2df1-4bfb-99e0-b3add2f980b0"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("45be74d3-425d-4b35-84f7-d0d0be667421"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("84ab9449-cc67-4759-a87b-e6e21b548f58"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a72443c7-d61d-4ce9-bb6e-a6796cec9ce3"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d3113932-28bf-4069-a81f-f11e14060440"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("dc5171a2-5725-499d-9b08-3c2f608f7472"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("ecbe3889-3f30-4149-b466-e9771cd5f13c"));

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("48ffce08-54ed-4c5c-9b9c-79300f297098"), null, "Test industry 1" },
                    { new Guid("a0066260-96e9-49bc-aa2b-6fdffe00482c"), null, "Test industry 2" },
                    { new Guid("e9a2ddf7-9450-4f15-952f-f2fa717e4f5c"), null, "Test industry 3" },
                    { new Guid("f67736a5-d6a1-44b6-859c-480c3726192b"), null, "Test industry 4" },
                    { new Guid("1478f59a-a2b1-485a-bef5-f1c7025cf358"), null, "Test industry 5" },
                    { new Guid("67f03807-e019-4df2-b9b7-7129bc65e876"), null, "Test industry 6" },
                    { new Guid("6076e068-1588-4b6b-ba01-182f743b033d"), null, "Test industry 7" },
                    { new Guid("db4f5b7f-2c52-4852-bdf7-36529946fa9b"), null, "Test industry 8" },
                    { new Guid("931092ff-e7c0-4698-b4be-4ca258cc4ec4"), null, "Test industry 9" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CompanyProviderId", "Name" },
                values: new object[,]
                {
                    { new Guid("b46e6e07-a7b6-472b-9a1d-7429f3797202"), null, "Test position 1" },
                    { new Guid("d645894b-7820-4bcd-85f4-7bec4ba190f2"), null, "Test position 2" },
                    { new Guid("b4728651-382d-4d3d-96c2-a93cbd72e980"), null, "Test position 3" },
                    { new Guid("b21037fe-57bd-4b3d-bdb5-e9553dd60531"), null, "Test position 4" },
                    { new Guid("40889d94-f0dd-46b4-b7f3-dded74735e07"), null, "Test position 5" },
                    { new Guid("41116f1e-b861-41a7-8b12-1bddf27c2088"), null, "Test position 6" },
                    { new Guid("d567b94b-3689-453c-af9a-f79be23c2933"), null, "Test position 7" }
                });
        }
    }
}
