using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces.Messages;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Models.Dtos;
using UsuariosApp.Domain.Models.Entities;

namespace UsuariosApp.Domain.Services
{
    /// <summary>
    /// Implementação dos serviços / regras de negócio para usuário
    /// </summary>
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioMessage _usuarioMessage;

        /// <summary>
        /// Construtor para injeção de dependência (inicialização dos atributos)
        /// </summary>
        public UsuarioService(IUsuarioRepository usuarioRepository, IUsuarioMessage usuarioMessage)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioMessage = usuarioMessage;
        }

        public CriarUsuarioResponseDto CriarUsuario(CriarUsuarioRequestDto request)
        {
            if (_usuarioRepository.VerificarSeEmailJaExiste(request.Email))
            {
                throw new ApplicationException("O email informado já está cadastrado. Tente outro.");
            }

            //capturando os dados do usuário
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                Senha = CryptoHelper.EncryptSHA256(request.Senha)
            };

            //gravando usuario no banco de dados
            _usuarioRepository.Adicionar(usuario);

            //enviar os dados para a mensageria
            var usuarioMessage = new UsuarioMessageDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCadastro = DateTime.Now,
            };

            //salvar os dados do usuário na fila de mensageria
            _usuarioMessage.EnviarMensagem(usuarioMessage);

            //dados de resposta
            var response = new CriarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCadastro = DateTime.Now
            };

            return response; //retornando os dados da resposta
        }


        public AutenticarUsuarioResponseDto AutenticarUsuario(AutenticarUsuarioRequestDto request)
        {
            //consultando os dados do usuário no banco de dados através do email e da senha
            var usuario = _usuarioRepository.Obter(request.Email, CryptoHelper.EncryptSHA256(request.Senha));

            //verficando se o usuário não foi encontrado
            if(usuario == null)
                throw new ApplicationException("Acesso negado. Usuário não encontrado");

            //Retornar os dados do usuário autenticado
            var response = new AutenticarUsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAcesso = DateTime.Now,
                Token = JwtHelper.CreateToken(usuario) //gerando o TOKEN JWT
            };

            return response;
        }
    }
}
