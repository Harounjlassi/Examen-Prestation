using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using App.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IPrestataireService, PrestataireService>();
builder.Services.AddScoped<IPrestationService, PrestationService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
