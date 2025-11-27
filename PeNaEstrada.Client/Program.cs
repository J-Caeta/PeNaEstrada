using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PeNaEstrada.Client;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PeNaEstrada.Client.Auth;
using PeNaEstrada.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7052/")
});

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<ExperienciaService>();

await builder.Build().RunAsync();