// Novo Program.cs adaptado para o objetivo original
using Microsoft.EntityFrameworkCore;
using RPA.Data;
using RPA.Repositories.Interfaces;
using RPA.Repositories;
using RPA.Services;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados usando Entity Framework com SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração dos serviços para injeção de dependência
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<CursoService>();

// Configuração do JSON Serializer
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

// Adicionando Swagger para documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RPA API", Version = "v1" });
});

// Criação do aplicativo
var app = builder.Build();

// Configuração do Swagger
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RPA API v1");
    });
}

// Mapeamento de endpoints para cursos
var cursosApi = app.MapGroup("/api/cursos");
cursosApi.MapGet("/", async (CursoService cursoService) =>
{
    var cursos = await cursoService.GetCursosAsync();
    return Results.Ok(cursos);
});
cursosApi.MapGet("/{id}", async (int id, CursoService cursoService) =>
{
    var curso = await cursoService.GetCursoByIdAsync(id);
    return curso is not null ? Results.Ok(curso) : Results.NotFound();
});
cursosApi.MapPost("/", async (Curso curso, CursoService cursoService) =>
{
    await cursoService.AddCursoAsync(curso);
    return Results.Created($"/api/cursos/{curso.Id}", curso);
});

// Rodar o aplicativo na porta padrão antiga
app.Run();

// Classe Curso (Entidade do Domínio)
public record Curso(int Id, string? Titulo, string? Professor, string? CargaHoraria, string? Descricao);

// Serializer para Curso
[JsonSerializable(typeof(Curso[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}