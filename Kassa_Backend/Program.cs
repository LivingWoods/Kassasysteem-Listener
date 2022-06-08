using Microsoft.EntityFrameworkCore;
using Kassa_Backend.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PrinterStaffelContext>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddDbContext<PrinterContext>(opt => opt.UseNpgsql(connectionString));

builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new() { Title = "Kassa API", Version = "v1" }));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kassa API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
