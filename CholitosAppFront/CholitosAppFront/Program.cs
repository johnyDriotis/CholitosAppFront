using CholitosAppFront.Configuration;
using CholitosAppFront.Configuration.Interfaces;
using CholitosAppFront.Repository;
using CholitosAppFront.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

#region Configuraciones #1 contenedor de servicios e inyeccion de dependencias.

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get configuration of appsettings.json
IConfiguration configuration = builder.Configuration;

Properties properties = new Properties(configuration);

// Add properties service to container of dependency injection
builder.Services.AddScoped<IProperties, Properties>();

// Add repository service to container of dependency injection
builder.Services.AddScoped<ITestConnection, TestConnection>();

#endregion

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
