using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddScoped(client =>
{
    return new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
});

builder.Services.AddHttpClient("postviewapi", (sp, client) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var baseUrl = configuration["Urls:PostViewApi"];

    var logger = sp.GetRequiredService<ILogger<Program>>(); 
    logger.LogInformation($"PostViewApi: {baseUrl}");
    client.BaseAddress = new Uri(baseUrl);
});


await builder.Build().RunAsync();
