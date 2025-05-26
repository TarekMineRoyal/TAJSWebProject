using Domain.Entities;
using Domain.Entities.AppEntities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class DataSeeder
    {
        public static void Seed(this TourAgencyDbContext dbContext)
        {
            // 1. Seed Categories
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

            // 2. Seed Cars
            if (!dbContext.Cars.Any())
            {
                // Get seeded categories to associate with cars
                var categories = dbContext.Categories.ToList();

                dbContext.Cars.AddRange(
                    // Car 1: Family Sedan
                    new Car
                    {
                        Model = "Toyota Camry",
                        Seats = 5,
                        Color = "Silver",
                        Image = "toyota-camry.jpg",
                        Mbw = 200.50m,
                        Pph = 45.99m,
                        Ppd = 250.00m,
                        Category = categories.FirstOrDefault(c => c.Title == "Sedans")
                    },
                    // Car 2: SUV
                    new Car
                    {
                        Model = "Honda CR-V",
                        Seats = 7,
                        Color = "Black",
                        Image = "honda-cr-v.jpg",
                        Mbw = 300.00m,
                        Pph = 55.50m,
                        Ppd = 300.00m,
                        Category = categories.FirstOrDefault(c => c.Title == "SUVs")
                    },
                    // Car 3: Sports Car
                    new Car
                    {
                        Model = "Ford Mustang",
                        Seats = 4,
                        Color = "Red",
                        Image = "ford-mustang.jpg",
                        Mbw = 150.00m,
                        Pph = 65.00m,
                        Ppd = 350.00m,
                        Category = categories.FirstOrDefault(c => c.Title == "Sports Cars")
                    },
                    // Car 4: Luxury SUV
                    new Car
                    {
                        Model = "BMW X5",
                        Seats = 5,
                        Color = "White",
                        Image = "bmw-x5.jpg",
                        Mbw = 250.00m,
                        Pph = 85.00m,
                        Ppd = 450.00m,
                        Category = categories.FirstOrDefault(c => c.Title == "Luxury")
                    },
                    // Car 5: Electric Sedan
                    new Car
                    {
                        Model = "Tesla Model S",
                        Seats = 5,
                        Color = "Blue",
                        Image = "tesla-model-s.jpg",
                        Mbw = 200.00m,
                        Pph = 75.00m,
                        Ppd = 400.00m,
                        Category = categories.FirstOrDefault(c => c.Title == "Electric")
                    }
                );
                dbContext.SaveChanges();
            }

            // 3. Seed Regions
            if (!dbContext.Regions.Any())
            {
                dbContext.Regions.AddRange(
                    new Region { Name = "North America" },
                    new Region { Name = "Europe" },
                    new Region { Name = "Asia-Pacific" },
                    new Region { Name = "Middle East" }
                );
                dbContext.SaveChanges();
            }
            // 4. Seed Trips
            if (!dbContext.Trips.Any())
            {
                dbContext.Trips.AddRange(
                    new Trip
                    {
                        Slug = "summer-adventure",
                        Description = "Explore sunny beaches and coastal cities.",
                        IsAvailable = true,
                        IsPrivate = false
                    },
                    new Trip
                    {
                        Slug = "winter-wonderland",
                        Description = "Ski resorts and snowy mountain escapes.",
                        IsAvailable = true,
                        IsPrivate = false
                    },
                    new Trip
                    {
                        Slug = "cultural-tour",
                        Description = "Immerse yourself in historical landmarks and traditions.",
                        IsAvailable = true,
                        IsPrivate = false
                    }
                );
                dbContext.SaveChanges();
            }
            // 5. Seed TripPlans
            if (!dbContext.TripPlans.Any())
            {
                // Get seeded regions to associate with tripPlans
                var regions = dbContext.Regions.ToList();
                // Get seeded trips to associate with tripPlans
                var trips = dbContext.Trips.ToList();
                dbContext.TripPlans.AddRange(
                    new TripPlan
                    {
                        StartDateTime = new DateTime(2025, 6, 15),
                        EndDateTime = new DateTime(2025, 6, 22),
                        Duration = 7,
                        IncludedServices = "Flight tickets, 6 nights hotel stay, breakfast daily",
                        Stops = "New York, Miami, Los Angeles",
                        MealsPlan = "Breakfast included at hotels",
                        HotelsStays = "4-star hotels in each city",
                        Region = regions.FirstOrDefault(r => r.Name == "North America"),
                        Trip = trips.FirstOrDefault(t => t.Slug == "summer-adventure")
                    },
                    new TripPlan
                    {
                        StartDateTime = new DateTime(2025, 12, 20),
                        EndDateTime = new DateTime(2025, 12, 27),
                        Duration = 7,
                        IncludedServices = "Flight tickets, ski equipment rental, 6 nights hotel stay",
                        Stops = "Zurich, Innsbruck, Chamonix",
                        MealsPlan = "Dinner included at hotels",
                        HotelsStays = "Chalets in alpine resorts",
                        Region = regions.FirstOrDefault(r => r.Name == "Europe"),
                        Trip = trips.FirstOrDefault(t => t.Slug == "winter-wonderland")
                    },
                    new TripPlan
                    {
                        StartDateTime = new DateTime(2025, 9, 10),
                        EndDateTime = new DateTime(2025, 9, 17),
                        Duration = 7,
                        IncludedServices = "Flight tickets, guided tours, 6 nights hotel stay",
                        Stops = "Tokyo, Seoul, Sydney",
                        MealsPlan = "Lunch and dinner included at local restaurants",
                        HotelsStays = "5-star hotels in major cities",
                        Region = regions.FirstOrDefault(r => r.Name == "Asia-Pacific"),
                        Trip = trips.FirstOrDefault(t => t.Slug == "cultural-tour")
                    }
                );
                dbContext.SaveChanges();
            }
        }
    }
}