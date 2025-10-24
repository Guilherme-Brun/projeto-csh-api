using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace Pogchamp.Controllers {
    [ApiController]
    [Route("/")]
    public class PrincipalController : ControllerBase {
        [HttpGet("")]
        public IActionResult Index(){

            var html = $@"
                <html>
                    <head>
                        <title>Manutenção de caminhões</title>
                    </head>
                    <body>
                        <h1>Escolha uma rota:</h1>
                        <button onclick=""location.href='/caminhoes'"">Lista de caminhões</button>
                        <button onclick=""location.href='/historico'"">Histórico de manutenções</button>
                        <button onclick=""location.href='/ordens'"">Ordens de serviço</button>
                    </body>
                <html>
            ";

            return Content(html, "text/html; charset=utf-8", Encoding.UTF8);
        }
    }
}
