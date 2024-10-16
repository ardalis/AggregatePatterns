using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AggregateLoops.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItem_PurchaseOrders_ParentId",
                table: "PurchaseOrderItem");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "PurchaseOrderItem",
                newName: "PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderItem_ParentId",
                table: "PurchaseOrderItem",
                newName: "IX_PurchaseOrderItem_PurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItem_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderItem",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItem_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderItem");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderId",
                table: "PurchaseOrderItem",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderItem_PurchaseOrderId",
                table: "PurchaseOrderItem",
                newName: "IX_PurchaseOrderItem_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItem_PurchaseOrders_ParentId",
                table: "PurchaseOrderItem",
                column: "ParentId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
