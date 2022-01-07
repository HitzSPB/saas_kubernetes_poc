using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unik.WebShop.OrderService.Infrastructure.Migrations
{
    public partial class AddedCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderEf");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "OrderEf",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OrderEf");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderEf",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
