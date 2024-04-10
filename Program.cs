using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PruebaEdenred.Data;
using PruebaEdenred.Model.Bl;
using PruebaEdenred.Model.Dao;
using PruebaEdenred.Model.Dto;
using PruebaEdenred.Model.Interface;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var databasePath = Path.Combine(builder.Environment.ContentRootPath, "Data", "db.db");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection").Replace("{PATH}", databasePath);

builder.Services.AddDbContext<DbContextSqlite>(options => options.UseSqlite(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Prueba Edenred",
        Version = "1.0",
        Description = "Esta API permite la gestión de los registros de Clientes, permitiendo la Creación, Búsqueda y Actualización de Registros."
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<IClientBl, ClientBl>();
builder.Services.AddScoped<IClientDao, ClientDao>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
