using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Models.Entities;
using UsuariosApp.Infra.Data.Context;

namespace UsuariosApp.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Adicionar(Usuario usuario)
        {
           using(var dataContext = new DataContext())
            {
                dataContext.Add(usuario);
                dataContext.SaveChanges();
            }
        }

        public bool VerificarSeEmailJaExiste(string email)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Usuario>()
                    .Where(u => u.Email.Equals(email))
                    .Any();
            }
        }
    }
}
