using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerOrderApp.Data.Migrations
{
    public partial class productData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "permission",
                column: "v",
                value: "SYSTEM_MANAGE");

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "barcode", "create_time", "description", "modifier", "owner", "price", "quantity", "status", "Update_time" },
                values: new object[] { 1ul, "Barcode", 1654358265000L, "New Product", "EF", "EF", 10.0, 5ul, "ACTIVE", 1654358265000L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "v",
                keyValue: "SYSTEM_MANAGE");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 1ul);
        }
    }
}
