using Microsoft.AspNetCore.Mvc;
using XBuddy.Blazor.Client.Pages;
using XBuddy.Blazor.Components;
using XBuddy.Blazor.Services;
using XBuddyModels.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents() 
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<ITenantService, TenantService>();
builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("backendapi");
});

builder.Services.AddHttpClient("backendapi", (sp, client) =>
{
    var tenantService = sp.GetRequiredService<ITenantService>();
    var tenantId = tenantService.GetTenantId();

    var baseUrl = string.Concat(builder.Configuration["Urls:BackendApi"], tenantId, '/');

    client.BaseAddress = new Uri(baseUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//Middleware
app.Use((context, next) =>
{
    var routeValue = context.Request.RouteValues.TryGetValue(MultiTenantConstants.TenantId, out var value) ? value : null;
    if (routeValue != null)
    {
        context.RequestServices.GetRequiredService<ITenantService>().SetTenantId(value.ToString());
    }
    return next.Invoke();
});



//Receive request from WASM Client
app.MapGet("feed", ([FromServices] HttpClient client,
                [FromServices] IHttpContextAccessor contextAccessor) =>
{ 
                var request = contextAccessor.HttpContext.Request;
                var feedUrl = string.Concat(request.Path.Value.TrimStart('/'), request.QueryString);
                
    return client.GetStringAsync(feedUrl);
});

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
