using Blazored.Modal;
using Inventory.Components;
using Inventory.Services;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ProductService>();

builder.Services.AddScoped(sp =>
{
    var handler = new HttpClientHandler
    {
        // WARNING: This bypasses SSL certificate validation.
        // Use only in development. Remove or adjust for production.
        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
    };

    return new HttpClient(handler)
    {
        BaseAddress = new Uri("https://10.0.0.13:7081/")
    };
});

builder.Services.AddBlazoredModal();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
