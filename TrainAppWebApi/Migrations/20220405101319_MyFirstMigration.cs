using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainAppWebApi.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchasedTickets",
                columns: table => new
                {
                    PurchasedTicketId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    TicketType = table.Column<int>(nullable: false),
                    FromStation = table.Column<string>(nullable: false),
                    ToStation = table.Column<string>(nullable: false),
                    TicketClass = table.Column<int>(nullable: false),
                    PurchasedDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedTickets", x => x.PurchasedTicketId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedTickets");
        }
    }
}
