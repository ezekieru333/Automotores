using Automotores.AutoMappers;
using Automotores.DTOs;
using Automotores.Models;
using Automotores.Repository;
using Automotores.Services;
using Automotores.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyedScoped<ICommonService<VehiculoDto, VehiculoInsertDto, VehiculoUpdateDto>, VehiculoService>("vehiculoService");
builder.Services.AddKeyedScoped<ICommonService<IndividuoDto, IndividuoInsertDto, IndividuoUpdateDto>, IndividuoService>("individuoService");

//Authorization Identity
builder.Services.AddAuthorization();

//Repositories
builder.Services.AddScoped<IRepository<Vehiculo>, VehiculoRepository>();
builder.Services.AddScoped<IRepository<Individuo>, IndividuoRepository>();

//Conexión Entity Framework
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Automotores"));
});

//Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Validators
builder.Services.AddScoped<IValidator<VehiculoInsertDto>, VehiculoInsertValidator>();
builder.Services.AddScoped<IValidator<VehiculoUpdateDto>, VehiculoUpdateValidator>();
builder.Services.AddScoped<IValidator<IndividuoInsertDto>, IndividuoInsertValidator>();
builder.Services.AddScoped<IValidator<IndividuoUpdateDto>, IndividuoUpdateValidator>();

//Agragado para usar Identity
//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<StoreContext>();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<StoreContext>();

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

//Agragado para usar Identity
//app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<IdentityUser>();

app.Run();
