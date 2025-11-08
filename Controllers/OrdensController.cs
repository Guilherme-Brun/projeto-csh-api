using Microsoft.AspNetCore.Mvc;
using ManutencaoAtivos.Data;
using Microsoft.EntityFrameworkCore;
using ManutencaoAtivos.Models;

namespace ManutencaoAtivos.Controllers
{
    [ApiController]
    [Route("ordens")]
    public class OrdensController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrdensController(AppDbContext context) => _context = context;

        [HttpGet("")]
        public async Task<IActionResult> GetTodas()
        {
            var lista = await _context.OrdemServico.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var o = await _context.OrdemServico.FindAsync(id);
            if (o == null) return NotFound(new { mensagem = "Ordem não encontrada" });
            return Ok(o);
        }

        [HttpGet("caminhao/{caminhaoId:int}")]
        public async Task<IActionResult> GetPorCaminhao(int caminhaoId)
        {
            var lista = await _context.OrdemServico.Where(x => x.CaminhaoId == caminhaoId).ToListAsync();
            return Ok(lista);
        }

        [HttpPost("")]
        public async Task<IActionResult> Criar([FromBody] OrdemServico ordem)
        {
            _context.OrdemServico.Add(ordem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPorId), new { id = ordem.Id }, ordem);
        }
    }
}


