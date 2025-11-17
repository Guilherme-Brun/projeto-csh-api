using Microsoft.AspNetCore.Mvc;
using ManutencaoAtivos.Data;
using Microsoft.EntityFrameworkCore;
using ManutencaoAtivos.Models;
using System.Threading.Tasks;

namespace ManutencaoAtivos.Controllers
{
    [ApiController]
    [Route("caminhoes")]
    public class CaminhoesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CaminhoesController(AppDbContext context) => _context = context;

        // GET /caminhoes
        [HttpGet("")]
        public async Task<IActionResult> GetTodos()
        {
            var lista = await _context.Caminhao.ToListAsync();
            return Ok(lista);
        }

        // GET /caminhoes/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var c = await _context.Caminhao.FindAsync(id);
            if (c == null) return NotFound(new { mensagem = "Caminhão não encontrado" });
            return Ok(c);
        }

        // POST /caminhoes
        [HttpPost("")]
        public async Task<IActionResult> Criar([FromBody] Caminhao novo)
        {
            _context.Caminhao.Add(novo);
            await _context.SaveChangesAsync();
            return Created($"/caminhoes/{novo.Id}", novo);
        }

        // PUT /caminhoes/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Caminhao dados)
        {
            var existente = await _context.Caminhao.FindAsync(id);
            if (existente == null)
                return NotFound(new { mensagem = "Caminhão não encontrado" });

            existente.Placa = dados.Placa;
            existente.Modelo = dados.Modelo;
            existente.Ano = dados.Ano;
            existente.Km = dados.Km;
            existente.Status = dados.Status;
            existente.DataUltimaRevisao = dados.DataUltimaRevisao;
            existente.ProximaRevisao = dados.ProximaRevisao;

            await _context.SaveChangesAsync();
            return Ok(new { mensagem = "Atualizado com sucesso!" });
        }

        // DELETE /caminhoes/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var caminhao = await _context.Caminhao.FindAsync(id);
            if (caminhao == null)
                return NotFound(new { mensagem = "Caminhão não encontrado" });

            _context.Caminhao.Remove(caminhao);
            await _context.SaveChangesAsync();
            return Ok(new { mensagem = "Removido com sucesso!" });
        }
    }
}
