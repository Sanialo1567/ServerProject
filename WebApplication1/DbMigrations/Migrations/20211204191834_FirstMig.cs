using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class FirstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebPortals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebPortals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebPortals_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cathegories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebPortalEntityModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cathegories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cathegories_WebPortals_WebPortalEntityModelId",
                        column: x => x.WebPortalEntityModelId,
                        principalTable: "WebPortals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebPortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_WebPortals_WebPortalId",
                        column: x => x.WebPortalId,
                        principalTable: "WebPortals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscritptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WebPortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscritptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscritptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscritptions_WebPortals_WebPortalId",
                        column: x => x.WebPortalId,
                        principalTable: "WebPortals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WebPortalCathegories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WebPortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CathegoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscritptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Subscritptions_SubscritptionId",
                        column: x => x.SubscritptionId,
                        principalTable: "Subscritptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cathegories_WebPortalEntityModelId",
                table: "Cathegories",
                column: "WebPortalEntityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PostId",
                table: "Notifications",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SubscritptionId",
                table: "Notifications",
                column: "SubscritptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_WebPortalId",
                table: "Posts",
                column: "WebPortalId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscritptions_UserId",
                table: "Subscritptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscritptions_WebPortalId",
                table: "Subscritptions",
                column: "WebPortalId");

            migrationBuilder.CreateIndex(
                name: "IX_WebPortalCathegories_CathegoryId",
                table: "WebPortalCathegories",
                column: "CathegoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WebPortalCathegories_WebPortalId",
                table: "WebPortalCathegories",
                column: "WebPortalId");

            migrationBuilder.CreateIndex(
                name: "IX_WebPortals_OwnerId",
                table: "WebPortals",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "WebPortalCathegories");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Subscritptions");

            migrationBuilder.DropTable(
                name: "Cathegories");

            migrationBuilder.DropTable(
                name: "WebPortals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
