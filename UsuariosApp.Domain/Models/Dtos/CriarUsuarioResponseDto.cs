namespace UsuariosApp.Domain.Models.Dtos
{
    /// <summary>
    /// DTO para saída de dados da ação de criar usuário
    /// </summary>
    public class CriarUsuarioResponseDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataHoraCadastro { get; set; }

    }
}
