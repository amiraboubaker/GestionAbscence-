using GestionAbscence.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services
builder.Services.AddDbContext<MyContextApp>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

// Map static files (if needed)
app.UseStaticFiles();

// Define routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "etudiant",
    pattern: "Etudiant/{action=Index}/{id?}");

app.Run();
