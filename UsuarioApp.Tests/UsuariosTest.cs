using System.Net;
using System.Text;
using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using UsuariosApp.Domain.Models.Dtos;

namespace UsuarioApp.Tests
{
    public class UsuariosTest
    {

        private HttpResponseMessage CriarUsuario(string email)
        {
            var request = new Faker<CriarUsuarioRequestDto>()
                .RuleFor(dto => dto.Nome, faker => faker.Person.FullName)
                .RuleFor(dto => dto.Email, email)
                .RuleFor(dto => dto.Senha, "@Teste2025")
                .Generate();

            var jsonRequest = new StringContent(JsonConvert.SerializeObject(request),
                    Encoding.UTF8, "application/json");

            var client = new WebApplicationFactory<Program>().CreateClient();

            return client.PostAsync("/api/usuarios/criar",jsonRequest).Result;
        }

        [Fact]
        public void Criar_Usuario_Com_Sucesso()
        {
            var response = CriarUsuario(new Faker().Internet.Email());
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var result = response.Content.ReadAsStringAsync().Result;
            result.Should().Contain("Usuário cadastrado com sucesso");
        }

        [Fact]
        public void Nao_Permitir_Usuarios_Com_Emails_Iguais()
        {
            var email = new Faker().Internet.Email();
            CriarUsuario(email);

            var response = CriarUsuario(email);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var result = response.Content.ReadAsStringAsync().Result;
            result.Should().Contain("O email informado já está cadastrado. Tente outro.");
        }
    }
}
