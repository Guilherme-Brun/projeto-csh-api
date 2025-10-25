using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using ManutencaoAtivos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManutencaoAtivos.Controllers
{
    [ApiController]
    [Route("ordens")]
    public class OrdensController : ControllerBase
    {
        private static List<OrdemServico> ordens = new();

        [HttpGet("")]

        public IActionResult Listar()
        {
            var htmlBuilder = new StringBuilder();

            htmlBuilder.Append(@"
                <html>
                    <head>
                        <title>Ordem de Serviços</title>
                        <script>
                            function redirecionarPorId()
                            {
                                const id = document.getElementById('id').value;
                                window.location.href = '/ordens/' + id;
                            }
                            function redirecionarPorCaminhao()
                            {
                                const caminhaoId = document.getElementById('caminhaoId').value;
                                window.location.href = '/ordens/caminhao/' + caminhaoId;
                            }
                        </script>
                    </head>
                    <body>
                        <h1>Lista de Ordem de Serviços</h1>
                        <form onsubmit=""event.preventDefault(); redirecionarPorId();"">
                            <label>Buscar por ID da Ordem: </label><br />
                            <input type='text' id='id' required></input>
                            <button type='submit'>Buscar</button>
                        </form>
                        <br />

                        <form onsubmit=""event.preventDefault(); redirecionarPorCaminhao();"">
                            <label>Buscar por ID do Caminhão:</label><br />
                            <input type='text' id='caminhaoId' required />
                            <button type='submit'>Buscar</button>
                        </form>
                        <br />

                        <button onclick=""location.href='/ordens/comissionar'"">Novo Serviço</button>
            ");
            
            if (ordens.Count == 0){
                htmlBuilder.Append(@"
                        <li>Não há nenhum serviço cadastrado.</li><br /> 
                ");
            }
            else{
                foreach(var o in ordens){
                    htmlBuilder.Append(@$"
                        <li>
                            <strong>Id da Ordem: </strong>{o.Id}    |
                            <strong>Id do Caminhão: </strong>{o.CaminhaoId}     |
                            <strong>Tipo de Manutenção: </strong>{o.TipoManutencao}
                        </li>
                    ");
                }
            }
            htmlBuilder.Append(@"
                <button onclick=""location.href='/'"">Ínicio</button>
                    </body>
                </html>
            ");

            return Content(htmlBuilder.ToString(), "text/html; charset=utf-8", Encoding.UTF8);
        }

        [HttpGet("comissionar")]

        public IActionResult Comissionar()
        {
            var html = @"
                <html>
                    <head>
                        <title>Comissionar Serviço</title>
                    </head>
                    <body>
                        <h1>Comissionar Serviço</h1>
                        <form method='post'>
                            <label>Id do Caminhão: </label><br />
                            <input type='text' name='caminhaoid'>
                            <label>Tipo de Manutenção: </label><br />
                            <select name='tipomanutencao'>
                                <option value='preventiva'>Preventiva</option>
                                <option value='corretiva'>Corretiva</option>
                                <option value='preditiva'>Preditiva</option>
                            </select><br />
                            <label>Descrição: </label><br />
                            <textarea rows='5' cols='40' placeholder='Descreva o serviço desejado...' name='descricao'></textarea>
                            <button type='submit'>Enviar</button>
                        </form>
                    </body>
                </html>
            ";
            return Content(html, "text/html; charset=utf-8", Encoding.UTF8);
        }

        [HttpPost("comissionar")]

        public IActionResult Armazenar(){

            var id = Guid.NewGuid();
            var caminhaoid = Request.Form["caminhaoid"];
            var descricao = Request.Form["descricao"];
            var tipomanutencao = Request.Form["tipomanutencao"];
            var custo = 5000;
            
            ordens.Add(new OrdemServico(
                id!,
                caminhaoid!,
                descricao!,
                tipomanutencao!,
                custo!
            ));

            var html = @$"
                <html>
                    <head>
                        <title>Serviço comissionado!</title>
                    </head>
                    <body>
                        <h1>Serviço comissionado com sucesso!</h1>
                        <strong>Id da Ordem: </strong>{id}
                        <p>Quantidade total de ordens: {ordens.Count}</p>
                        <button onclick=""location.href='/'"">Ínicio</button>
                        <button onclick=""location.href='/ordens'"">Ordens</button>
                    </body>
                </html>
            ";

            return Content(html, "text/html; charset=utf-8", Encoding.UTF8);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarOrdem(Guid id)
        {
            var ordem = ordens.FirstOrDefault(o => o.Id == id);

            if (ordem == null)
            {
                return NotFound("<h1>Ordem não encontrada!</h1>");
            }

            var html = @$"
                <html>
                    <head>
                        <title>Informações da Ordem</title>
                    </head>
                    <body>
                        <h1>Informações da Ordem</h1>
                        <p><strong>Id: </strong>{ordem.Id}</p>
                        <p><strong>Id do Caminhão: </strong>{ordem.CaminhaoId}</p>
                        <p><strong>Descrição: </strong>{ordem.Descricao}</p>
                        <p><strong>Tipo da Manutenção: </strong>{ordem.TipoManutencao}</p>
                        <p><strong>Data de Abertura: </strong>{ordem.DataAbertura}</p>
                        <p><strong>Status: </strong>{ordem.Status}</p>
                        <p><strong>Custo: </strong>{ordem.Custo}</p>
                        <button onclick=""location.href='/ordens/{ordem.Id}/status'"">Atualizar Status</button>
                        <button onclick=""location.href='/'"">Ínicio</button>
                        <button onclick=""location.href='/ordens'"">Ordens</button>
                    </body>
                </html>
            ";

            return Content(html, "text/html; charset=utf-8", Encoding.UTF8);
        }

        [HttpGet("{id}/status")]
        public IActionResult FormularioStatus(Guid id)
        {
            var ordem = ordens.FirstOrDefault(o => o.Id == id);

            if (ordem == null)
            {
                return NotFound("<h1>Ordem não encontrada!</h1>");
            }

            var html = @$"
            <html>
                <head>
                    <title>Atualizar Status</title>
                </head>
                <body>
                    <h1>Atualizar Status da Ordem</h1>
                    <form method='post' action='/ordens/{id}/status'>
                        <label>Status atual: <strong>{ordem.Status}</strong></label><br/><br/>
                        <label>Novo status:</label><br/>
                        <select name='novoStatus'>
                            <option value='Aberta'>Aberta</option>
                            <option value='Em andamento'>Em andamento</option>
                            <option value='Finalizada'>Finalizada</option>
                        </select><br/><br/>
                        <button type='submit'>Atualizar</button>
                    </form>
                    <br/>
                    <button onclick=""location.href='/ordens/{id}'"">Voltar</button>
                </body>
            </html>
        ";

            return Content(html, "text/html; charset=utf-8", Encoding.UTF8);
        }

        [HttpPost("{id}/status")]
        public IActionResult AtualizarStatus(Guid id)
        {
            var ordem = ordens.FirstOrDefault(o => o.Id == id);

            if (ordem == null)
            {
                return NotFound("<h1>Ordem não encontrada!</h1>");
            }

            var novoStatus = Request.Form["novoStatus"];

            ordem.Status = novoStatus;

            if (novoStatus == "Finalizada")
            {
                ordem.DataConclusao = DateTime.Now;
            }

            var html = @$"
                <html>
                    <head>
                        <title>Status Atualizado</title>
                    </head>
                    <body>
                        <h1>Status da Ordem Atualizado com Sucesso!</h1>
                        <p><strong>ID:</strong> {ordem.Id}</p>
                        <p><strong>Status Atual:</strong> {ordem.Status}</p>
                        <p><strong>Data de Conclusão:</strong> {ordem.DataConclusao}</p>
                        <button onclick=""location.href='/ordens/{id}'"">Voltar para a Ordem</button>
                        <button onclick=""location.href='/ordens'"">Voltar à Lista</button>
                    </body>
                </html>
            ";

            return Content(html, "text/html; charset=utf-8", Encoding.UTF8);
        }

        [HttpGet("caminhao/{caminhaoId}")]
        public IActionResult ListarPorCaminhao(string caminhaoId)
        {
            var ordensDoCaminhao = ordens.Where(o => o.CaminhaoId == caminhaoId).ToList();

            var htmlBuilder = new StringBuilder();

            htmlBuilder.Append($@"
                <html>
                    <head>
                        <title>Ordens do Caminhão {caminhaoId}</title>
                    </head>
                    <body>
                        <h1>Ordens do Caminhão {caminhaoId}</h1>
            ");

            if (ordensDoCaminhao.Count == 0)
            {
                htmlBuilder.Append($@"
                    <p>Não há ordens registradas para este caminhão.</p>
                ");
            }
            else
            {
                htmlBuilder.Append("<ul>");
                foreach (var ordem in ordensDoCaminhao)
                {
                htmlBuilder.Append($@"
                        <li>
                            <strong>ID da Ordem:</strong> {ordem.Id} |
                            <strong>Tipo:</strong> {ordem.TipoManutencao} |
                            <strong>Status:</strong> {ordem.Status} |
                            <strong>Data Abertura:</strong> {ordem.DataAbertura}
                            <button onclick=""location.href='/ordens/{ordem.Id}'"">Ver Detalhes</button>
                        </li><br/>
                    ");
                }
                htmlBuilder.Append("</ul>");
            }

            htmlBuilder.Append(@"
                        <button onclick=""location.href='/ordens'"">Voltar à Lista Geral</button>
                        <button onclick=""location.href='/'"">Início</button>
                    </body>
                </html>
            ");

        return Content(htmlBuilder.ToString(), "text/html; charset=utf-8", Encoding.UTF8);
        }
    }
}