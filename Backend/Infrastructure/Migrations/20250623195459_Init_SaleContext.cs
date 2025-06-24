using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init_SaleContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sales");

            migrationBuilder.CreateTable(
                name: "order",
                schema: "sales",
                columns: table => new
                {
                    number = table.Column<string>(type: "text", nullable: false),
                    cargo_weight_in_kg = table.Column<decimal>(type: "numeric", nullable: false),
                    cargo_pickup_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    receiver_address = table.Column<string>(type: "text", nullable: false),
                    receiver_city = table.Column<string>(type: "text", nullable: false),
                    sender_address = table.Column<string>(type: "text", nullable: false),
                    sender_city = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order", x => x.number);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order",
                schema: "sales");
        }
    }
}
