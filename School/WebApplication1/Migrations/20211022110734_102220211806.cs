using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagement.Migrations
{
    public partial class _102220211806 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaKH",
                table: "DonHang");

            migrationBuilder.AddColumn<int>(
                name: "IdLoai",
                table: "HangHoa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TenLoai",
                table: "HangHoa",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdKhachHang",
                table: "DonHang",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TenKhachHang",
                table: "DonHang",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdLoai",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "TenLoai",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "IdKhachHang",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "TenKhachHang",
                table: "DonHang");

            migrationBuilder.AddColumn<int>(
                name: "MaKH",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
