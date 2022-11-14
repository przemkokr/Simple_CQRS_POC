using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_CQRS_POC.Persistance.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuctionOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Winner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsBuyNow = table.Column<bool>(type: "bit", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    BuyNowValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionId = table.Column<long>(type: "bigint", nullable: false),
                    Bidder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BiddingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bid_Auction_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    AuctionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Auction_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auction_Id",
                table: "Auction",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bid_AuctionId",
                table: "Bid",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_AuctionId",
                table: "Item",
                column: "AuctionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Auction");
        }
    }
}
