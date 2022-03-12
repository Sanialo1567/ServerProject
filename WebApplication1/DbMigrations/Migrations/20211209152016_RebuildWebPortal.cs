using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class RebuildWebPortal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cathegories_WebPortals_WebPortalEntityModelId",
                table: "Cathegories");

            migrationBuilder.DropTable(
                name: "WebPortalCathegories");

            migrationBuilder.DropIndex(
                name: "IX_Cathegories_WebPortalEntityModelId",
                table: "Cathegories");

            migrationBuilder.DropColumn(
                name: "WebPortalEntityModelId",
                table: "Cathegories");

            migrationBuilder.AddColumn<Guid>(
                name: "CathegoryId",
                table: "WebPortals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WebPortals_CathegoryId",
                table: "WebPortals",
                column: "CathegoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WebPortals_Cathegories_CathegoryId",
                table: "WebPortals",
                column: "CathegoryId",
                principalTable: "Cathegories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebPortals_Cathegories_CathegoryId",
                table: "WebPortals");

            migrationBuilder.DropIndex(
                name: "IX_WebPortals_CathegoryId",
                table: "WebPortals");

            migrationBuilder.DropColumn(
                name: "CathegoryId",
                table: "WebPortals");

            migrationBuilder.AddColumn<Guid>(
                name: "WebPortalEntityModelId",
                table: "Cathegories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WebPortalCathegories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CathegoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WebPortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebPortalCathegories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebPortalCathegories_Cathegories_CathegoryId",
                        column: x => x.CathegoryId,
                        principalTable: "Cathegories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebPortalCathegories_WebPortals_WebPortalId",
                        column: x => x.WebPortalId,
                        principalTable: "WebPortals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cathegories_WebPortalEntityModelId",
                table: "Cathegories",
                column: "WebPortalEntityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_WebPortalCathegories_CathegoryId",
                table: "WebPortalCathegories",
                column: "CathegoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WebPortalCathegories_WebPortalId",
                table: "WebPortalCathegories",
                column: "WebPortalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cathegories_WebPortals_WebPortalEntityModelId",
                table: "Cathegories",
                column: "WebPortalEntityModelId",
                principalTable: "WebPortals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
