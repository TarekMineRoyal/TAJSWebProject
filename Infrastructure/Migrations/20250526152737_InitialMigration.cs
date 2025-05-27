using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingType = table.Column<bool>(type: "bit", nullable: false),
                    startDateTime = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    endDateTime = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    numOfPassengers = table.Column<int>(type: "int", nullable: false),
                    employeeId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    method = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PostTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isAvailable = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 50, nullable: false),
                    isPrivate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingId = table.Column<int>(type: "int", nullable: true),
                    satatus = table.Column<int>(type: "int", nullable: false),
                    amountDue = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    amountPaid = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    paymentDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_bookingId",
                        column: x => x.bookingId,
                        principalTable: "Bookings",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    seats = table.Column<int>(type: "int", nullable: false),
                    color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    image = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    mbw = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    pph = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    ppd = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cars_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    views = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    postTypeId = table.Column<int>(type: "int", nullable: true),
                    summary = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    publishDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    employeeId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Posts_PostTypes_postTypeId",
                        column: x => x.postTypeId,
                        principalTable: "PostTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TripPlans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startDateTime = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    endDateTime = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    includedServices = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stops = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mealsPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hotelsStays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    regionId = table.Column<int>(type: "int", nullable: false),
                    tripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripPlans", x => x.id);
                    table.ForeignKey(
                        name: "FK_TripPlans_Regions_regionId",
                        column: x => x.regionId,
                        principalTable: "Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripPlans_Trips_tripId",
                        column: x => x.tripId,
                        principalTable: "Trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    transactionDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    paymentId = table.Column<int>(type: "int", nullable: false),
                    paymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_PaymentMethods_paymentMethodId",
                        column: x => x.paymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_Payments_paymentId",
                        column: x => x.paymentId,
                        principalTable: "Payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarBookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingId = table.Column<int>(type: "int", nullable: false),
                    carId = table.Column<int>(type: "int", nullable: false),
                    pickupLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dropoffLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    withDriver = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_CarBookings_Bookings_bookingId",
                        column: x => x.bookingId,
                        principalTable: "Bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarBookings_Cars_carId",
                        column: x => x.carId,
                        principalTable: "Cars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    postId = table.Column<int>(type: "int", nullable: true),
                    tagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.id);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_postId",
                        column: x => x.postId,
                        principalTable: "Posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_tagId",
                        column: x => x.tagId,
                        principalTable: "Tags",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SeoMetadata",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urlSlug = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    metaTitle = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    metaDescription = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    metaKeywords = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    postId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeoMetadata", x => x.id);
                    table.ForeignKey(
                        name: "FK_SeoMetadata_Posts_postId",
                        column: x => x.postId,
                        principalTable: "Posts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TripBookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    withGuide = table.Column<bool>(type: "bit", nullable: false),
                    tripPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripBookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_TripBookings_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripBookings_TripPlans_tripPlanId",
                        column: x => x.tripPlanId,
                        principalTable: "TripPlans",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TripPlanCars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    tripPlanId = table.Column<int>(type: "int", nullable: true),
                    carId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripPlanCars", x => x.id);
                    table.ForeignKey(
                        name: "FK_TripPlanCars_Cars_carId",
                        column: x => x.carId,
                        principalTable: "Cars",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TripPlanCars_TripPlans_tripPlanId",
                        column: x => x.tripPlanId,
                        principalTable: "TripPlans",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ImageShots",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    carBookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageShots", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImageShots_CarBookings_carBookingId",
                        column: x => x.carBookingId,
                        principalTable: "CarBookings",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_bookingId",
                table: "CarBookings",
                column: "bookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_carId",
                table: "CarBookings",
                column: "carId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_categoryId",
                table: "Cars",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageShots_carBookingId",
                table: "ImageShots",
                column: "carBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_bookingId",
                table: "Payments",
                column: "bookingId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_paymentId",
                table: "PaymentTransactions",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_paymentMethodId",
                table: "PaymentTransactions",
                column: "paymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_postTypeId",
                table: "Posts",
                column: "postTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_postId",
                table: "PostTags",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_tagId",
                table: "PostTags",
                column: "tagId");

            migrationBuilder.CreateIndex(
                name: "IX_SeoMetadata_postId",
                table: "SeoMetadata",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_BookingId",
                table: "TripBookings",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_tripPlanId",
                table: "TripBookings",
                column: "tripPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TripPlanCars_carId",
                table: "TripPlanCars",
                column: "carId");

            migrationBuilder.CreateIndex(
                name: "IX_TripPlanCars_tripPlanId",
                table: "TripPlanCars",
                column: "tripPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TripPlans_regionId",
                table: "TripPlans",
                column: "regionId");

            migrationBuilder.CreateIndex(
                name: "IX_TripPlans_tripId",
                table: "TripPlans",
                column: "tripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageShots");

            migrationBuilder.DropTable(
                name: "PaymentTransactions");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "SeoMetadata");

            migrationBuilder.DropTable(
                name: "TripBookings");

            migrationBuilder.DropTable(
                name: "TripPlanCars");

            migrationBuilder.DropTable(
                name: "CarBookings");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "TripPlans");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "PostTypes");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
