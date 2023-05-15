using BankAppIdentityProject.DataAccessLayer.Concrete;
using BankAppIdentityProject.EntityLayer.Concrete;
using BankAppIdentityProject.PresentationLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
var services = builder.Services;

services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"), opt =>
    {
        opt.MigrationsAssembly("BankAppIdentityProject.DataAccessLayer");
    });
});

// Buradan CustomValidator tanidilir
builder.Services.AddIdentity<AppUser,AppRole>(opt =>
{
	opt.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AppDbContext>().AddErrorDescriber<CustomIdentityValidator>();
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
