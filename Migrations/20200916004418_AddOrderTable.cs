using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombatAPI.Migrations
{
    public partial class AddOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderJItem_Items_ItemID",
                table: "OrderJItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderJItem_Order_OrderID",
                table: "OrderJItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderJMenu_Menus_MenuID",
                table: "OrderJMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderJMenu_Order_OrderID",
                table: "OrderJMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentJOrder_Order_OrderID",
                table: "PaymentJOrder");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderJMenu",
                table: "OrderJMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderJItem",
                table: "OrderJItem");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ItemMenus");

            migrationBuilder.DropColumn(
                name: "MenusSold",
                table: "OrderJMenu");

            migrationBuilder.DropColumn(
                name: "ItemsSold",
                table: "OrderJItem");

            migrationBuilder.RenameTable(
                name: "OrderJMenu",
                newName: "OrderMenus");

            migrationBuilder.RenameTable(
                name: "OrderJItem",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderJMenu_OrderID",
                table: "OrderMenus",
                newName: "IX_OrderMenus_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderJMenu_MenuID",
                table: "OrderMenus",
                newName: "IX_OrderMenus_MenuID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderJItem_OrderID",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderJItem_ItemID",
                table: "OrderItems",
                newName: "IX_OrderItems_ItemID");

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "ItemMenus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "OrderMenus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    OrderType = table.Column<string>(nullable: true),
                    AmountDue = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Employee = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    OrderStartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Items_ItemID",
                table: "OrderItems",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenus_Menus_MenuID",
                table: "OrderMenus",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenus_Orders_OrderID",
                table: "OrderMenus",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentJOrder_Orders_OrderID",
                table: "PaymentJOrder",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Items_ItemID",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenus_Menus_MenuID",
                table: "OrderMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenus_Orders_OrderID",
                table: "OrderMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentJOrder_Orders_OrderID",
                table: "PaymentJOrder");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "ItemMenus");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "OrderMenus");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderMenus",
                newName: "OrderJMenu");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderJItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenus_OrderID",
                table: "OrderJMenu",
                newName: "IX_OrderJMenu_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenus_MenuID",
                table: "OrderJMenu",
                newName: "IX_OrderJMenu_MenuID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderJItem",
                newName: "IX_OrderJItem_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ItemID",
                table: "OrderJItem",
                newName: "IX_OrderJItem_ItemID");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ItemMenus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenusSold",
                table: "OrderJMenu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemsSold",
                table: "OrderJItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderJMenu",
                table: "OrderJMenu",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderJItem",
                table: "OrderJItem",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountDue = table.Column<double>(type: "float", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Employee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OrderStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderJItem_Items_ItemID",
                table: "OrderJItem",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderJItem_Order_OrderID",
                table: "OrderJItem",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderJMenu_Menus_MenuID",
                table: "OrderJMenu",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderJMenu_Order_OrderID",
                table: "OrderJMenu",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentJOrder_Order_OrderID",
                table: "PaymentJOrder",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
