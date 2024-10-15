using Microsoft.EntityFrameworkCore;
using ProjetoBusca.Data;
using ProjetoBusca.Repositories.Interfaces;
using ProjetoBusca.Repositories;
using ProjetoBusca.Services;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using ProjetoBusca.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados usando Entity Framework com SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração dos serviços para injeção de dependência
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<CursoService>();
builder.Services.AddScoped<CursoAutomationService>();

// Adicionando os controladores
builder.Services.AddControllers(); // Isto registra os controladores no contêiner de serviços

// Configuração do JSON Serializer
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

// Adicionando Swagger para documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoBusca API", Version = "v1" });
});

// Criação do aplicativo
var app = builder.Build();

// Configuração do Swagger
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoBusca API v1");
    });
}

app.UseHttpsRedirection();

// Use os controladores definidos no projeto
app.MapControllers(); // Isto garante que os controladores mapeiem suas rotas automaticamente

// Rodar o aplicativo na porta padrão
app.Run();

// Serializer para Curso
[JsonSerializable(typeof(Curso[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}