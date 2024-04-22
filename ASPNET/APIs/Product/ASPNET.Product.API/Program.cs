using ASPNET.Product.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("DB_HOST_PRODUCT");
var database = Environment.GetEnvironmentVariable("DB_DATABASE_PRODUCT");
var username = Environment.GetEnvironmentVariable("DB_USER_PRODUCT");
var password = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD_PRODUCT");
var connectionString = $"Data Source={host};Initial Catalog={database};User ID={username};Password={password};Trusted_connection=false;TrustServerCertificate=True;";

//builder.Services.AddHttpClient("graphiteapi.user.api", c => c.BaseAddress = new System.Uri("http://graphiteapi.user.api:8080"));
//builder.Services.AddHttpClient("graphiteapi.product.api", c => c.BaseAddress = new System.Uri("http://graphiteapi.pencil.api:8080"));

builder.Services.AddSqlServer<ProductContext>(connectionString);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
