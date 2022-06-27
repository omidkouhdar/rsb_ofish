using Microsoft.EntityFrameworkCore.Migrations;

namespace RSB_Ofish_System.Migrations
{
    public partial class addviheclePic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ViheclePic",
                table: "Ofish",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViheclePic",
                table: "Ofish");
        }
    }
}
