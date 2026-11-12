// START HERE when reading any ASP.NET Core app. Program.cs has two halves:
//   1. register services in the DI container   (builder.Services...)
//   2. build the app and configure the HTTP pipeline  (app.Use... / app.Map...)
using Microsoft.Extensions.Options;
using RealWorldSample.Core;
using RealWorldSample.Core.Interfaces;
using RealWorldSample.Core.Options;
using RealWorldSample.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// CreateBuilder already loaded configuration (appsettings.json, appsettings.{Environment}.json,
// environment variables, command-line args) and set up console logging.

// ---- 1. Services (dependency injection) ----
builder.Services.AddControllers();                         // MVC controllers in Controllers/
builder.Services.Configure<TodoOptions>(                   // bind "Todo" section -> IOptions<TodoOptions>
    builder.Configuration.GetSection(TodoOptions.SectionName));
builder.Services.AddCore();                                // our extension methods, one per layer
builder.Services.AddInfrastructure();

var app = builder.Build();

// ---- 2. HTTP pipeline (middleware runs in this order for every request) ----
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();                       // detailed error pages in dev only
}

app.MapControllers();                                      // routes from [Route]/[HttpGet] attributes
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));   // a "minimal API" endpoint

// Optional startup work: seed demo data when configured (true in appsettings.Development.json)
if (app.Services.GetRequiredService<IOptions<TodoOptions>>().Value.SeedSampleData)
{
    // Scoped services (like ITodoService) need a scope outside of an HTTP request.
    using var scope = app.Services.CreateScope();
    var todos = scope.ServiceProvider.GetRequiredService<ITodoService>();
    await todos.CreateAsync("Read Program.cs");
    await todos.CreateAsync("Follow a request from controller to repository");
}

app.Run();
