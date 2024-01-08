using Automotores.AutoMappers;
using Automotores.DTOs;
using Automotores.Services;
using Automotores.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyedScoped<ICommonService<VehiculoDto, VehiculoInsertDto, VehiculoUpdateDto>, VehiculoService>("vehiculoService");
builder.Services.AddKeyedScoped<ICommonService<IndividuoDto, IndividuoInsertDto, IndividuoUpdateDto>, IndividuoService>("individuoService");
//Conexión Entity Framework
builder.Services.AddDbContext<DbContext>(options =>
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
