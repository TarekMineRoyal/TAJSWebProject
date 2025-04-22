using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class DataSeeder
    {
        public static void Seed(this TourAgencyDbContext dbContext)
        {
            if (!dbContext.Cars.Any())
            {
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
                        Ppd = 250.00m
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
                        Ppd = 300.00m
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
                        Ppd = 350.00m
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
                        Ppd = 450.00m
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
                        Ppd = 400.00m
                    },
                    // Car 6: Luxury Sedan
                    new Car
                    {
                        Model = "Mercedes-Benz E-Class",
                        Seats = 5,
                        Color = "Black",
                        Image = "mercedes-e-class.jpg",
                        Mbw = 180.00m,
                        Pph = 90.00m,
                        Ppd = 480.00m
                    },
                    // Car 7: Compact SUV
                    new Car
                    {
                        Model = "Hyundai Tucson",
                        Seats = 5,
                        Color = "Gray",
                        Image = "hyundai-tucson.jpg",
                        Mbw = 220.00m,
                        Pph = 40.00m,
                        Ppd = 220.00m
                    },
                    // Car 8: Full-Size SUV
                    new Car
                    {
                        Model = "Chevrolet Suburban",
                        Seats = 8,
                        Color = "Black",
                        Image = "chevy-suburban.jpg",
                        Mbw = 400.00m,
                        Pph = 70.00m,
                        Ppd = 380.00m
                    },
                    // Car 9: Electric Hatchback
                    new Car
                    {
                        Model = "Nissan Leaf",
                        Seats = 5,
                        Color = "White",
                        Image = "nissan-leaf.jpg",
                        Mbw = 150.00m,
                        Pph = 50.00m,
                        Ppd = 275.00m
                    },
                    // Car 10: Sports Convertible
                    new Car
                    {
                        Model = "Porsche 911",
                        Seats = 2,
                        Color = "Yellow",
                        Image = "porsche-911.jpg",
                        Mbw = 100.00m,
                        Pph = 150.00m,
                        Ppd = 800.00m
                    }
                );
                dbContext.SaveChanges();
            }
        }
    }
}