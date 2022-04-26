using JuniperWebAPI.Implementations;
using JuniperWebAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register the tax calculator
// if multiple implementations are needed, we'd scope a 'service locator' that
// allows the client to use multiple implementations during runtime
builder.Services.AddScoped<ITaxCalculator, TaxJarTaxCalculator>();
builder.Services.AddScoped<ITaxService, TaxService>();

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
