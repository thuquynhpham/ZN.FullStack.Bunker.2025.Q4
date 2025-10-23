using Bunker.Domain.DBI;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Bunker API",
        Version = "v1",
        Description = "API for managing vessels, ports, voyages, port calls, and bunker orders"
    });

    // Include XML comments if available
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddUserSecrets<Program>(optional: true)
    .AddEnvironmentVariables()
    .Build();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Add DbContext
builder.Services.AddDbContext<BunkerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Bunker.Api")));

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Add UnitOfWork with explicit DbContext dependency
builder.Services.AddScoped<IUnitOfWork>(provider =>
    new UnitOfWork(provider.GetRequiredService<BunkerDbContext>()));

// Add TimeProvider for consistent timestamps
builder.Services.AddSingleton(TimeProvider.System);

// Add Response Caching
builder.Services.AddResponseCaching();

var app = builder.Build();

// Ensure database is created and migrations are applied
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BunkerDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Checking database connection...");

        // Get pending migrations
        var pendingMigrations = context.Database.GetPendingMigrations().ToList();

        if (pendingMigrations.Any())
        {
            logger.LogInformation("Found {Count} pending migrations: {Migrations}", 
                pendingMigrations.Count, string.Join(", ", pendingMigrations));
            
            logger.LogInformation("Applying migrations...");
            context.Database.Migrate();
            
            logger.LogInformation("Database migrations completed successfully.");
        }
        else
        {
            logger.LogInformation("Database is up to date. No migrations needed.");
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating the database.");
        throw;
    }
}

// Configure the HTTP request pipeline.
// Enable Swagger in all environments for testing
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bunker API v1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
});

app.UseHttpsRedirection();

// Add Response Caching
app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();