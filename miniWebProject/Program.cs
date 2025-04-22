using BLL.IServices;
using BLL.Services;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repository.IRepository;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using DataAccess.User;
using BLL.MappingProfiles;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContexts
builder.Services.AddDbContext<TourAgencyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabase")));
builder.Services.AddDbContext<IUserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));

// Register Generic Repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


// Replace the existing AutoMapper registration with:
//builder.Services.AddAutoMapper(typeof(MappingProfile)); // Explicitly reference the profile
// Register CarService
builder.Services.AddScoped<ICarService, CarService>();
// Validate AutoMapper configuration
//var mapperConfig = new MapperConfiguration(cfg =>
//{
//    cfg.AddProfile<MappingProfile>();
//});
//mapperConfig.AssertConfigurationIsValid(); // Throws an exception if mappings are invalid// Validate AutoMapper configuration


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<TourAgencyDbContext>();
    dbContext.Database.EnsureCreated(); // Or use Migrate() for migrations
    dbContext.Seed(); // Call the updated Seed method
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();