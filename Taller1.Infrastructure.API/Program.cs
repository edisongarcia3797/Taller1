using Taller1.Application.Interfaces;
using Taller1.Application.Services;
using Taller1.Infrastructure.Data.Context;
using Taller1.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IOperationContext db = new OperationContext("server=127.0.0.1;port=3306;database=dbTaller1;user=root;password=12345");
db.Database.EnsureCreated();
OperationRepository calculatorRepository = new OperationRepository(db);

IOperationService operationService = new OperationService(calculatorRepository);
ICalculatorService calculatorService = new CalculatorService();

builder.Services.AddSingleton(calculatorService);
builder.Services.AddSingleton(operationService);
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
