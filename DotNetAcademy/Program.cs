using DotNetAcademy.Components;
using DotNetAcademy.Persistence;
using DotNetAcademy.Persistence.Entities;
using DotNetAcademy.Persistence.Repositories;
using DotNetAcademy.Persistence.Repositories.Interfaces;
using DotNetAcademy.Services.ApplicationUserService;
using DotNetAcademy.Services.ItemService;
using DotNetAcademy.Services.ItemsService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionString"]));

//Repositories
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

//Services
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
