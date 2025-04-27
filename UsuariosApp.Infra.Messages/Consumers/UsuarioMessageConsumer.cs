using Microsoft.Extensions.Hosting;

namespace UsuariosApp.Infra.Messages.Consumers
{
    /// <summary>
    /// Classe para ler e processar as mensgens contidas na fila
    /// </summary>
    public class UsuarioMessageConsumer : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
