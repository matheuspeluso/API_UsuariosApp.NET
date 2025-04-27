using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using UsuariosApp.Domain.Interfaces.Messages;
using UsuariosApp.Domain.Models.Dtos;
using UsuariosApp.Infra.Messages.Settings;

namespace UsuariosApp.Infra.Messages.Producers
{
    /// <summary>
    /// Classe para implementar a escrita de mensagens na fila do servidor de mensageria (RabbitMQ)
    /// </summary>
    public class UsuarioMessageProducer : IUsuarioMessage
    {
        public void EnviarMensagem(UsuarioMessageDto usuario)
        {
            //Configurar a conexão com o servidor da mensageria
            var connectionFactory = new ConnectionFactory
            {
                HostName = RabbitMQSettings.Host,
                Port = RabbitMQSettings.Port,
                UserName = RabbitMQSettings.User,
                Password = RabbitMQSettings.Pass,
                VirtualHost = RabbitMQSettings.VHost
            };

            //abrindo conexão com o servidor do RabbitMq
            using(var connection = connectionFactory.CreateConnection())
            {
                //connectando / criando a fila
                using(var model = connection.CreateModel())
                {
                    model.QueueDeclare(
                        queue: RabbitMQSettings.Queue,//nome da fila
                        durable: true, //fila não será apagada quando o servidor for reiniciado
                        autoDelete: false, //não permite a remoção de mensagens automaticamente
                        exclusive: false, //permite que a fila seja compartilhada com outro sistemas
                        arguments: null //nenhum argumento adicional
                    );

                    //serializando os dados do usuário para JSON
                    var jsonContent = JsonConvert.SerializeObject( usuario );

                    //gravar os dados na fila
                    model.BasicPublish(
                        exchange: string.Empty,
                        routingKey:RabbitMQSettings.Queue,
                        basicProperties:null,
                        body: Encoding.UTF8.GetBytes(jsonContent)
                    );
                }
            }
        }
    }
}
