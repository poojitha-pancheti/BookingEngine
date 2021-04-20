using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingEngine.Migrations
{
    public partial class ReservationForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_rooms",
                table: "rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_guests",
                table: "guests");

            migrationBuilder.RenameTable(
                name: "rooms",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "guests",
                newName: "Guest");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Rooms",
                newName: "RoomID");

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guest",
                table: "Guest",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_GuestId",
                table: "Reservation",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId",
                table: "Reservation",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Guest_GuestId",
                table: "Reservation",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Rooms_RoomId",
                table: "Reservation",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Guest_GuestId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Rooms_RoomId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_GuestId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_RoomId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guest",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "rooms");

            migrationBuilder.RenameTable(
                name: "Guest",
                newName: "guests");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "rooms",
                newName: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rooms",
                table: "rooms",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_guests",
                table: "guests",
                column: "GuestId");
        }
    }
}
