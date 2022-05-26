

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnlineAlisveris.Web;

using OnlineAlisveris.Web.Services;
using ICartService = OnlineAlisveris.Web.Services.Contracts.ICartService;
using IProductService = OnlineAlisveris.Web.Services.Contracts.IProductService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7203/") });
 builder.Services.AddScoped<IProductService,ProductService>();
 builder.Services.AddScoped<ICartService,CartService>();
await builder.Build().RunAsync();