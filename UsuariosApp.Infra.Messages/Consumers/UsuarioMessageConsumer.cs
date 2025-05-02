using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using UsuariosApp.Domain.Models.Dtos;
using UsuariosApp.Infra.Messages.Helpers;
using UsuariosApp.Infra.Messages.Settings;

namespace UsuariosApp.Infra.Messages.Consumers
{
    /// <summary>
    /// Classe para ler e processar as mensagens contidas na fila
    /// </summary>
    public class UsuarioMessageConsumer : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            #region Conectando no servidor de fila do RabbitMQ
            var connectionFactory = new ConnectionFactory
            {
                HostName = RabbitMQSettings.Host,
                Port = RabbitMQSettings.Port,
                UserName = RabbitMQSettings.User,
                Password = RabbitMQSettings.Pass,
                VirtualHost = RabbitMQSettings.VHost
            };

            var connection = connectionFactory.CreateConnection();
            #endregion

            #region Conectando na fila do servidor do RabbitMQ para leitura dos dados
            var model = connection.CreateModel();

            model.QueueDeclare(
                queue: RabbitMQSettings.Queue,
                durable: true,
                autoDelete: false,
                exclusive: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(model);
            #endregion

            #region Fazer a leitura das mensagens contidas na fila
            consumer.Received += (sender, args) =>
            {
                var payload = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(payload);

                var usuario = JsonConvert.DeserializeObject<UsuarioMessageDto>(message);

                // Enviando o email de boas-vindas para o usuário
                EnviarEmailDeBoasVindas(usuario);

                // Retirando o usuário da fila
                model.BasicAck(args.DeliveryTag, false);
            };
            #endregion

            #region Executando o consumer
            model.BasicConsume(
                queue: RabbitMQSettings.Queue,
                autoAck: false,
                consumer: consumer
            );
            #endregion

            // Aguarda a finalização do serviço
            await Task.CompletedTask;
        }

        /// <summary>
        /// Método para escrever e fazer o envio dos emails.
        /// </summary>
        private void EnviarEmailDeBoasVindas(UsuarioMessageDto usuario)
        {
            var assunto = "Bem-vindo ao Sistema da COTI Informática!";
            var corpo = @$"
            <div style='font-family: Arial, sans-serif; font-size: 16px; color: #333; line-height: 1.6;'>
                <h2 style='color: #2c3e50;'>Olá, {usuario.Nome}!</h2>
                <p>Temos o prazer de informar que seu cadastro foi realizado com sucesso em nosso sistema.</p>
                <p>Agora você já pode acessar a plataforma e aproveitar todos os recursos disponíveis para você.</p>
                <div style='margin: 20px 0; padding: 15px; background-color: #f1f1f1; border-left: 5px solid #4CAF50;'>
                    <p style='margin: 0;'><strong>Para acessar sua conta, clique no link abaixo:</strong></p>
                    <p><a href='http://www.cotiinformatica.com.br' target='_blank' style='color: #007BFF; text-decoration: none;'>www.cotiinformatica.com.br</a></p>
                </div>
                <p>Em caso de dúvidas ou dificuldades, nossa equipe de suporte está à disposição para ajudar você no que for necessário.</p>
                <p>Seja muito bem-vindo e sucesso na sua jornada conosco!</p>
                <br />
                <p>Atenciosamente,</p>
                <p><strong>Equipe COTI Informática</strong></p>
                <hr style='margin-top: 40px;' />
                <p style='font-size: 12px; color: #777;'>Este é um e-mail automático. Por favor, não responda.</p>
            </div>";

            // Enviando o email
            MailHelper.SendMessage(usuario.Email, assunto, corpo);
        }
    }
}
