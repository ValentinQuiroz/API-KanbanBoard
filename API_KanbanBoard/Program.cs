using API_KanbanBoard.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// WHITELIST
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => {
        builder
            .SetIsOriginAllowed(origin => true) // Permite cualquier origen
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials(); // Importante cuando usas withCredentials: true
    });

});
//

// Add services to the container.
// variable para la connection string
var connectionString = builder.Configuration.GetConnectionString("Conexion");
// registrar servicio para la conexion
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    
    context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000"); ///Dominios con acceso a la API
    context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
    await next();
});

/// ngrok http --host-header=rewrite XXXX --request-header-add "Access-Control-Allow-Origin: *"

app.Run();
