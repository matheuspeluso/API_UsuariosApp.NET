namespace UsuariosApp.Infra.Messages.Settings
{
    /// <summary>
    /// Classe para mapear os paramtros de conexão com o servidor de mensageria
    /// </summary>
    public class RabbitMQSettings
    {
        public static string Host => "localhost"; //servidor do RabbitMQ
        public static int Port => 5672; //porta para conexão com o servidro
        public static string User => "guest"; //usuário de acesso
        public static string Pass => "guest";//senha de acesso
        public static string VHost => "/";//endereço virtual do servidor
        public static string Queue => "Usuarios";//nome da fila
    }
}
