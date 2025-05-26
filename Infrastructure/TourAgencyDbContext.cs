using Domain.Entities.AppEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    /// <summary>
    /// The main database context for the Tour Agency application
    /// </summary>
    public partial class TourAgencyDbContext : DbContext
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the TourAgencyDbContext
        /// </summary>
        /// <param name="options">The options to be used by the DbContext</param>
        public TourAgencyDbContext(DbContextOptions<TourAgencyDbContext> options)
            : base(options)
        {
        }
        #endregion

        #region DbSets - Vehicle Rental
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBooking> CarBookings { get; set; }
        #endregion

        #region DbSets - Trip Management
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripPlan> TripPlans { get; set; }
        public DbSet<TripPlanCar> TripPlanCars { get; set; }
        public DbSet<TripBooking> TripBookings { get; set; }
        public DbSet<Region> Regions { get; set; }
        #endregion

        #region DbSets - Booking System
        public DbSet<Booking> Bookings { get; set; }
        #endregion

        #region DbSets - Payment System
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        #endregion

        #region DbSets - Content Management
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SeoMetadata> SeoMetadata { get; set; }
        #endregion

        #region DbSets - Media
        public DbSet<ImageShot> ImageShots { get; set; }
        #endregion

        //#region Model Configuration
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Configure enum conversions and table mappings
        //    ConfigureEnumsAndTables(modelBuilder);

        //    // Configure relationships
        //    ConfigureRelationships(modelBuilder);
        //}

        //private void ConfigureEnumsAndTables(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().ToTable("Categories");
        //    modelBuilder.Entity<Car>().ToTable("Cars");

        //    modelBuilder.Entity<Payment>()
        //        .ToTable("Payments")
        //        .Property(e => e.Status)
        //        .HasConversion<string>();

            
            

        //    modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethods");

        //    modelBuilder.Entity<PaymentTransaction>()
        //        .ToTable("PaymentTransactions")
        //        .Property(e => e.TransactionType)
        //        .HasConversion<string>();

            

            




        //    modelBuilder.Entity<PaymentTransaction>().HasIndex(p => new { p.PaymentId, p.PaymentMethodId, p.TransactionDate }).IsUnique(true);

        //    modelBuilder.Entity<Tag>().ToTable("Tags");

        //    modelBuilder.Entity<Post>()
        //        .ToTable("Posts")
        //        .Property(e => e.Status)
        //        .HasConversion<string>();

        //    modelBuilder.Entity<PostTag>().ToTable("PostTags");
        //    modelBuilder.Entity<SeoMetadata>().ToTable("SeoMetadata");
        //    modelBuilder.Entity<PostType>().ToTable("PostTypes");
        //    modelBuilder.Entity<ImageShot>().ToTable("ImageShots");

        //    modelBuilder.Entity<Booking>()
        //        .ToTable("Bookings")
        //        .Property(e => e.Status)
        //        .HasConversion<string>();

        //    modelBuilder.Entity<CarBooking>().ToTable("CarBookings");
        //    modelBuilder.Entity<TripBooking>().ToTable("TripBookings");
        //    modelBuilder.Entity<TripPlan>().ToTable("TripPlans");
        //    modelBuilder.Entity<TripPlanCar>().ToTable("TripPlanCars");
        //    modelBuilder.Entity<Region>().ToTable("Regions");
        //    modelBuilder.Entity<Trip>().ToTable("Trips");
        //    modelBuilder.Entity<Employee>().ToTable("Employees");
        //    modelBuilder.Entity<Customer>().ToTable("Customers");
        //}

        //private void ConfigureRelationships(ModelBuilder modelBuilder)
        //{
        //    // Configure the one-to-one relationship between Booking and CarBooking
        //    modelBuilder.Entity<Booking>()
        //        .HasOne(p => p.CarBooking)
        //        .WithOne(p => p.Booking)
        //        .HasForeignKey<CarBooking>(p => p.BookingId);

        //    // Configure the one-to-one relationship between Booking and TripBooking
        //    modelBuilder.Entity<Booking>()
        //        .HasOne(p => p.TripBooking)
        //        .WithOne(p => p.Booking)
        //        .HasForeignKey<TripBooking>(p => p.BookingId);


        //}
        //#endregion
    }
}