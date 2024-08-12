﻿using Microsoft.EntityFrameworkCore;
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
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<CartService,CartServiceImpl>();
// add session
builder.Services.AddSession(options =>
{
    options.IOTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});
var app = builder.Build();


    


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
