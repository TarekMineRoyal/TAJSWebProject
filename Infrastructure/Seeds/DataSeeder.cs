using Domain.Entities.AppEntities;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure
{
    public static class DataSeeder
    {
        public static void Seed(this TourAgencyDbContext dbContext)
        {
            // Seed Categories
            if (!dbContext.Categories.Any())
            {
                dbContext.Categories.AddRange(
                    new Category { Title = "Sedans" },
                    new Category { Title = "SUVs" },
                    new Category { Title = "Luxury" },
                    new Category { Title = "Electric" },
                    new Category { Title = "Sports Cars" }
                );
                dbContext.SaveChanges();
            }

            // Seed Cars
            if (!dbContext.Cars.Any())
            {
                var categories = dbContext.Categories.ToList();
                dbContext.Cars.AddRange(
                    new Car { Model = "Toyota Camry", Seats = 5, Color = "Silver", Image = "toyota-camry.jpg", Mbw = 200.50m, Pph = 45.99m, Ppd = 250.00m, CategoryId = categories.First(c => c.Title == "Sedans").Id },
                    new Car { Model = "Honda CR-V", Seats = 7, Color = "Black", Image = "honda-cr-v.jpg", Mbw = 300.00m, Pph = 55.50m, Ppd = 300.00m, CategoryId = categories.First(c => c.Title == "SUVs").Id },
                    new Car { Model = "Ford Mustang", Seats = 4, Color = "Red", Image = "ford-mustang.jpg", Mbw = 150.00m, Pph = 65.00m, Ppd = 350.00m, CategoryId = categories.First(c => c.Title == "Sports Cars").Id }
                );
                dbContext.SaveChanges();
            }

            // Seed Regions
            if (!dbContext.Regions.Any())
            {
                dbContext.Regions.AddRange(
                    new Region { Name = "North America" },
                    new Region { Name = "Europe" },
                    new Region { Name = "Asia-Pacific" }
                );
                dbContext.SaveChanges();
            }

            // Seed Trips
            if (!dbContext.Trips.Any())
            {
                dbContext.Trips.AddRange(
                    new Trip { Slug = "summer-adventure", Description = "Explore sunny beaches and coastal cities.", IsAvailable = true, IsPrivate = false },
                    new Trip { Slug = "winter-wonderland", Description = "Ski resorts and snowy mountain escapes.", IsAvailable = true, IsPrivate = false }
                );
                dbContext.SaveChanges();
            }

            // Seed TripPlans
            if (!dbContext.TripPlans.Any())
            {
                var regions = dbContext.Regions.ToList();
                var trips = dbContext.Trips.ToList();
                dbContext.TripPlans.AddRange(
                    new TripPlan { StartDateTime = new DateTime(2025, 6, 15), EndDateTime = new DateTime(2025, 6, 22), Duration = 7, IncludedServices = "Flights, Hotels, Breakfast", Stops = "New York, Miami", MealsPlan = "Breakfast", HotelsStays = "4-star hotels", RegionId = regions.First(r => r.Name == "North America").Id, TripId = trips.First(t => t.Slug == "summer-adventure").Id },
                    new TripPlan { StartDateTime = new DateTime(2025, 12, 20), EndDateTime = new DateTime(2025, 12, 27), Duration = 7, IncludedServices = "Flights, Ski Pass, Chalet", Stops = "Zurich, Innsbruck", MealsPlan = "Half-board", HotelsStays = "Alpine chalets", RegionId = regions.First(r => r.Name == "Europe").Id, TripId = trips.First(t => t.Slug == "winter-wonderland").Id }
                );
                dbContext.SaveChanges();
            }

            // Seed TripPlanCars
            if (!dbContext.TripPlanCars.Any())
            {
                var tripPlans = dbContext.TripPlans.ToList();
                var cars = dbContext.Cars.ToList();
                dbContext.TripPlanCars.AddRange(
                    new TripPlanCar { TripPlanId = tripPlans[0].Id, CarId = cars[0].Id, Price = 1500.00m },
                    new TripPlanCar { TripPlanId = tripPlans[1].Id, CarId = cars[1].Id, Price = 2000.00m }
                );
                dbContext.SaveChanges();
            }

            // Seed Tags
            if (!dbContext.Tags.Any())
            {
                dbContext.Tags.AddRange(
                    new Tag { Name = "Travel" },
                    new Tag { Name = "Adventure" },
                    new Tag { Name = "Tips" }
                );
                dbContext.SaveChanges();
            }

            // Seed PostTypes
            if (!dbContext.PostTypes.Any())
            {
                dbContext.PostTypes.AddRange(
                    new PostType { Title = "Blog Post", Description = "General travel stories and articles." },
                    new PostType { Title = "Travel Guide", Description = "In-depth guides to destinations." }
                );
                dbContext.SaveChanges();
            }

            // Seed Posts
            if (!dbContext.Posts.Any())
            {
                var postTypes = dbContext.PostTypes.ToList();
                dbContext.Posts.AddRange(
                    new Post { Title = "Top 5 Summer Destinations", Body = "...", Image = "summer.jpg", Slug = "summer-destinations", Views = 150, Status = PostStatus.Published, PostTypeId = postTypes[0].Id, Summary = "Discover the best places to visit this summer.", PublishDate = DateTime.Now.AddDays(-10), EmployeeId = "seeded-employee-id" },
                    new Post { Title = "A Guide to European Christmas Markets", Body = "...", Image = "christmas-market.jpg", Slug = "european-christmas-markets", Views = 200, Status = PostStatus.Published, PostTypeId = postTypes[1].Id, Summary = "Everything you need to know about Europe's magical Christmas markets.", PublishDate = DateTime.Now.AddDays(-5), EmployeeId = "seeded-employee-id" }
                );
                dbContext.SaveChanges();
            }

            // Seed PostTags
            if (!dbContext.PostTags.Any())
            {
                var posts = dbContext.Posts.ToList();
                var tags = dbContext.Tags.ToList();
                dbContext.PostTags.AddRange(
                    new PostTag { PostId = posts[0].Id, TagId = tags.First(t => t.Name == "Travel").Id },
                    new PostTag { PostId = posts[0].Id, TagId = tags.First(t => t.Name == "Adventure").Id },
                    new PostTag { PostId = posts[1].Id, TagId = tags.First(t => t.Name == "Travel").Id },
                    new PostTag { PostId = posts[1].Id, TagId = tags.First(t => t.Name == "Tips").Id }
                );
                dbContext.SaveChanges();
            }

            // Seed PaymentMethods
            if (!dbContext.PaymentMethods.Any())
            {
                dbContext.PaymentMethods.AddRange(
                    new PaymentMethod { Method = "Credit Card", Icon = "fa-credit-card" },
                    new PaymentMethod { Method = "PayPal", Icon = "fa-paypal" }
                );
                dbContext.SaveChanges();
            }

            // Seed Bookings and Payments (Example Data)
            if (!dbContext.Bookings.Any())
            {
                var carBooking = new Booking { BookingType = true, StartDateTime = DateTime.Now.AddDays(10), EndDateTime = DateTime.Now.AddDays(17), NumberOfPassengers = 2, Status = BType.Approved };
                var tripBooking = new Booking { BookingType = false, StartDateTime = DateTime.Now.AddMonths(2), EndDateTime = DateTime.Now.AddMonths(2).AddDays(7), NumberOfPassengers = 4, Status = BType.Pending };

                dbContext.Bookings.AddRange(carBooking, tripBooking);
                dbContext.SaveChanges();

                var cars = dbContext.Cars.ToList();
                var tripPlans = dbContext.TripPlans.ToList();

                dbContext.CarBookings.Add(new CarBooking { BookingId = carBooking.Id, CarId = cars.First().Id, PickupLocation = "Airport", DropoffLocation = "Downtown", WithDriver = false });
                dbContext.TripBookings.Add(new TripBooking { BookingId = tripBooking.Id, TripPlanId = tripPlans.First().Id, WithGuide = true });
                dbContext.SaveChanges();

                var paymentMethods = dbContext.PaymentMethods.ToList();
                var paymentForCarBooking = new Payment { BookingId = carBooking.Id, Status = StatusEnum.Complete, AmountDue = 1750.00m, AmountPaid = 1750.00m, PaymentDate = DateTime.Now.AddDays(-1) };
                dbContext.Payments.Add(paymentForCarBooking);
                dbContext.SaveChanges();

                dbContext.PaymentTransactions.Add(new PaymentTransaction { PaymentId = paymentForCarBooking.Id, Amount = 1750.00m, TransactionDate = DateTime.Now.AddDays(-1), TransactionType = TType.Final, PaymentMethodId = paymentMethods.First().Id });
                dbContext.SaveChanges();
            }

        }
    }
}