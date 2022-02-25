using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assigment_2_Task.Migrations
{
    public partial class SeedingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthPlace", "DateOfBirth", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { new Guid("43258efb-e780-4cc6-a3c2-01f7dd112500"), "Hải Dương", new DateTime(1796, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Man", 0, "IRON" },
                    { new Guid("54bddba9-2373-45a9-b382-c2892a764bbd"), "Hải Dương", new DateTime(2000, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tân", 0, "Lều Duy" },
                    { new Guid("d3db22a3-affb-441c-929a-9a326c3a5243"), "Hải Dương", new DateTime(1967, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alan", 2, "Ưalker" },
                    { new Guid("db8b1c0b-8327-4b8a-9792-c839abcff892"), "Hải Dương", new DateTime(1996, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter", 1, "John" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("43258efb-e780-4cc6-a3c2-01f7dd112500"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("54bddba9-2373-45a9-b382-c2892a764bbd"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("d3db22a3-affb-441c-929a-9a326c3a5243"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("db8b1c0b-8327-4b8a-9792-c839abcff892"));
        }
    }
}
