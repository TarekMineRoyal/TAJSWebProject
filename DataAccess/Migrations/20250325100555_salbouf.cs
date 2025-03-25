using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class salbouf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransactions_PaymentMethods_paymentMethodId",
                table: "PaymentTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransactions_Payments_paymentId",
                table: "PaymentTransactions");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransactions_paymentId",
                table: "PaymentTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "paymentMethodId",
                table: "PaymentTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "paymentId",
                table: "PaymentTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_paymentId_paymentMethodId_transactionDate",
                table: "PaymentTransactions",
                columns: new[] { "paymentId", "paymentMethodId", "transactionDate" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransactions_PaymentMethods_paymentMethodId",
                table: "PaymentTransactions",
                column: "paymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_PaymentTransactions_PaymentMethods_paymentMethodId",
                table: "PaymentTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransactions_Payments_paymentId",
                table: "PaymentTransactions");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTransactions_paymentId_paymentMethodId_transactionDate",
                table: "PaymentTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "paymentMethodId",
                table: "PaymentTransactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "paymentId",
                table: "PaymentTransactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_paymentId",
                table: "PaymentTransactions",
                column: "paymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransactions_PaymentMethods_paymentMethodId",
                table: "PaymentTransactions",
                column: "paymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransactions_Payments_paymentId",
                table: "PaymentTransactions",
                column: "paymentId",
                principalTable: "Payments",
                principalColumn: "id");
        }
    }
}
