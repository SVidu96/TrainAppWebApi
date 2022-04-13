using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainAppWebApi.Migrations
{
    public partial class UserLoginMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    NicNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
