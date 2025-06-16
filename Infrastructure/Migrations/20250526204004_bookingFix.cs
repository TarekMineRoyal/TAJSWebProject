using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class bookingFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageShots_CarBookings_carBookingId",
                table: "ImageShots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarBookings",
                table: "CarBookings");

            migrationBuilder.DropIndex(
                name: "IX_CarBookings_bookingId",
                table: "CarBookings");

            migrationBuilder.DropColumn(
                name: "id",
                table: "CarBookings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarBookings",
                table: "CarBookings",
                column: "bookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageShots_CarBookings_carBookingId",
                table: "ImageShots",
                column: "carBookingId",
                principalTable: "CarBookings",
                principalColumn: "bookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageShots_CarBookings_carBookingId",
                table: "ImageShots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarBookings",
                table: "CarBookings");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "CarBookings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarBookings",
                table: "CarBookings",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_bookingId",
                table: "CarBookings",
                column: "bookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageShots_CarBookings_carBookingId",
                table: "ImageShots",
                column: "carBookingId",
                principalTable: "CarBookings",
                principalColumn: "id");
        }
    }
}
