using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManutencaoAtivos.Data;

namespace ManutencaoAtivos.Controllers
{
    [ApiController]
    [Route("historico")]
    public class HistoricoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public HistoricoController(AppDbContext context) => _context = context;

        [HttpGet("")]
        public async Task<IActionResult> GetTodos()
        {
            var lista = await _context.HistoricoManutencao.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var h = await _context.HistoricoManutencao.FindAsync(id);
            if (h == null) return NotFound(new { mensagem = "Histórico não encontrado" });
            return Ok(h);
        }

        [HttpGet("caminhao/{caminhaoId:int}")]
        public async Task<IActionResult> GetPorCaminhao(int caminhaoId)
        {
            var lista = await _context.HistoricoManutencao
                .Where(x => x.CaminhaoId == caminhaoId)
                .ToListAsync();

            return Ok(lista);
        }
    }
}
