using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ShopLite.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

LoadInfrastructure(builder.Services);

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var seeder = scope.ServiceProvider.GetService<IDataSeeder>();
    if (seeder is not null)
    {
        await seeder.SeedAsync(CancellationToken.None);
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

static void LoadInfrastructure(IServiceCollection services)
{
    const string infrastructureAssemblyName = "ShopLite.Infrastructure";
    var assembly = Assembly.Load(infrastructureAssemblyName);
    var diType = assembly.GetType("ShopLite.Infrastructure.DependencyInjection");
    var method = diType?.GetMethod("AddInfrastructure", BindingFlags.Public | BindingFlags.Static);

    if (method is null)
    {
        throw new InvalidOperationException($"Unable to locate AddInfrastructure in {infrastructureAssemblyName}.");
    }

    _ = method.Invoke(null, new object?[] { services });
}
