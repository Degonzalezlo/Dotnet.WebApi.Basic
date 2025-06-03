using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Configurations;
using MyVaccine.WebApi.Configurations.Validators;
using MyVaccine.WebApi.Literals;
using MyVaccine.WebApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();  // (fv => fv.RegisterValidatorsFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssemblyContaining<DependentsDtoValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.SetDatabaseConfiguration();
builder.Services.SetMyVaccineAuthConfigurations();
builder.Services.SetDependencyInjection();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

