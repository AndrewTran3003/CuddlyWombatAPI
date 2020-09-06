using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuddlyWombatAPI.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    AvailableQuantity = table.Column<int>(nullable: true),
                    QuantitySold = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    AvailableQuantity = table.Column<int>(nullable: true),
                    QuantitySold = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
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
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Method = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    MerchantID = table.Column<string>(nullable: true),
                    OrderDetail = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemMenus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MenuID = table.Column<Guid>(nullable: false),
                    ItemID = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMenus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemMenus_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemMenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderJItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ItemID = table.Column<Guid>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: false),
                    ItemsSold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderJItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderJItem_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderJItem_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderJMenu",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MenuID = table.Column<Guid>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: false),
                    MenusSold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderJMenu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderJMenu_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderJMenu_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentJOrder",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PaymentID = table.Column<Guid>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentJOrder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentJOrder_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentJOrder_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentJReceipt",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ReceiptID = table.Column<Guid>(nullable: false),
                    PaymentID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentJReceipt", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentJReceipt_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentJReceipt_Receipt_ReceiptID",
                        column: x => x.ReceiptID,
                        principalTable: "Receipt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemMenus_ItemID",
                table: "ItemMenus",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMenus_MenuID",
                table: "ItemMenus",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderJItem_ItemID",
                table: "OrderJItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderJItem_OrderID",
                table: "OrderJItem",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderJMenu_MenuID",
                table: "OrderJMenu",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderJMenu_OrderID",
                table: "OrderJMenu",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentJOrder_OrderID",
                table: "PaymentJOrder",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentJOrder_PaymentID",
                table: "PaymentJOrder",
                column: "PaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentJReceipt_PaymentID",
                table: "PaymentJReceipt",
                column: "PaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentJReceipt_ReceiptID",
                table: "PaymentJReceipt",
                column: "ReceiptID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMenus");

            migrationBuilder.DropTable(
                name: "OrderJItem");

            migrationBuilder.DropTable(
                name: "OrderJMenu");

            migrationBuilder.DropTable(
                name: "PaymentJOrder");

            migrationBuilder.DropTable(
                name: "PaymentJReceipt");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Receipt");
        }
    }
}
