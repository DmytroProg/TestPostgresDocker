using Microsoft.EntityFrameworkCore;
using TestPostgresDocker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options => {
    var host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
    var database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "Company";
    var user = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "user";
    var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "password12345";
    options.UseNpgsql($"Host={host}; Port=5432; Database={database}; Username={user}; Password={password}");
});
builder.Services.AddControllers();
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

//app.UseAuthorization();

app.MapControllers();

app.Run();
