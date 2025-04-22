using BLL.IServices;

using DataAccess;
using DataAccess.Entities;
using DataAccess.Repository.IRepository;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using DataAccess.User;

using AutoMapper;
using BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<CarBookingService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();


//
//builder.Services.AddScoped<CarService>();
//builder.Services.AddScoped<CarBookingService>();
//builder.Services.AddScoped<IPaymentService, PaymentService>();

// Register AutoMapper with the specific profile
builder.Services.AddAutoMapper(typeof(BLL.Profiles.CarProfile));


builder.Services.AddDbContext<TourAgencyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabase")));
builder.Services.AddDbContext<IUserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));

builder.Services.AddScoped<IGenericRepository<Car>, SqlGenericRepository<Car>>();
builder.Services.AddScoped<ICarService, CarService>();  


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<TourAgencyDbContext>();
    dbContext.Database.EnsureCreated(); // Or use Migrate() for migrations
    dbContext.Seed(); // Call the updated Seed method
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();