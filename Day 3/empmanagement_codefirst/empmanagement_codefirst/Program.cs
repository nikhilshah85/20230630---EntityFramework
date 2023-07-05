using empmanagement_codefirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
//builder.Services.AddEntityFramework().AddSQlServer().AddDbContext<employeeDBContext>(options => options.useSqlServer("server=(localdb)\\MSSQLLocalDB;database=empDemoEF;integrated security=true"));

builder.Services.AddDbContext<employeeDBContext>
    (serverInfo => serverInfo.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=empDemoEF;integrated security=true"));






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
