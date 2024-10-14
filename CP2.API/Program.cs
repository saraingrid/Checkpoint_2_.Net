using CP2.API.Application.Interfaces;
using CP2.API.Application.Services;
using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Infrastructure.Data.Repositories;
using CP2.API.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(x => {
    x.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

// Adicionando a injecão de dependencia das interfaces e suas classes concretas
builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddTransient<IVendedorRepository, VendedorRepository>();
builder.Services.AddTransient<IFornecedorApplicationService, FornecedorApplicationService>();
builder.Services.AddTransient<IVendedorApplicationService, VendedorApplicationService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

//Configurando e habilitando a documentação no swagger 
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sistema de Gerenciamento de Fornecedores e Vendedores",
        Version = "v1",
        Description = "API para cadastro de Fornecedores e Vendedores"
    });
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Define a URL padrão para o Swagger UI
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");

        // Define a URL inicial (raiz) do Swagger UI - na minha máquina ele não estava rodando no local correto
        c.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
