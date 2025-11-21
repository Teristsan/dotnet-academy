using DotNetAcademy.Components;
using DotNetAcademy.Persistence;
using DotNetAcademy.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionString"]));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
	options.SignIn.RequireConfirmedAccount = false;
	options.Password.RequireDigit = true;
	options.Password.RequiredLength = 6;
	options.Password.RequireNonAlphanumeric = false;
})
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
	options.LoginPath = "/login";
	options.AccessDeniedPath = "/Account/AccessDenied";
	options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
