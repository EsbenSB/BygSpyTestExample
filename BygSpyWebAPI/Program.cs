using BygSpyServer;
using BygSpyServer.MongoDb;
using BygSpyWebAPI.Services.Interfaces;
using BygSpyServer.Services;
using BygSpyWebAPI.Repositories.Interfaces;
using BygSpyServer.Repositories;
using BygSpyServer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DatabaseSettings>();
builder.Services.AddSingleton<MongoService>(); // Or whichever lifetime suits your application
builder.Services.AddSingleton<BygSpyDbContext>(); // Register BygSpyDbContext
builder.Services.AddSingleton<ISpyingObjectRepository, SpyingObjectRepository>();
builder.Services.AddSingleton<ISpyingObjectService, SpyingObjectService>();
builder.Services.AddSingleton<ISpyService, SpyService>();
builder.Services.AddSingleton<ISpyRepository, SpyRepository>();
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
