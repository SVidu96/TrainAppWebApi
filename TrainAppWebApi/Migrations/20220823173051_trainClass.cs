using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainAppWebApi.Migrations
{
    public partial class trainClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndStation",
                table: "Trains",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartStation",
                table: "Trains",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndStation",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "StartStation",
                table: "Trains");
        }
    }
}
