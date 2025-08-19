using BlazorWebAppMovies.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlazorWebAppMovies.Data;
using BlazorWebAppMovies.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<BlazorWebAppMoviesContext>(options =>
    options.UseInMemoryDatabase("BlazorWebAppMovies"));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure MyFlood API
builder.Services.Configure<MyFloodOptions>(
    builder.Configuration.GetSection("MyFlood"));

builder.Services.AddHttpClient<MyFloodApiService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
