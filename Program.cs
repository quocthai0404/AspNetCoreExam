using AspdotNetCoreMVCExam.Models;
using AspdotNetCoreMVCExam.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession();



var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => {
    option.UseLazyLoadingProxies().UseSqlServer(connectionString);
});

//service
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
//
/*cau hinh security*/
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {
    option.LoginPath = "/Login/index";
    
});
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "myareas",
    pattern: "{area:exists}/{controller}/{action}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}"
);

app.Run();