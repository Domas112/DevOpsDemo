using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AutoMapper;
using TodoClient;
using TodoClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
string baseUrl = builder.Configuration["base_url"] == null ?
    "http://domas911dod.ukwest.azurecontainer.io":
    builder.Configuration["base_url"];

builder.Services.AddScoped<HttpClient>(sp => new HttpClient());

builder.Services.AddHttpClient<ITodosService, TodosService>
    (ts => ts.BaseAddress = new Uri(baseUrl));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


await builder.Build().RunAsync();
