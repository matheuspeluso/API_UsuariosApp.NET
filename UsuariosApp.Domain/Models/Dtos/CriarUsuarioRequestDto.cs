using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Models.Dtos
{
    public class CriarUsuarioRequestDto
    {
        [MaxLength(100, ErrorMessage ="Por favor, informe no máximo {1} caracteres")]
        [MinLength(8, ErrorMessage ="Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage ="Por favor, informe o nome do usuário.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage ="Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage ="Por favor, informe o email do usuário..")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$",ErrorMessage = "Por favor, informe a senha com letras minúsculas, maiúsculas, números,símbolos e pelo menos 8 caracteres.")]
        [Required(ErrorMessage ="Por favor, informe a senha do usuário.")]
        public string? Senha { get; set; }
    }
}
