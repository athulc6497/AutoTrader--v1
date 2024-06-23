using AutoTrader.Web.Components;
using AutoTrader.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<IRegisterService, RegisterService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7154/");
});
builder.Services.AddHttpClient<ICarListService, CarListService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7154/");
});
builder.Services.AddHttpClient<IVehicleTypeService, VehicleTypeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7154/");
});
builder.Services.AddHttpClient<ITransmissionService, TransmissionService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7154/");
});
builder.Services.AddHttpClient<ISeatingCapacityService, SeatingCapacityService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7154/");
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
