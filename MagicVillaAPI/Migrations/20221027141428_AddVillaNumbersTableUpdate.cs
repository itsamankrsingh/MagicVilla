using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaWebAPI.Migrations
{
    public partial class AddVillaNumbersTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbersTable",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbersTable", x => x.VillaNo);
                });

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 27, 19, 44, 28, 272, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 27, 19, 44, 28, 272, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 27, 19, 44, 28, 272, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 27, 19, 44, 28, 272, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 27, 19, 44, 28, 272, DateTimeKind.Local).AddTicks(9447));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbersTable");

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 27, 19, 13, 58, 175, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 27, 19, 13, 58, 175, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 27, 19, 13, 58, 175, DateTimeKind.Local).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 27, 19, 13, 58, 175, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 27, 19, 13, 58, 175, DateTimeKind.Local).AddTicks(7407));
        }
    }
}
