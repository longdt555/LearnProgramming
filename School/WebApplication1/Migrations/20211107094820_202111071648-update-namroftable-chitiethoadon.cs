using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagement.Migrations
{
    public partial class _202111071648updatenamroftablechitiethoadon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDH",
                table: "ChiTietDH");

            migrationBuilder.RenameTable(
                name: "ChiTietDH",
                newName: "ChiTietDonHang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDonHang",
                table: "ChiTietDonHang",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDonHang",
                table: "ChiTietDonHang");

            migrationBuilder.RenameTable(
                name: "ChiTietDonHang",
                newName: "ChiTietDH");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDH",
                table: "ChiTietDH",
                column: "Id");
        }
    }
}
