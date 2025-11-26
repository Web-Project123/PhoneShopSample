using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using PhoneShop.Application.Interfaces;
using PhoneShop.Application.Services;
using PhoneShop.Infrastructure.Data;
using PhoneShop.Infrastructure.Repositories;
using Serilog;
using System;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

// --------- Serilog bootstrap ----------
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Starting PhoneShop API");

    var builder = WebApplication.CreateBuilder(args);

    // replace default logger with Serilog
    builder.Host.UseSerilog();

    // Add services to the container.
    builder.Services.AddControllers();

    // Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneShop API", Version = "v1" });
    });

    // repository
    builder.Services.AddScoped<IProductRepository, ProductRepository>();

    // AppDb
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<ProductService>();

    var app = builder.Build();

    // Middleware
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneShop API v1"));
    }

    app.UseSerilogRequestLogging(); 

    app.UseRouting();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}












