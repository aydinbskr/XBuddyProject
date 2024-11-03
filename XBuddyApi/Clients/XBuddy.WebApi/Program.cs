using Microsoft.AspNetCore.Mvc;
using XBuddy.WebApi.Infrastructure.MultiTenant.Extensions;
using XBuddy.WebApi.Infrastructure.MultiTenant.Services;
using XBuddy.Infra.SqlServer.Extensions;
using XBuddy.WebApi.Infrastructure.Endpoints;
using XBuddy.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMultiTenancy();

builder.Services.AddApplicationServices();

builder.Services.AddSqlServices(builder.Configuration.GetConnectionString("SqlServer"), (sp) =>
{
    var service = sp.GetRequiredService<IMultiTenantService>();
    return service.GetUserId().ToString();
});


builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(opt => opt.SerializerOptions.TypeInfoResolver = XBuddy.WebApi.Infrastructure.SourceGenerators.JsonSerializerContext.Default);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/{tenantId}/weatherforecast/", ([FromServices] IMultiTenantService service) =>
//{
//    return $"TenantID:{service.GetCurrentTenantId()}";
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.RegisterMappings();

app.UseMultiTenancy();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
