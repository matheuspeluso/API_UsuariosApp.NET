using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace UsuariosApp.Domain.Models.Dtos
{
    public class AutenticarUsuarioRequestDto
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email de acesso.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe a senha com pelo menos {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        public string? Senha { get; set; }
    }
}
