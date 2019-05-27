using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourAPI.Data.Migrations
{
    public partial class removedSkillId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkills_Positions_PositionId1",
                table: "PositionSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkills_Skills_SkillId",
                table: "PositionSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_PositionSkills_PositionId1",
                table: "PositionSkills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "PositionId1",
                table: "PositionSkills");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkillName",
                table: "PositionSkills",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkills_SkillName",
                table: "PositionSkills",
                column: "SkillName");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkills_Positions_PositionId",
                table: "PositionSkills",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkills_Skills_SkillName",
                table: "PositionSkills",
                column: "SkillName",
                principalTable: "Skills",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkills_Positions_PositionId",
                table: "PositionSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionSkills_Skills_SkillName",
                table: "PositionSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_PositionSkills_SkillName",
                table: "PositionSkills");

            migrationBuilder.DropColumn(
                name: "SkillName",
                table: "PositionSkills");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId1",
                table: "PositionSkills",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkills_PositionId1",
                table: "PositionSkills",
                column: "PositionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkills_Positions_PositionId1",
                table: "PositionSkills",
                column: "PositionId1",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionSkills_Skills_SkillId",
                table: "PositionSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
