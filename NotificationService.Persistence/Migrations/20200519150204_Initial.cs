using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationService.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NotificationService");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "NotificationService",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 120, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Cost = table.Column<long>(nullable: false),
                    Unit = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "NotificationService",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    BuyerName = table.Column<long>(maxLength: 100, nullable: false),
                    BuyerEmail = table.Column<long>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Adress = table.Column<string>(maxLength: 100, nullable: true),
                    Payment = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "NotificationService",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "NotificationService",
                table: "Product",
                columns: new[] { "Id", "Cost", "Description", "Name", "Unit" },
                values: new object[] { 1L, 800L, "Apple on September 10, 2019, unveiled the iPhone 11, its new flagship $699 smartphone that offers a range of powerful features at an affordable price tag. Sold alongside the more expensive iPhone 11 Pro and the iPhone 11 Pro Max, the iPhone 11 is going to be the iPhone perfect for most people.", "IPhone 11", "$" });

            migrationBuilder.InsertData(
                schema: "NotificationService",
                table: "Product",
                columns: new[] { "Id", "Cost", "Description", "Name", "Unit" },
                values: new object[] { 2L, 1300L, "Xiaomi notebooks are still considered a rarity in Europe and have to be imported from Asia. Not having the opportunity of looking at the device beforehand at your trusted local store, plus the additional effort of making warranty claims etc., makes it all the more important to read reviews of imported products before making your final decision. Notebookcheck has therefore decided that after reviewing the Intel Core i5-8250U version, we will now also take a look at the model with the stronger Intel Core i7-8550U. In this review, we have focused mainly on the device's performance and its differences to the other model that we have already tested.", "Xiaomi Mi Notebook Pro", "$" });

            migrationBuilder.InsertData(
                schema: "NotificationService",
                table: "Product",
                columns: new[] { "Id", "Cost", "Description", "Name", "Unit" },
                values: new object[] { 3L, 400L, "The PlayStation 4 (officially abbreviated as PS4) is an eighth-generation home video game console developed by Sony Computer Entertainment. Announced as the successor to the PlayStation 3 in February 2013, it was launched on November 15 in North America, November 29 in Europe, South America and Australia, and on February 22, 2014 in Japan. It's the 4th best-selling console of all time. It competes with Microsoft's Xbox One and Nintendo's Wii U and Switch.", "PlayStation 4", "$" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                schema: "NotificationService",
                table: "Order",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order",
                schema: "NotificationService");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "NotificationService");
        }
    }
}
