using ASPNET.Domain.Commons.Interface;
using ASPNET.User.API.MinimalAPI.Extensions;
using ASPNET.User.BusinessLogic.Repository;
using ASPNET.User.DataAccess.Context;
using ASPNET.User.DataAccess.Model;

var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("DB_HOST_USER");
var database = Environment.GetEnvironmentVariable("DB_DATABASE_USER");
var username = Environment.GetEnvironmentVariable("DB_USER_USER");
var password = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD_USER");
var connectionString = $"Data Source={host};Initial Catalog={database};User ID={username};Password={password};Trusted_connection=false;TrustServerCertificate=True;";

//builder.Services.AddHttpClient("graphiteapi.user.api", c => c.BaseAddress = new System.Uri("http://graphiteapi.user.api:8080"));
//builder.Services.AddHttpClient("graphiteapi.product.api", c => c.BaseAddress = new System.Uri("http://graphiteapi.pencil.api:8080"));

builder.Services.AddSqlServer<UserContext>(connectionString);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGenericRepository<UserModel, Guid>, UserRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

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

