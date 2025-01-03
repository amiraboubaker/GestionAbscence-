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
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Etudiant}/{action=Create}/");

app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "etudiant",
    pattern: "Etudiant/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "etudiant",
    pattern: "Etudiant/{action=Create}/");

app.MapControllerRoute(
    name: "etudiant",
    pattern: "Etudiant/{action=Edit}/{id?}");

app.MapControllerRoute(
    name: "etudiant",
    pattern: "Etudiant/{action=Delete}/{id?}");

app.MapControllerRoute(
    name: "matiere",
    pattern: "Matiere/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "matiere",
    pattern: "Matiere/{action=Create}/{id?}");

app.MapControllerRoute(
    name: "matiere",
    pattern: "Matiere/{action=Edit}/{id?}");

app.MapControllerRoute(
    name: "matiere",
    pattern: "Matiere/{action=Delete}/{id?}");

app.MapControllerRoute(
    name: "absence",
    pattern: "Absence/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "absence",
    pattern: "Absence/{action=Create}/{id?}");

app.MapControllerRoute(
    name: "absence",
    pattern: "Absence/{action=Edit}/{id?}");

app.MapControllerRoute(
    name: "absence",
    pattern: "Absence/{action=Delete}/{id?}");
app.Run();
