using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingEngine.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "rooms");

            migrationBuilder.AddColumn<byte[]>(
                name: "ByteArrayImage",
                table: "rooms",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ByteArrayImage",
                table: "rooms");

            migrationBuilder.AddColumn<byte>(
                name: "Images",
                table: "rooms",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
