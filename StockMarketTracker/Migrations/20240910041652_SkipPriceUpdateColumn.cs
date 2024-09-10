using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMarketTracker.Migrations
{
    public partial class SkipPriceUpdateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SkipPriceUpdate",
                table: "Tickers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkipPriceUpdate",
                table: "Tickers");
        }
    }
}
