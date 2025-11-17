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
            var lista = await _context.OrdemServico
                .Where(x => x.CaminhaoId == caminhaoId)
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("expandido")]
        public async Task<IActionResult> GetComPlaca()
        {
            var lista = await _context.OrdemServico
                .Join(_context.Caminhao,
                    o => o.CaminhaoId,
                    c => c.Id,
                    (o, c) => new {
                        o.Id,
                        o.TipoManutencao,
                        o.Descricao,
                        o.Custo,
                        o.Status,
                        o.DataAbertura,
                        o.DataConclusao,
                        CaminhaoPlaca = c.Placa
                    })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpPost("")]
        public async Task<IActionResult> Criar([FromBody] OrdemServico ordem)
        {
            _context.OrdemServico.Add(ordem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPorId), new { id = ordem.Id }, ordem);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] OrdemServico ordemAtualizada)
        {
            if (id != ordemAtualizada.Id)
                return BadRequest(new { mensagem = "ID da URL não confere com o corpo da requisição." });

            var ordemExistente = await _context.OrdemServico.FindAsync(id);
            if (ordemExistente == null)
                return NotFound(new { mensagem = $"Ordem com ID {id} não encontrada." });

            ordemExistente.CaminhaoId = ordemAtualizada.CaminhaoId;
            ordemExistente.Descricao = ordemAtualizada.Descricao;
            ordemExistente.TipoManutencao = ordemAtualizada.TipoManutencao;
            ordemExistente.Status = ordemAtualizada.Status;
            ordemExistente.Custo = ordemAtualizada.Custo;
            ordemExistente.DataAbertura = ordemAtualizada.DataAbertura;
            ordemExistente.DataConclusao = ordemAtualizada.DataConclusao;

            await _context.SaveChangesAsync();

            return Ok(ordemExistente);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ordemServico = await _context.OrdemServico.FindAsync(id);

            if (ordemServico == null)
                return NotFound(new { mensagem = $"Ordem com ID {id} não encontrada." });

            _context.OrdemServico.Remove(ordemServico);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = $"Ordem com ID {id} foi removida com sucesso." });
        }
    }
}


