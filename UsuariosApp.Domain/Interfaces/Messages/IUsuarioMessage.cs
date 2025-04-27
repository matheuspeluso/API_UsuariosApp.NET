using UsuariosApp.Domain.Models.Dtos;

namespace UsuariosApp.Domain.Interfaces.Messages
{
    public interface IUsuarioMessage
    {
        void EnviarMensagem(UsuarioMessageDto usuario);
    }
}
