using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamTwo.WebShop.OrderService.Infrastructure.Migrations
{
    public partial class singular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItemEf_Orders_OrderEfId",
                table: "ProductItemEf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderEf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderEf",
                table: "OrderEf",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItemEf_OrderEf_OrderEfId",
                table: "ProductItemEf",
                column: "OrderEfId",
                principalTable: "OrderEf",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItemEf_OrderEf_OrderEfId",
                table: "ProductItemEf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderEf",
                table: "OrderEf");

            migrationBuilder.RenameTable(
                name: "OrderEf",
                newName: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItemEf_Orders_OrderEfId",
                table: "ProductItemEf",
                column: "OrderEfId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
