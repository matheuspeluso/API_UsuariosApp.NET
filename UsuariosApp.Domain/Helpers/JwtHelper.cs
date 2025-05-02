using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApp.Domain.Models.Entities;
namespace UsuariosApp.Domain.Helpers
{
    public class JwtHelper
    {
        /// <summary>
        /// Chave utilizada para assinar / criptografar os tokens gerados
        /// </summary>
        public static string SecretKey

        => "39E48946-C701-4021-9841-38085F265214";

        /// <summary>
        /// Método para gerar uym TOKEN JWT para um usuário autenticado
        /// </summary>
        public static string CreateToken(Usuario usuario)
        {
            //Registrando a chave utilizada para assinar os tokens
            var key = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(SecretKey));
            //Criprografando a chave e gerando a assinatura
            var credentials = new SigningCredentials
            (key, SecurityAlgorithms.HmacSha256);
            //informações do usuário autenticado
            var claims = new[]
            {
                //identificação do usuário
                new Claim(ClaimTypes.Name, usuario.Id.ToString())
            };
            //gerando o token
            var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: credentials
            );
            //retornando o token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}