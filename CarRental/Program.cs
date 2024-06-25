using CarRental.Data;
using CarRental.Domain;
using CarRental.Domain.Interfaces;
using CarRental.Services;
using CarRental.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Datas>();
builder.Services.AddScoped<ICalculatePrice, CalculatePrice>();
builder.Services.AddScoped<IRent, Rent>();
builder.Services.AddScoped<IRentCars, RentCars>();

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
