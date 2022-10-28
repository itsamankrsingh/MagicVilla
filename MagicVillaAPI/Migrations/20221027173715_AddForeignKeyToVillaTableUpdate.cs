using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaWebAPI.Migrations
{
    public partial class AddForeignKeyToVillaTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "VillaNumbersTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "VillasTable",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 10, 27, 23, 7, 14, 810, DateTimeKind.Local).AddTicks(678), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", "Royal Villa", 4, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(2022, 10, 27, 23, 7, 14, 810, DateTimeKind.Local).AddTicks(690), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(2022, 10, 27, 23, 7, 14, 810, DateTimeKind.Local).AddTicks(692), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400.0, 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(2022, 10, 27, 23, 7, 14, 810, DateTimeKind.Local).AddTicks(695), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550.0, 900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", new DateTime(2022, 10, 27, 23, 7, 14, 810, DateTimeKind.Local).AddTicks(697), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600.0, 1100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbersTable_VillaID",
                table: "VillaNumbersTable",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbersTable_VillasTable_VillaID",
                table: "VillaNumbersTable",
                column: "VillaID",
                principalTable: "VillasTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbersTable_VillasTable_VillaID",
                table: "VillaNumbersTable");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbersTable_VillaID",
                table: "VillaNumbersTable");

            migrationBuilder.DeleteData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VillasTable",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "VillaNumbersTable");
        }
    }
}
