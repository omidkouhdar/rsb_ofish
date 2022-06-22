using Microsoft.EntityFrameworkCore.Migrations;

namespace RSB_Ofish_System.Migrations
{
    public partial class addPlate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ViheclePlate",
                table: "Ofish",
                maxLength:10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViheclePlate",
                table: "Ofish");
        }
    }
}
