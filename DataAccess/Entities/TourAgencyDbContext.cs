using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public partial class TourAgencyDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SeoMetadata> SeoMetadata { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<ImageShot> ImageShots { get; set; }


        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CarBooking> CarBookings { get; set; }
        public DbSet<TripBooking> TripBookings { get; set; }


        public TourAgencyDbContext(DbContextOptions<TourAgencyDbContext> options)
            :base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Payment>()
                .ToTable("Payments")
                .Property(e => e.Status)
                .HasConversion<string>();
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethods");
            modelBuilder.Entity<PaymentTransaction>()
                .ToTable("PaymentTransactions")
                .Property(e => e.TransactionType)
                .HasConversion<string>();
            modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<PostTag>().ToTable("PostTags");
            modelBuilder.Entity<SeoMetadata>().ToTable("SeoMetadata");
            modelBuilder.Entity<PostType>().ToTable("PostTypes");
            modelBuilder.Entity<ImageShot>().ToTable("ImageShots");
            //modelBuilder.Entity<Booking>().HasOne(p => p.CarBooking).WithOne(p => p.Booking);//.HasForeignKey<CarBooking>(p => p.BookingId);
            //modelBuilder.Entity<Booking>().HasOne(p => p.TripBooking).WithOne(p => p.Booking);
            modelBuilder.Entity<Booking>().ToTable("Bookings")
                .Property(e => e.Status);
            //    .HasConversion<string>();
            modelBuilder.Entity<CarBooking>().ToTable("CarBookings");
            modelBuilder.Entity<CarBooking>().HasOne(p => p.Booking).WithOne(p => p.CarBooking).HasForeignKey<Booking>(p => p.CarBookingId);
            
            modelBuilder.Entity<TripBooking>().ToTable("TripBookings");
            modelBuilder.Entity<TripBooking>().HasOne(p => p.Booking).WithOne(p => p.TripBooking).HasForeignKey<Booking>(p => p.TripBookingId);

        }
    }
}
