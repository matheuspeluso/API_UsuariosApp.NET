using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Infra.Messages.Settings
{
    /// <summary>
    /// Classe para mapear os parametros de conexão com o servidor de envio de emails (SMPT)
    /// </summary>
    public class SmptSettings
    {
        public static string Host => "localhost";
        public static int Port => 1025;
        public static string EmailFrom => "nao-responda@cotiinformatica.com.br";
    }
}
