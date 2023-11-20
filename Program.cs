using AccesoWindows.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

//configurar la base de datos con estos paramatros
builder.Configuration.AddJsonFile("appsettings.json");
var connectionString = builder.Configuration.GetConnectionString("conexionDB");
builder.Services.AddDbContext<AplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

/////////////////////////////////////////////////////////////////////////

// Add services to the container.
builder.Services.AddControllersWithViews();

bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);


if (isWindows)
{
    // Configuración de autenticación de Windows
    builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
       .AddNegotiate()
       .AddCookie();
}
else
{
    // Configuración de autenticación de formularios (Cookies) solo si no es Windows
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.Name = "YourAppCookieName";
            options.LoginPath = "/Account/Login"; // Ruta de la página de inicio de sesión personalizada
        });
}


builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddRazorPages();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
