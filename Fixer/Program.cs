using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Fixer.Areas.Identity.Data;
using Fixer.Configuration;
using Fixer.Services;
using Fixer.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'Default' not found.");

builder.Services.AddScoped<I_ServiceCategoryRepo, ServiceCategoryRepo>();
builder.Services.AddScoped<I_ServiceRepo, ServiceRepo>();

builder.Services.AddDbContext<FixerContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<FixerUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FixerContext>();

//Email Confihuration
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
