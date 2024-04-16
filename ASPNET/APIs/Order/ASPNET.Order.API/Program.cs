using ASPNET.Order.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("DB_HOST_ORDER");
var database = Environment.GetEnvironmentVariable("DB_DATABASE_ORDER");
var username = Environment.GetEnvironmentVariable("DB_USER_ORDER");
var password = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD_ORDER");
var connectionString = $"Data Source={host};Initial Catalog={database};User ID={username};Password={password};Trusted_connection=false;TrustServerCertificate=True;";

//builder.Services.AddHttpClient("graphiteapi.user.api", c => c.BaseAddress = new System.Uri("http://graphiteapi.user.api:8080"));
//builder.Services.AddHttpClient("graphiteapi.product.api", c => c.BaseAddress = new System.Uri("http://graphiteapi.pencil.api:8080"));

builder.Services.AddSqlServer<OrderContext>(connectionString);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
