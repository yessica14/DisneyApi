using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy.Disney.Api.Migrations
{
    public partial class DisneyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    History = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    qualification = table.Column<int>(type: "int", nullable: false),
                    TypeProduction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterProduction",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    ProductionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterProduction", x => new { x.CharactersId, x.ProductionsId });
                    table.ForeignKey(
                        name: "FK_CharacterProduction_Character_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterProduction_Production_ProductionsId",
                        column: x => x.ProductionsId,
                        principalTable: "Production",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenderProduction",
                columns: table => new
                {
                    GendersId = table.Column<int>(type: "int", nullable: false),
                    ProductionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderProduction", x => new { x.GendersId, x.ProductionsId });
                    table.ForeignKey(
                        name: "FK_GenderProduction_Gender_GendersId",
                        column: x => x.GendersId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenderProduction_Production_ProductionsId",
                        column: x => x.ProductionsId,
                        principalTable: "Production",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterProduction_ProductionsId",
                table: "CharacterProduction",
                column: "ProductionsId");

            migrationBuilder.CreateIndex(
                name: "IX_GenderProduction_ProductionsId",
                table: "GenderProduction",
                column: "ProductionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterProduction");

            migrationBuilder.DropTable(
                name: "GenderProduction");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Production");
        }
    }
}
