using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationService.Persistence.Migrations
{
    public partial class Added_OrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BuyerName",
                schema: "NotificationService",
                table: "Order",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerEmail",
                schema: "NotificationService",
                table: "Order",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "NotificationService",
                table: "Order",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "NotificationService",
                table: "Order");

            migrationBuilder.AlterColumn<long>(
                name: "BuyerName",
                schema: "NotificationService",
                table: "Order",
                type: "bigint",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BuyerEmail",
                schema: "NotificationService",
                table: "Order",
                type: "bigint",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
