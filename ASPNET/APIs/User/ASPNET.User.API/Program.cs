using ASPNET.User.API.MinimalAPI.Endpoints.Handler.User;
using ASPNET.User.API.MinimalAPI.Extensions;
using ASPNET.User.BusinessLogic.Repository;
using ASPNET.User.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("DB_HOST_USER");
var database = Environment.GetEnvironmentVariable("DB_DATABASE_USER");
var username = Environment.GetEnvironmentVariable("DB_USER_USER");
var password = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD_USER");

var connectionString = $"Data Source={host};Initial Catalog={database};User ID={username};Password={password};Trusted_connection=false;TrustServerCertificate=True;";

builder.Services.AddSqlServer<UserContext>(connectionString);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UserRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();

