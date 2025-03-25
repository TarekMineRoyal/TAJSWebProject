using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class samra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripPlanCars_TripPlans_tripPlanIdId",
                table: "TripPlanCars");

            migrationBuilder.RenameColumn(
                name: "tripPlanIdId",
                table: "TripPlanCars",
                newName: "tripPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_TripPlanCars_tripPlanIdId",
                table: "TripPlanCars",
                newName: "IX_TripPlanCars_tripPlanId");

            migrationBuilder.RenameColumn(
                name: "bookingId",
                table: "TripBookings",
                newName: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripPlanCars_TripPlans_tripPlanId",
                table: "TripPlanCars",
                column: "tripPlanId",
                principalTable: "TripPlans",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripPlanCars_TripPlans_tripPlanId",
                table: "TripPlanCars");

            migrationBuilder.RenameColumn(
                name: "tripPlanId",
                table: "TripPlanCars",
                newName: "tripPlanIdId");

            migrationBuilder.RenameIndex(
                name: "IX_TripPlanCars_tripPlanId",
                table: "TripPlanCars",
                newName: "IX_TripPlanCars_tripPlanIdId");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "TripBookings",
                newName: "bookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripPlanCars_TripPlans_tripPlanIdId",
                table: "TripPlanCars",
                column: "tripPlanIdId",
                principalTable: "TripPlans",
                principalColumn: "id");
        }
    }
}
