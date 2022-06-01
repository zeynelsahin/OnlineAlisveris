

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using OnlineAlisveris.Web;

using OnlineAlisveris.Web.Services;
using OnlineAlisveris.Web.Services.Abstract;
using OnlineAlisveris.Web.Services.Concreate;
using OnlineAlisveris.Web.Services.Contracts;
using IProductService = OnlineAlisveris.Web.Services.Contracts.IProductService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7203/") });
 builder.Services.AddScoped<IProductService,ProductService>();
 builder.Services.AddScoped<ICartItemService,CartItemService>();
 builder.Services.AddScoped<IProductCategoryService,ProductCategoryService>();

//MudBlazor
builder.Services.AddMudServices(configuration =>
{
 configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
 configuration.SnackbarConfiguration.PreventDuplicates = false;
 configuration.SnackbarConfiguration.NewestOnTop = false;
 configuration.SnackbarConfiguration.VisibleStateDuration =1000;
 configuration.SnackbarConfiguration.HideTransitionDuration = 500;
 configuration.SnackbarConfiguration.ShowTransitionDuration = 50;
 configuration.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

await builder.Build().RunAsync();