using Microsoft.AspNetCore.Mvc;

namespace Pogchamp.Controllers
{
    [ApiController]
    [Route("/")]
    public class PrincipalController : ControllerBase
    {
        /// <summary>
        /// Endpoint principal da API de manutenção de caminhões.
        /// Retorna uma mensagem informando que a API está ativa e lista as rotas disponíveis.
        /// </summary>
        [HttpGet("")]
        public IActionResult Index()
        {
            var info = new
            {
                mensagem = "API de Manutenção de Caminhões ativa.",
                rotas_disponiveis = new[]
                {
                    "/caminhoes",
                    "/historico",
                    "/ordens"
                }
            };

            return Ok(info);
        }
    }
}
