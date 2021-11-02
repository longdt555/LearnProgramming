using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagement.Migrations
{
    public partial class _202111022226add_seeddata_loaikhachhang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LoaiKhachHang",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DiscountCode", "IsDeleted", "Name", "Type", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 11, 2, 22, 28, 56, 337, DateTimeKind.Local).AddTicks(2625), 2, false, "VIP_1", "V1", 1, new DateTime(2021, 11, 2, 22, 28, 56, 337, DateTimeKind.Local).AddTicks(2625) },
                    { 2, 1, new DateTime(2021, 11, 2, 22, 28, 56, 337, DateTimeKind.Local).AddTicks(2625), 4, false, "VIP_2", "V2", 1, new DateTime(2021, 11, 2, 22, 28, 56, 337, DateTimeKind.Local).AddTicks(2625) },
                    { 3, 1, new DateTime(2021, 11, 2, 22, 28, 56, 337, DateTimeKind.Local).AddTicks(2625), 6, false, "VIP_3", "V3", 1, new DateTime(2021, 11, 2, 22, 28, 56, 337, DateTimeKind.Local).AddTicks(2625) },
                    { 4, 1, new DateTime(2021, 11, 2, 22, 28, 56, 337, DateTimeKind.Local).AddTicks(2625), 8, false, "VIP_4", "V4", 1, new DateTime(2021, 11, 2, 22, 28, 56, 337, DateTimeKind.Local).AddTicks(2625) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
