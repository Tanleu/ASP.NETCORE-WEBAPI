using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_3_Product.Migrations
{
    public partial class IntialDatabaseAndSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("19abfb80-c933-4377-9de8-5f430c11fc01"), "Đồ gia dụng" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b3399eb3-acd5-430e-b38a-d5993d01f03c"), "Đồ điện" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f05250dc-8ba4-473d-96ed-39a632c69423"), "Đồ cơ khí" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Manufacture", "Name" },
                values: new object[,]
                {
                    { new Guid("0bc6b6cd-afeb-4994-890a-f3e0fbe0b499"), new Guid("19abfb80-c933-4377-9de8-5f430c11fc01"), "Campuchia", "Máy giặt" },
                    { new Guid("28f0d0cb-6ff8-4a99-a732-d7c7829a5b3d"), new Guid("b3399eb3-acd5-430e-b38a-d5993d01f03c"), "Trung Quốc", "Tivi" },
                    { new Guid("501ceb80-773d-4909-a7ed-363bd79cf439"), new Guid("19abfb80-c933-4377-9de8-5f430c11fc01"), "Úc", "Bếp từ" },
                    { new Guid("71161bdf-bab5-4204-91be-537dde7a6384"), new Guid("b3399eb3-acd5-430e-b38a-d5993d01f03c"), "Hàn Quốc", "Điện thoại" },
                    { new Guid("7f1d94f3-5fca-40d3-b5bd-d1e08337b1d0"), new Guid("19abfb80-c933-4377-9de8-5f430c11fc01"), "Hàn Quốc", "Bàn Là" },
                    { new Guid("8bf64e1c-d538-409f-a0ad-2a7035956388"), new Guid("f05250dc-8ba4-473d-96ed-39a632c69423"), "Việt Nam", "Máy đục" },
                    { new Guid("9f67dd5f-1cbd-49c3-9b01-64c40c5109fd"), new Guid("19abfb80-c933-4377-9de8-5f430c11fc01"), "Nga", "Nồi cơm" },
                    { new Guid("bf188a93-c640-46b6-8408-3e3d35235ce4"), new Guid("f05250dc-8ba4-473d-96ed-39a632c69423"), "Mỹ", "Máy khoan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
