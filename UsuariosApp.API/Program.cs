using Scalar.AspNetCore;
using UsuariosApp.Domain.Interfaces.Messages;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Services;
using UsuariosApp.Infra.Data.Repositories;
using UsuariosApp.Infra.Messages.Consumers;
using UsuariosApp.Infra.Messages.Producers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//adicionando as configurações do swagger (documentação da API)
builder.Services.AddRouting(map => map.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configuração para injeção de dependência

builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioMessage, UsuarioMessageProducer>();

#endregion

#region Configurando os Workers (serviço de segundo plano)

builder.Services.AddHostedService<UsuarioMessageConsumer>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//executando as configurações do swagger
app.UseSwagger();
app.UseSwaggerUI();

//habilitando a biblioteca do Scalar
app.MapScalarApiReference(options => {
    options
    .WithTitle("UsuariosApp - API para controle de usuários.")
    .WithTheme(ScalarTheme.BluePlanet);
});

app.UseAuthorization();

app.MapControllers();

app.Run();

//definindo a classe Program.cs como pública 
public partial class Program { }