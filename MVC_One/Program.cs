using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb")));
builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 10;
    //Check for more in the login videos. ------------

}).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/auth/signin";
    x.AccessDeniedPath = "/auth/denied";
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
    x.Cookie.Expiration = TimeSpan.FromHours(1);
    x.SlidingExpiration = true;
});
//Create a denied page? ------------


builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();




var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.UseRewriter(new RewriteOptions().AddRedirect("^$", "/projects"));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Projects}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
