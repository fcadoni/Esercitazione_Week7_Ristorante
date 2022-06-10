using Microsoft.AspNetCore.Authentication.Cookies;
using Ristorante.Core.BusinessLayer;
using Ristorante.Core.Interfaces;
using Ristorante.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configurazione della DI //creo i collegamenti!
builder.Services.AddScoped<IMainBusinessLayer, MainBusinessLayer>();
builder.Services.AddScoped<IRepositoryDishes, RepositoryDishesEF>();
builder.Services.AddScoped<IRepositoryMenus, RepositoryMenusEF>();
builder.Services.AddScoped<IRepositoryUsers, RepositoryUsersEF>();
builder.Services.AddScoped<IRepositoryAdmins, RepositoryAdminsEF>();



//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
//    option =>
//    {
//        option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Login");
//        option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Forbidden");
//    });

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Adm", policy => policy.RequireRole("Administrator"));
//    options.AddPolicy("User", policy => policy.RequireRole("User"));
//});


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

//app.UseAuthentication(); 
//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


