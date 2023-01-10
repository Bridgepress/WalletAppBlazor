using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;
using WalletApp.Client;
using WalletApp.Client.Handlers;
using WalletApp.Client.HttpRepositories;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddTransient<CustomAuthorizationHandler>();
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});
builder.Services.AddHttpClient("FlowMoneyAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7069/api/");
});
builder.Services.AddHttpClient("IncomeAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7069/api/");
});
builder.Services.AddHttpClient("AppUserAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7069/api/");
});
builder.Services.AddHttpClient("TypeOfExpenseAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7069/api/");
});
builder.Services.AddHttpClient("TypeIncomeAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7069/api/");
});
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<IFlowMoneyReposytory, FlowMoneyReposytory>();
builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<ITypeIncomeRepository, TypeIncomeRepository>();
builder.Services.AddScoped<ITypeOfExpenseRepository, TypeOfExpenseRepository>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityAuthenticationStateProvider>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();

