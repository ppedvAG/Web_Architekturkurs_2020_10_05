using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstSampleWithEFCore.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArenaCapacity",
                table: "Clubs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ArenaName",
                table: "Clubs",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArenaCapacity",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "ArenaName",
                table: "Clubs");
        }
    }
}
