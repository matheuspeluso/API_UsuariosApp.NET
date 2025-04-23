using UsuariosApp.Domain.Models.Dtos;

namespace UsuariosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para abstração dos métodos da camada de serviço do domínio de usuário
    /// </summary>
    public interface IUsuarioService
    {
        CriarUsuarioResponseDto CriarUsuario(CriarUsuarioRequestDto request);

    }
}
