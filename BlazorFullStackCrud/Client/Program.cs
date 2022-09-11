global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
global using BlazorFullStackCrud.Shared;
using BlazorFullStackCrud.Client;
using BlazorFullStackCrud.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddScoped<ISinhVienService, SinhVienService>();
builder.Services.AddScoped<IMonHocService, MonHocService>();
builder.Services.AddScoped<IDiemService, DiemSerivce>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

///

await builder.Build().RunAsync();
