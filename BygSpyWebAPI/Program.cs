using BygSpyWebAPI.MongoDb;
using BygSpyWebAPI.Services.Interfaces;
using BygSpyWebAPI.Services;
using BygSpyWebAPI.Repositories.Interfaces;
using BygSpyWebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<BygSpyDBContext>();
builder.Services.AddSingleton<ISpyingObjectRepository, SpyingObjectRepository>();
builder.Services.AddSingleton<ISpyingObjectService, SpyingObjectService>();
builder.Services.AddSingleton<ISpyRepository, SpyRepository>();
builder.Services.AddSingleton<ISpyNotificationService, SpyNotificationService>();
builder.Services.AddSingleton<ISpyService, SpyService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUserValidator, EmailValidator>();
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
