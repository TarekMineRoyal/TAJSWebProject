using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Application.IServices;
using Application.Profiles;
using Application.Services;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Application.IRepositories;
using Infrastructure;
using Hotel_Restaurant_Reservation.API.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Domain.Entities;
using Infrastructure.AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();

builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
//builder.Services.AddScoped<CarService>();
//builder.Services.AddScoped<CarBookingService>();
//builder.Services.AddScoped<IPaymentService, PaymentService>();
// Program.cs
builder.Services.AddAutoMapper(typeof(Infrastructure.AssemplyReference).Assembly);


builder.Services.AddScoped<IImageShotService, ImageShotService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ITripBookingService, TripBookingService>();
builder.Services.AddScoped<IGenericRepository<Category>, SqlGenericRepository<Category>>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICarBookingService, CarBookingService>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<ITripPlanService, TripPlanService>();
builder.Services.AddScoped<ITripPlanCarService, TripPlanCarService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IPaymentTransactionService, PaymentTransactionService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<CarBookingService>();
builder.Services.AddScoped<IPaymentTransactionService, PaymentTransactionService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IPostTypeService, PostTypeService>();

// Register AutoMapper for all the profiles
builder.Services.AddAutoMapper(typeof(Infrastructure.AssemplyReference).Assembly);


builder.Services.AddDbContext<TourAgencyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabase")));
builder.Services.AddDbContext<IUserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(SqlGenericRepository<>));
builder.Services.AddScoped<ICarService, CarService>();  


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<TourAgencyDbContext>();
    dbContext.Database.EnsureCreated();
    dbContext.Seed();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();