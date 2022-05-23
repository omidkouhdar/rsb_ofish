using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RSB_Ofish_System.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ofish",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Staff = table.Column<string>(nullable: true),
                    OfficeId = table.Column<int>(nullable: false),
                    NationCode = table.Column<string>(nullable: true),
                    PicPath = table.Column<string>(nullable: true),
                    OffishTime = table.Column<DateTime>(nullable: false),
                    ExitTime = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ofish_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    sureName = table.Column<string>(nullable: true),
                    sexual = table.Column<int>(nullable: false),
                    OfficeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ofish_OfficeId",
                table: "Ofish",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_OfficeId",
                table: "Staffs",
                column: "OfficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ofish");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Office");
        }
    }
}
