using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaWebAPI.Migrations
{
    public partial class SeedVillaTableWithCreatedDateNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 27, 21, 4, 55, 536, DateTimeKind.Local).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 27, 21, 4, 55, 536, DateTimeKind.Local).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 27, 21, 4, 55, 536, DateTimeKind.Local).AddTicks(9669));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 27, 21, 4, 55, 536, DateTimeKind.Local).AddTicks(9672));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 27, 21, 4, 55, 536, DateTimeKind.Local).AddTicks(9674));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 27, 21, 4, 36, 469, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 27, 21, 4, 36, 469, DateTimeKind.Local).AddTicks(9811));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 27, 21, 4, 36, 469, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 27, 21, 4, 36, 469, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 27, 21, 4, 36, 469, DateTimeKind.Local).AddTicks(9818));
        }
    }
}
