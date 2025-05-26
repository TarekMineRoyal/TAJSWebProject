using Microsoft.EntityFrameworkCore;
using Application.IServices;
using Application.Services;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Application.IRepositories;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Domain.Entities.AppEntities;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<CarBookingService>();
builder.Services.AddScoped<IPaymentTransactionService, PaymentTransactionService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IPostTypeService, PostTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IRolePermissionService, RolePermissionService>();

builder.Services.AddAutoMapper(typeof(Application.AssemplyReference).Assembly);


builder.Services.AddDbContext<TourAgencyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabase")));

builder.Services.AddDbContext<CustomIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(SqlGenericRepository<>));
builder.Services.AddScoped(typeof(IUserManagerRepository<>), typeof(SqlUserManagerRepository<>));
builder.Services.AddScoped(typeof(IRoleManagerRepository<>), typeof(SqlRoleManagerRepository<>));

builder.Services.AddScoped<ICarService, CarService>();  


var app = builder.Build();


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