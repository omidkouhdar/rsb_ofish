using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RSB_Ofish_System.Migrations
{
    public partial class add2colsToOfish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExitTime",
                table: "Ofish",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "OnExitRegister",
                table: "Ofish",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnExitRegister",
                table: "Ofish");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExitTime",
                table: "Ofish",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
