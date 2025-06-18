using Microsoft.EntityFrameworkCore;
using Application.IServices;
using Application.Services;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Application.IRepositories;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Domain.Entities.AppEntities;
using Infrastructure.Repositories; // <-- Add this using statement
using Microsoft.OpenApi.Models;
using Infrastructure.Authentication;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Seeds;
using Stripe;
using Microsoft.Extensions.FileProviders;


var builder = WebApplication.CreateBuilder(args);

StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Jwt Authentication",
        Description = "Enter a valid JWT bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition("Bearer", securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new String[]{} }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();


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
builder.Services.AddScoped<CarBookingService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IPostTypeService, PostTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICustomerService, Application.Services.CustomerService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IRolePermissionService, RolePermissionService>();
builder.Services.AddScoped<IPayPalService, PayPalService>();
builder.Services.AddScoped<ISEOMetaDataService, SEOMetaDataService>();

builder.Services.AddScoped<IStripeService, StripeService>();

builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<ICustomerService, Application.Services.CustomerService>();

builder.Services.AddScoped<IGenericRepository<CarBooking>, SqlGenericRepository<CarBooking>>();
builder.Services.AddScoped<IGenericRepository<Booking>, SqlGenericRepository<Booking>>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodServices>();
builder.Services.AddAutoMapper(typeof(Application.AssemplyReference).Assembly);


builder.Services.AddDbContext<TourAgencyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabase")));

builder.Services.AddDbContext<CustomIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(SqlGenericRepository<>));
builder.Services.AddScoped(typeof(IUserManagerRepository<>), typeof(SqlUserManagerRepository<>));
builder.Services.AddScoped(typeof(IRoleManagerRepository<>), typeof(SqlRoleManagerRepository<>));

// --- Register the specific Car Repository ---
builder.Services.AddScoped<ICarRepository, SqlCarRepository>();

builder.Services.AddIdentity<User, IdentityRole>(
    options =>
    {
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<CustomIdentityDbContext>()
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>();


builder.Services.AddScoped<ICarService, CarService>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddAuthorization();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<TourAgencyDbContext>();
    //dbContext.Database.EnsureCreated();
    dbContext.Seed();
    app.UseSwagger();
    app.UseSwaggerUI();

}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // Get the correctly configured DbContext from the service provider
    var identityDbContext = services.GetRequiredService<CustomIdentityDbContext>();

    // Pass the configured context to the seeder method
    await IdentitySeed.SeedRolesAndAdmin(userManager, roleManager, identityDbContext);
}

app.UseCors("AllowReactApp");

// 1. This serves files from the default `wwwroot` folder (e.g., for CSS, JS).
app.UseStaticFiles();

// 2. This adds the configuration to serve files from your 'uploads' folder.
var uploadsPath = Path.Combine(builder.Environment.WebRootPath, "uploads");
if (!Directory.Exists(uploadsPath))
{
    Directory.CreateDirectory(uploadsPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/uploads" // This maps the URL path /uploads to the physical folder.
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
