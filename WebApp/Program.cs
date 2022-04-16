using DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SharedLibrary;
using SharedLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(AppDbContext))));
builder.Services.AddScoped<IRepository,Repository>();
builder.Services.AddDatAccessServices(System.Reflection.Assembly.GetAssembly(typeof(AppDbContext)));
builder.Services.AddEmailService(builder.Configuration.GetSection(nameof(AppEmailConfig)).Get<AppEmailConfig>());
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie
    (options=>options.LoginPath="/Account/Login");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
