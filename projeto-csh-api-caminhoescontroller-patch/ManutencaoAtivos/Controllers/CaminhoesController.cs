using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using ManutencaoAtivos.Models;

namespace ManutencaoAtivos.Controllers
{
    [ApiController]
    [Route("caminhoes")]
    public class CaminhoesController : ControllerBase
    {
        private static List<Caminhao> caminhoes = new();

        private static bool PlacaExiste(string placa, Guid? ignorarId = null)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                return false;
            }

            foreach (var c in caminhoes)
            {
                if (c.Id != ignorarId && string.Equals(c.Placa, placa, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        [HttpGet("")]
        public IActionResult Listar()
        {
            var htmlBuilder = new StringBuilder();

            htmlBuilder.Append(@"
                <html>
                    <head>
                        <title>Lista de caminhões</title>
                        <script>
                            function excluirCaminhao(id)
                            {
                                if (!confirm('Tem certeza que deseja excluir? ')) return;
                                
                                fetch('/caminhoes/excluir/' + id, {
                                    method: 'DELETE'
                                })
                                .then (res => {
                                    if (res.ok) {
                                        alert('Caminhão removido!');
                                        location.reload();
                                    } else {
                                        alert('Erro ao excluir o caminhão.');
                                    }
                                });
                            }
                            function redirecionarPorId()
                            {
                                const id = document.getElementById('id').value;
                                window.location.href = '/caminhoes/' + id;
                            }
                        </script>
                        </head>
                        <body>
                            <h1>Lista de caminhões</h1>
                            <div class=""lista-wrapper"">
                                <form onsubmit=""event.preventDefault(); redirecionarPorId();"">
                                    <label for='id'>ID do caminhão: </label><br />
                                    <input type='text' id='id' required /><br /><br />
                                    <button type='submit'>Buscar</button>
                                </form>
                                <button onclick=""location.href='/caminhoes/cadastro'"">Cadastar novo caminhão</button>
                                <ul>
            ");

            if (caminhoes.Count == 0)
            {
                htmlBuilder.Append("<li> Nenhum caminhão cadastrado</li>");
            }
            else
            {
                foreach (var c in caminhoes)
                {
                    htmlBuilder.Append($@"
                        <li class=""caminhao-item"">
                            <div class=""caminhao-info"">
                                <strong>Placa: </strong> {c.Placa} |
                                <strong>Modelo: </strong> {c.Modelo} |
                                <strong>Id: </strong> {c.Id}
                            </div>
                            <div class=""caminhao-acao"">
                                <button onclick=""excluirCaminhao('{c.Id}')"" class=""button-excluir"">Excluir</button>
                                <button onclick=""location.href='/caminhoes/editar/{c.Id}'"">Editar</button>
                                <button onclick=""location.href='/caminhoes/{c.Id}'"">Informações</button>
                            </div>
                        </li>");
                }
            }
            htmlBuilder.Append(@"
                            </ul>
                        </div>
                        <br />
                        <button onclick=""location.href='/'"">Ínicio</button>
            ");

            return Content(htmlBuilder.ToString(), "text/html; charset=utf-8", Encoding.UTF8);
        }

        [HttpGet("{id}")]
        public IActionResult ProcurarPorId(Guid id)
        {
            var caminhao = caminhoes.FirstOrDefault(c => c.Id == id);

            if (caminhao == null)
            {
                var htmlErro = @"
                    <html>
                        <head><title>Caminhão não encontrado</title></head>
                        <body>
                            <h1>Caminhão não encontrado!</h1>
                            <button onclick=""location.href='/caminhoes'"">Voltar</button>
                        </body>
                    </html>
                ";
        
                return Content(htmlErro, "text/html; charset=utf-8", Encoding.UTF8);
            }

            var html = $@"
                <html>
                    <head><title>Detalhes do caminhão</title></head>
                    <body>
                        <h1>Detalhes do caminhão</h1>
                        <p><strong>ID do caminhão: </strong> {caminhao.Id}</p>
                        <p><strong>Placa: </strong> {caminhao.Placa}</p>
                        <p><strong>Modelo: </strong> {caminhao.Modelo}</p>
                        <p><strong>Ano: </strong> {caminhao.Ano}</p>
                        <p><strong>Quilometragem: </strong> {caminhao.Km}</p>
                        <p><strong>Status: </strong> {caminhao.Status}</p>
                        <p><strong>Data da última revisão: </strong> {caminhao.DataUltimaRevisao}</p>
                        <p><strong>Data da próxima revisão: </strong> {caminhao.ProximaRevisao}</p>

                        <button onclick=""location.href='/caminhoes/editar/{id}'"">Editar</button>
                        <button onclick=""location.href='/caminhoes'"">Lista de caminhões</button>
                        <button onclick=""location.href='/'"">Ínicio</button>
                    </body>
                </html>
            ";

            return Content(html, "text/html; charset=utf-8", Encoding.UTF8);
        }

        [HttpGet("cadastro")]
        public IActionResult Cadastro()
        {
            var html = @$"
                <html>
                    <head>
                        <title>Cadastro</title>
                    </head>
                    <body>
                        <h1>Cadastro de caminhão</h1>
                        <form method='post'>
                            <label>Placa: </label><br />
                            <input type='text' name='placa' required /><br /><br />
                            <label>Modelo: </label><br />
                            <input type='text' name='modelo' required /><br /><br />
                            <label>Ano: </label><br />
                            <input type='text' name='ano' required /><br /><br />
                            <button type='submit'>Cadastrar</button>
                        </form>
                        <br />
                        <button onclick=""location.href='/caminhoes'"">Lista de caminhões</button>
                        <button onclick=""location.href='/'"">Ínicio</button>
                    </body>
                </html>
            ";

            return Content(html, "text/html; charset=utf-8", Encoding.UTF8); 
        }

        [HttpPost("cadastro")]
        public IActionResult ArmazenarCadastro()
        {
            var id = Guid.NewGuid();
            var placa = Request.Form["placa"];
            var modelo = Request.Form["modelo"];
            var ano = int.Parse(Request.Form["ano"].ToString());

            if (string.IsNullOrEmpty(placa) || string.IsNullOrEmpty(modelo))
            {
                var erroHtml = @"
                    <html>
                        <head>
                            <title>Erro no cadastro</title>
                        </head>
                        <body>
                            <h1>Erro: Preencha todos os campos!</h1>
                            <button onclick=""location.href='/cadastro'"">Voltar</button>
                        </body>
                    </html>
                ";

                return Content(erroHtml, "text/html; charset=utf-8", Encoding.UTF8);
            }

            if (PlacaExiste(placa!))
            {
                var erroDuplicata = @"
                    <html>
                        <head>
                            <title>Erro no cadastro</title>
                        </head>
                        <body>
                            <h1>Placa do caminhão já existe! Tente novamente!</h1>
                            <button onclick=""location.href='/caminhoes/cadastro'"">Voltar</button>
                        </body>
                    </html>
                ";

                return Content(erroDuplicata, "text/html; charset=utf-8", Encoding.UTF8);
            }

            caminhoes.Add(new Caminhao(
                id!,
                placa!,
                modelo!,
                ano!
            ));

            var html = $@"
                <html>
                    <head>
                        <title>Cadastro realizado!</title>
                    </head>
                    <body>
                        <h1>Cadastro realizado com sucesso!</h1>
                        <p><strong>Id: {id}</strong></p>
                        
                        <p>Quantidade total de caminhões: {caminhoes.Count}</p>

                        <button onclick=""location.href='/caminhoes'"">Lista de caminhões</button>
                        <button onclick=""location.href='/'"">Ínicio</button>
                    </body>
                </html>
            ";

            return Content(html, "text/html; charset=utf-8", Encoding.UTF8);
        }

        [HttpGet("editar/{id}")]
        public IActionResult Editar(Guid id)
        {
            var caminhao = caminhoes.FirstOrDefault(c => c.Id == id);

            if (caminhao == null)
            {
                return NotFound();
            }

            var html = $@"
                <head>
                    <title>Editar caminhão</title>
                    <script>
                        function atualizarCaminhao(id) 
                        {{
                            const placa = document.getElementById('placa').value;
                            const modelo = document.getElementById('modelo').value;
                            const ano = parseInt(document.getElementById('ano').value);

                            fetch('/caminhoes/atualizar/' + id, {{
                                method: 'PUT',
                                headers: {{
                                    'Content-Type': 'application/json'
                                }},
                                body: JSON.stringify({{ placa, modelo, ano }})
                            }})

                            .then(res => {{
                                if (res.ok) 
                                {{
                                    alert('Caminhão atualizado com sucesso!');
                                    location.href = '/caminhoes/{id}';
                                }}
                                else
                                {{
                                    res.text().then(msg => {{
                                        document.getElementById('mensagemErro').innerText = msg;
                                    }})
                                }}
                            }});
                        }}
                    </script>
                </head>
                <body>
                    <h1>Editar caminhão</h1>
                    <form onsubmit=""event.preventDefault(); atualizarCaminhao('{caminhao.Id}')"">
                        <div id='mensagemErro'></div>

                        <label>Placa: </label><br />
                        <input type='text' id='placa' value='{caminhao.Placa}' required /><br /><br />

                        <label>Modelo: </label><br />
                        <input type='text' id='modelo' value='{caminhao.Modelo}' required /><br /><br />

                        <label>Ano: </label><br />
                        <input type='text' id='ano' value='{caminhao.Ano}' required /><br /><br />
                        
                        <button type='submit'>Atualizar</button>
                    </form>
                    <br />
                    <button onclick=""location.href='/caminhoes'"">Voltar</button>
                </body>
            ";

            return Content(html, "text/html; chatset=utf-8", Encoding.UTF8);
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] Caminhao dados)
        {
            var caminhao = caminhoes.FirstOrDefault(c => c.Id == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            if (PlacaExiste(dados.Placa, caminhao.Id))
            {
                return BadRequest("Placa do caminhão já existe!");
            }
            
            caminhao.Placa = dados.Placa;
            caminhao.Modelo = dados.Modelo;
            caminhao.Ano = dados.Ano;

            return NoContent();
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Excluir(Guid id)
        {
            var caminhao = caminhoes.FirstOrDefault(c => c.Id == id);

            if (caminhao == null)
            {
                return NotFound();
            }

            caminhoes.Remove(caminhao);
            return NoContent();
        }
    }
}