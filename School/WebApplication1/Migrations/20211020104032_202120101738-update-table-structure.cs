using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagement.Migrations
{
    public partial class _202120101738updatetablestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateddBy",
                table: "ChiTietDH");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Loai",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Loai",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Loai",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Loai",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Loai",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "KhachHang",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "KhachHang",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "KhachHang",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "KhachHang",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "KhachHang",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "HangHoa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "HangHoa",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HangHoa",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "HangHoa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "HangHoa",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "DonHang",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DonHang",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DonHang",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "DonHang",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "DonHang",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "ChiTietDH",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Loai");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Loai");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Loai");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Loai");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Loai");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ChiTietDH");

            migrationBuilder.AddColumn<int>(
                name: "UpdateddBy",
                table: "ChiTietDH",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
