using System;
using System.Collections.Generic;
using System.Linq;
namespace UsuariosApp.Domain.Models.Dtos
{
    public class AutenticarUsuarioResponseDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataHoraAcesso { get; set; }
        public string? Token { get; set; }
    }
}
