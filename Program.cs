using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ MVC vào container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình pipeline xử lý HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



// Cấu hình route
app.MapControllerRoute(
      name: "default",
    pattern: "{action=Index}/{id?}",
    defaults: new { controller = "Home" });

app.Run();
