using Microsoft.AspNetCore.Mvc;
using ManutencaoAtivos.Data;
using Microsoft.EntityFrameworkCore;

namespace ManutencaoAtivos.Controllers
{
    [ApiController]
    [Route("caminhoes")]
    public class CaminhoesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CaminhoesController(AppDbContext context) => _context = context;

        [HttpGet("")]
        public async Task<IActionResult> GetTodos()
        {
            var lista = await _context.Caminhao.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var c = await _context.Caminhao.FindAsync(id);
            if (c == null) return NotFound(new { mensagem = "Caminhão não encontrado" });
            return Ok(c);
        }
    }
}
