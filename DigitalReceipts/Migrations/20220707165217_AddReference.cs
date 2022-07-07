using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalReceipts.Migrations
{
    public partial class AddReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Receipts",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Receipts");
        }
    }
}
