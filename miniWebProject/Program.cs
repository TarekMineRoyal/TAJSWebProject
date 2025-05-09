using DataAccess.Entities;
using DataAccess.User;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TourAgencyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabase")));
builder.Services.AddDbContext<IUserDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
