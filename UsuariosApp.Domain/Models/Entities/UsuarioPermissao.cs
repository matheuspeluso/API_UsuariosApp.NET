using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Models.Entities
{
    public class UsuarioPermissao
    {
        public Guid UsuarioId { get; set; }
        public Guid PermissaoId { get; set; }

        #region Relacionamento
        public Usuario? Usuario { get; set; }
        public Permissao? Permissao { get; set; }
        #endregion
    }
}
