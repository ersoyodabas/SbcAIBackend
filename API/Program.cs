using System.Reflection;
using ExtensionConfigApi.Models;
using Sbc.SERVICE;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
RegisterServiceLayer(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ExtensionCors", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("ExtensionCors");
app.MapControllers();

app.MapGet("/api/health", () => Results.Ok(new { status = "ok", utc = DateTime.UtcNow }));

app.Run();

static string ReadTextOrDefault(string filePath, string fallback)
{
    return File.Exists(filePath) ? File.ReadAllText(filePath) : fallback;
}

static void RegisterServiceLayer(IServiceCollection services)
{
    var serviceAssembly = typeof(IAnnouncementService).Assembly;
    var serviceTypes = serviceAssembly.GetTypes();

    var interfaces = serviceTypes
        .Where(type =>
            type.IsInterface &&
            type.Name.StartsWith("I", StringComparison.Ordinal) &&
            type.Name.EndsWith("Service", StringComparison.Ordinal) &&
            type != typeof(IBaseService))
        .ToList();

    foreach (var serviceInterface in interfaces)
    {
        var implementationName = serviceInterface.Name[1..];
        var implementationType = serviceTypes.FirstOrDefault(type =>
            type.IsClass &&
            !type.IsAbstract &&
            type.Name.Equals(implementationName, StringComparison.Ordinal) &&
            serviceInterface.IsAssignableFrom(type));

        if (implementationType != null)
        {
            services.AddScoped(serviceInterface, implementationType);
        }
    }
}
