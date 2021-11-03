using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagement.Migrations
{
    public partial class _202011031034initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietDH",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MaDH = table.Column<int>(nullable: false),
                    MaHH = table.Column<int>(nullable: false),
                    DonGia = table.Column<float>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDH", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MaKH = table.Column<int>(nullable: false),
                    IdKhachHang = table.Column<int>(nullable: false),
                    TenKhachHang = table.Column<string>(nullable: true),
                    NgayLap = table.Column<DateTime>(nullable: true),
                    PhiVanChuyen = table.Column<float>(nullable: false),
                    ThanhTien = table.Column<float>(nullable: false),
                    TongTien = table.Column<float>(nullable: false),
                    TrangThaiDonHang = table.Column<string>(nullable: true),
                    TrangThaiThanhToan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TenHH = table.Column<string>(nullable: true),
                    TenLoai = table.Column<string>(nullable: true),
                    SoLuong = table.Column<int>(nullable: false),
                    DonGia = table.Column<float>(nullable: false),
                    GiamGia = table.Column<float>(nullable: false),
                    ChiTiet = table.Column<string>(nullable: true),
                    IdLoai = table.Column<int>(nullable: false),
                    MaLoai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    HoTen = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MatKhau = table.Column<string>(nullable: true),
                    RandomKey = table.Column<string>(nullable: true),
                    DangHoatDong = table.Column<string>(nullable: true),
                    NhanQuangCao = table.Column<string>(nullable: true),
                    IdLoaiKhachHang = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangDto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    HoTen = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MatKhau = table.Column<string>(nullable: true),
                    RandomKey = table.Column<string>(nullable: true),
                    DangHoatDong = table.Column<string>(nullable: true),
                    NhanQuangCao = table.Column<string>(nullable: true),
                    IdLoaiKhachHang = table.Column<int>(nullable: false),
                    LoaiKhachHang = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loai",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TenLoai = table.Column<string>(nullable: true),
                    Mota = table.Column<string>(nullable: true),
                    MaLoaiCha = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiKhachHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    DiscountCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiKhachHang", x => x.Id);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDH");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "KhachHangDto");

            migrationBuilder.DropTable(
                name: "Loai");

            migrationBuilder.DropTable(
                name: "LoaiKhachHang");
        }
    }
}
