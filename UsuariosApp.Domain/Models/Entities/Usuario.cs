namespace UsuariosApp.Domain.Models.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        #region Relacionamentos
        public List<UsuarioPermissao>? Permissoes { get; set; }
        #endregion
    }
}
