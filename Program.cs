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
builder.Services.AddScoped<EmployeeService, EmployeeServiceImpl>();
builder.Services.AddScoped<PriorityService, PriorityServiceImpl>();
builder.Services.AddScoped<RequestService, RequestServiceImpl>();
//
/*cau hinh security*/
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {
    option.LoginPath = "/Login/index";
    option.AccessDeniedPath = "/Denied/Index";
    
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