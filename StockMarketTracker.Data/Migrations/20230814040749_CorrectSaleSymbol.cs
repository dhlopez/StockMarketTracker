using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMarketTracker.Data.Migrations
{
    public partial class CorrectSaleSymbol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Tickers_TickerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_TickerId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TickerId",
                table: "Sales");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "TickerId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_TickerId",
                table: "Sales",
                column: "TickerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Tickers_TickerId",
                table: "Sales",
                column: "TickerId",
                principalTable: "Tickers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
