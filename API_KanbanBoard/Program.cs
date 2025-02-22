using API_KanbanBoard.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// WHITELIST
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy => {
        policy
            .WithOrigins("http://localhost:3000")   //Origen permitido
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials(); // Importante cuando se usa withCredentials: true
    });

});

// variable para la connection string
var connectionString = builder.Configuration.GetConnectionString("Conexion");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
