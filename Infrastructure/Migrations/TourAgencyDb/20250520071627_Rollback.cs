using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.TourAgencyDb
{
    /// <inheritdoc />
    public partial class Rollback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransactions_Payments_paymentId",
                table: "PaymentTransactions");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransactions_Payments_paymentId",
                table: "PaymentTransactions",
                column: "paymentId",
                principalTable: "Payments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransactions_Payments_paymentId",
                table: "PaymentTransactions");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransactions_Payments_paymentId",
                table: "PaymentTransactions",
                column: "paymentId",
                principalTable: "Payments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
