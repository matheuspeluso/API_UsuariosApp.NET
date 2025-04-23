using Microsoft.EntityFrameworkCore;
using UsuariosApp.Infra.Data.Mappings;

namespace UsuariosApp.Infra.Data.Context
{
    /// <summary>
    /// Classe de contexto para configurar a conexão com o banco de dados através do Entity Framework
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Método para configurar a string de conexão do banco de dados
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1434;Initial Catalog=master;User ID=sa;Password=Coti@2025;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PermissaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioPermissaoMap());
        }
    }
}
