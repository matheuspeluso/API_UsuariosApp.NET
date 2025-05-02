using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Infra.Messages.Settings;

namespace UsuariosApp.Infra.Messages.Helpers
{
    /// <summary>
    /// Classe auxiliar para fazer o envio dos emails
    /// </summary>
    public class MailHelper
    {
        /// <summary>
        /// Método para fazer o evio de um email
        /// </summary>
        /// <param name="to">Email do destinatário da mensagem</param>
        /// <param name="subject">Assunto da mensagem de email</param>
        /// <param name="body">Corpo / conteúdo da mensagem de email</param>
        public static void SendMessage(string to, string subject, string body)
        {
            //configuração do protocolo SMTP para fazer o envio dos emails
            var smtpCliente = new SmtpClient(SmptSettings.Host, SmptSettings.Port)
            {
                EnableSsl = false,
            };

            //criar a mensagem de email e fazer o envio
            var mailMessage = new MailMessage(SmptSettings.EmailFrom, to, subject, body);

            mailMessage.IsBodyHtml = true;//formatando o conteudo do email em HTML

            //enviando o email
            smtpCliente.Send(mailMessage);

        }
    }
}
