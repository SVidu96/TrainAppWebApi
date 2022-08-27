using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainAppWebApi.Migrations
{
    public partial class rfidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRFID",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RfidNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRFID", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRFID");
        }
    }
}
