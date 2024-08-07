using Microsoft.EntityFrameworkCore;
using ProjectDotNet.Database;
using ProjectDotNet.Services;
using System.Data.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<MyDBContext>(option => option.UseLazyLoadingProxies().UseMySQL(connectionString));
builder.Services.AddScoped<ProductService, ProductServiceImpl>();
builder.Services.AddScoped<CategoryService,CategoryServiceImpl>();
var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
