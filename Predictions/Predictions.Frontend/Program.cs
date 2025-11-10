using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Predictions.Frontend;
using Predictions.Frontend.Repositories;
using MudBlazor.Services;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7058") });
builder.Services.AddMudServices();
builder.Services.AddSweetAlert2();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddLocalization();

await builder.Build().RunAsync();