using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCodeFirstReverseExample.Migrations
{
    public partial class CodeFirstNewVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FoundingYear = table.Column<DateTime>(nullable: false),
                    TransferBudget = table.Column<long>(nullable: false),
                    ArenaCapacity = table.Column<int>(nullable: false),
                    ArenaName = table.Column<string>(maxLength: 50, nullable: false),
                    ClubColors = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
