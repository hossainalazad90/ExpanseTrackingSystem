using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpanseTrackingSystem.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpanseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpanseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expanses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpanseCategoryId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    ExpanseAmount = table.Column<decimal>(nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expanses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expanses_ExpanseCategories_ExpanseCategoryId",
                        column: x => x.ExpanseCategoryId,
                        principalTable: "ExpanseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expanses_ExpanseCategoryId",
                table: "Expanses",
                column: "ExpanseCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expanses");

            migrationBuilder.DropTable(
                name: "ExpanseCategories");
        }
    }
}
