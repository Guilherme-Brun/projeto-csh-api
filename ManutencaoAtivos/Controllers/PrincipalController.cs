using Microsoft.AspNetCore.Mvc;

namespace Pogchamp.Controllers
{
    [ApiController]
    [Route("api")]
    public class PrincipalController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok(new
            {
                mensagem = "API de Manutenção de Caminhões ativa.",
                rotas_disponiveis = new[]
                {
                    "caminhoes",
                    "ordens",
                    "historico"
                }
            });
        }
    }
}
