using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CityAPI.Migrations
{
    public partial class PeopleTableAddToCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_People_peopleId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_peopleId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "peopleId",
                table: "City");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "People",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_City_CityId",
                table: "People",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_City_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "peopleId",
                table: "City",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_peopleId",
                table: "City",
                column: "peopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_People_peopleId",
                table: "City",
                column: "peopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
