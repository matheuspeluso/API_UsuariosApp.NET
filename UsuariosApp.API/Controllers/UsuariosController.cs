using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Models.Dtos;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        /// <summary>
        /// Serviço para criação de usuários na API
        /// </summary>
        [HttpPost("criar")]
        public IActionResult Criar([FromBody] CriarUsuarioRequestDto request)
        {
            try
            {
                var response = _usuarioService.CriarUsuario(request);
                return StatusCode(201, new //created sucesso
                {
                    Message = "Usuário cadastrado com sucesso",
                    Data = response

                });
            }catch(ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
                //BAD REQUEST
            }catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
                //INTERNAL SERVER ERROR (erro do servidor)
            }
        }

        /// <summary>
        /// Serviço para autenticação de usuário na API
        /// </summary>
        [HttpPost("autenticar")]
        public IActionResult Autenticar()
        {
            return Ok();
        }



    }
}
