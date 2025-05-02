using UsuariosApp.Domain.Models.Entities;

namespace UsuariosApp.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        //método para gravar um novo usuário no banco
        void Adicionar(Usuario usuario);
        
        //método para verificar se um email já está cadastrado
        bool VerificarSeEmailJaExiste(string email);

        //Método para consultar 1 usuário atreves do email e da senha
        Usuario? Obter(string email, string senha);

    }
}
