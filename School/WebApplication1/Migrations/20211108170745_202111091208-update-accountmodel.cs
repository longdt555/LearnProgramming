using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagement.Migrations
{
    public partial class _202111091208updateaccountmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Account");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Account",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Account",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Account",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Account",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
