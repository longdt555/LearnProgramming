using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagement.Migrations
{
    public partial class _202111071643updatenamroftablechitiethoadon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhachHangDto");

            migrationBuilder.DeleteData(
                table: "LoaiKhachHang",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LoaiKhachHang",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LoaiKhachHang",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LoaiKhachHang",
                keyColumn: "Id",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHangDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DangHoatDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdLoaiKhachHang = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LoaiKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanQuangCao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RandomKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangDto", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LoaiKhachHang",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DiscountCode", "IsDeleted", "Name", "Type", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 11, 3, 10, 51, 55, 702, DateTimeKind.Local).AddTicks(1394), 2, false, "VIP_1", "V1", 1, new DateTime(2021, 11, 3, 10, 51, 55, 702, DateTimeKind.Local).AddTicks(1394) },
                    { 2, 1, new DateTime(2021, 11, 3, 10, 51, 55, 702, DateTimeKind.Local).AddTicks(1394), 4, false, "VIP_2", "V2", 1, new DateTime(2021, 11, 3, 10, 51, 55, 702, DateTimeKind.Local).AddTicks(1394) },
                    { 3, 1, new DateTime(2021, 11, 3, 10, 51, 55, 702, DateTimeKind.Local).AddTicks(1394), 6, false, "VIP_3", "V3", 1, new DateTime(2021, 11, 3, 10, 51, 55, 702, DateTimeKind.Local).AddTicks(1394) },
                    { 4, 1, new DateTime(2021, 11, 3, 10, 51, 55, 702, DateTimeKind.Local).AddTicks(1394), 8, false, "VIP_4", "V4", 1, new DateTime(2021, 11, 3, 10, 51, 55, 702, DateTimeKind.Local).AddTicks(1394) }
                });
        }
    }
}
