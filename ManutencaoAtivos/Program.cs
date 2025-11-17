using Microsoft.EntityFrameworkCore;
using ManutencaoAtivos.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// *** NECESSÁRIO PARA LIBERAR O CORS ***
builder.Services.AddCors();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// *** LIBERA ACESSO DO FRONTEND (HTML/JS) ***
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// *** PERMITE CARREGAR index.html, js e css ***
app.UseStaticFiles();

// Mapeia as rotas da API
app.MapControllers();
app.MapFallbackToFile("index.html");

// Inicia o servidor
app.Run();

