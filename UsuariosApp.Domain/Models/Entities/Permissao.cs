using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Models.Entities
{
    public class Permissao
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }

        #region Relacionamentos
        public List<UsuarioPermissao>? Usuarios { get; set; }
        #endregion
    }
}
