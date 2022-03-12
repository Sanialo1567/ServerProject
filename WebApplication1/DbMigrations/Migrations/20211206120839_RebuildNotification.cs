using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class RebuildNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Subscritptions_SubscritptionId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "SubscritptionId",
                table: "Notifications",
                newName: "SubscritptionEntityModelId");

            migrationBuilder.RenameColumn(
                name: "SubscriptionId",
                table: "Notifications",
                newName: "WebPortalId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_SubscritptionId",
                table: "Notifications",
                newName: "IX_Notifications_SubscritptionEntityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_WebPortalId",
                table: "Notifications",
                column: "WebPortalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Subscritptions_SubscritptionEntityModelId",
                table: "Notifications",
                column: "SubscritptionEntityModelId",
                principalTable: "Subscritptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_WebPortals_WebPortalId",
                table: "Notifications",
                column: "WebPortalId",
                principalTable: "WebPortals",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Subscritptions_SubscritptionEntityModelId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_WebPortals_WebPortalId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_WebPortalId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "WebPortalId",
                table: "Notifications",
                newName: "SubscriptionId");

            migrationBuilder.RenameColumn(
                name: "SubscritptionEntityModelId",
                table: "Notifications",
                newName: "SubscritptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_SubscritptionEntityModelId",
                table: "Notifications",
                newName: "IX_Notifications_SubscritptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Subscritptions_SubscritptionId",
                table: "Notifications",
                column: "SubscritptionId",
                principalTable: "Subscritptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
