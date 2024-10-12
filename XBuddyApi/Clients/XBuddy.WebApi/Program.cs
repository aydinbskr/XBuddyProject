using Microsoft.AspNetCore.Mvc;
using XBuddy.WebApi.Infrastructure.MultiTenant.Extensions;
using XBuddy.WebApi.Infrastructure.MultiTenant.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMultiTenancy();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/{tenantId}/weatherforecast/", ([FromServices] IMultiTenantService service) =>
{
    return $"TenantID:{service.GetCurrentTenantId()}";
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.UseMultiTenancy();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
