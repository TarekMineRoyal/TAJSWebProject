using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations.TourAgencyDb
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_CarBookings_carBookingId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TripBookings_tripBookingId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_User_id",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_User_id",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_carBookingId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_tripBookingId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "bookingId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "carBookingId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "tripBookingId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_BookingId",
                table: "TripBookings",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_bookingId",
                table: "CarBookings",
                column: "bookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarBookings_Bookings_bookingId",
                table: "CarBookings",
                column: "bookingId",
                principalTable: "Bookings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripBookings_Bookings_BookingId",
                table: "TripBookings",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBookings_Bookings_bookingId",
                table: "CarBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TripBookings_Bookings_BookingId",
                table: "TripBookings");

            migrationBuilder.DropIndex(
                name: "IX_TripBookings_BookingId",
                table: "TripBookings");

            migrationBuilder.DropIndex(
                name: "IX_CarBookings_bookingId",
                table: "CarBookings");

            migrationBuilder.AddColumn<int>(
                name: "bookingId",
                table: "Regions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "carBookingId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tripBookingId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_carBookingId",
                table: "Bookings",
                column: "carBookingId",
                unique: true,
                filter: "[carBookingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_tripBookingId",
                table: "Bookings",
                column: "tripBookingId",
                unique: true,
                filter: "[tripBookingId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_CarBookings_carBookingId",
                table: "Bookings",
                column: "carBookingId",
                principalTable: "CarBookings",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TripBookings_tripBookingId",
                table: "Bookings",
                column: "tripBookingId",
                principalTable: "TripBookings",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_User_id",
                table: "Customers",
                column: "id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_User_id",
                table: "Employees",
                column: "id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
