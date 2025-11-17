const API_URL = "http://localhost:5024/caminhoes";

let paginaAtual = 1;
const itensPorPagina = 15;
let ordemColuna = null;
let ordemAsc = true;

// ======================================================
// 🔹 Carrega da API E PREENCHE FILTROS
// ======================================================
async function carregarCaminhoes() {

    const resp = await fetch(API_URL);
    window._caminhoes = await resp.json();

    preencherFiltros();
    renderizarTabela(window._caminhoes);
}

// ======================================================
// 🔹 Preenche ANOS e MODELOS dinamicamente
// ======================================================
function preencherFiltros() {

    const anos = [...new Set(window._caminhoes.map(c => c.ano))].sort();
    document.getElementById("filtroAno").innerHTML +=
        anos.map(a => `<option>${a}</option>`).join("");

    const modelos = [...new Set(window._caminhoes.map(c => c.modelo))].sort();
    document.getElementById("filtroModelo").innerHTML +=
        modelos.map(m => `<option>${m}</option>`).join("");
}

// ======================================================
// 🔹 Renderiza tabela (ACEITA lista externa)
// ======================================================
function renderizarTabela(lista = window._caminhoes) {

    lista = aplicarFiltros(lista);
    atualizarIconesOrdenacao();

    // 🔽 Ordenação correta
    if (ordemColuna) {
        lista.sort((a, b) => {
            let x = a[ordemColuna];
            let y = b[ordemColuna];

            if (typeof x === "string") {
                x = x.toLowerCase();
                y = y.toLowerCase();
            }

            return ordemAsc ? (x > y ? 1 : -1) : (x < y ? 1 : -1);
        });
    }

    // 🔢 Paginação
    const inicio = (paginaAtual - 1) * itensPorPagina;
    const pagina = lista.slice(inicio, inicio + itensPorPagina);

    document.getElementById("countRange").innerText =
        `${inicio + 1} - ${inicio + pagina.length} de ${lista.length}`;

    // 🖨 MONTA TABELA
    document.querySelector("#tabelaCaminhoes tbody").innerHTML = pagina
        .map(c => `
        <tr>
            <td>${c.id}</td>
            <td>${formatarPlaca(c.placa)}</td>
            <td>${c.modelo}</td>
            <td>${c.ano}</td>
            <td>${c.km}</td>
            <td>${badgeStatus(c.status)}</td>
            <td>${formatar(c.dataUltimaRevisao)}</td>
            <td>${formatar(c.proximaRevisao)}</td>
            <td>
                <button class="btn btn-primary btn-compact" onclick="editar(${c.id})">
                    <i class="bi bi-pencil-square"></i>
                </button>
                <button class="btn btn-danger btn-compact" onclick="excluir(${c.id})">
                    <i class="bi bi-trash"></i>
                </button>
            </td>
        </tr>`
    ).join("");

    renderizarPaginacao(lista.length);
}

// ======================================================
// 🔹 FILTRAGEM
// ======================================================
function aplicarFiltros(lista) {

    const busca = document.getElementById("busca").value.toLowerCase();
    const status = document.getElementById("filtroStatus").value.toLowerCase();
    const ano = document.getElementById("filtroAno").value;
    const modelo = document.getElementById("filtroModelo").value.toLowerCase();

    return lista.filter(c => {

        if (busca && !(
            c.placa.toLowerCase().includes(busca) ||
            c.modelo.toLowerCase().includes(busca)
        )) return false;

        if (status && c.status.toLowerCase() !== status) return false;
        if (ano && c.ano.toString() !== ano) return false;
        if (modelo && c.modelo.toLowerCase() !== modelo) return false;

        return true;
    });
}

// ======================================================
// 🔹 EVENTOS - filtro + reset página
// ======================================================
["busca", "filtroStatus", "filtroAno", "filtroModelo"].forEach(id => {
    document.getElementById(id)?.addEventListener("input", () => {
        paginaAtual = 1;
        renderizarTabela();
    });
});

// ======================================================
// 🔹 ORDENAR AO CLICAR NO CABEÇALHO (COM SETAS)
// ======================================================
document.querySelectorAll("#tabelaCaminhoes thead th").forEach((th, i) => {
    th.style.cursor = "pointer";

    th.onclick = () => {
        const colunas = ["id", "placa", "modelo", "ano", "km", "status"];

        if (!colunas[i]) return;

        if (ordemColuna === colunas[i]) {
            ordemAsc = !ordemAsc;
        } else {
            ordemColuna = colunas[i];
            ordemAsc = true;
        }

        atualizarIconesOrdenacao();
        renderizarTabela();
    };
});

// ======================================================
// 🔹 🔻 Função que coloca ▲ ▼ nos títulos
// ======================================================
function atualizarIconesOrdenacao() {
    const ths = document.querySelectorAll("#tabelaCaminhoes thead th");
    const colunas = ["id", "placa", "modelo", "ano", "km", "status"];

    ths.forEach((th, i) => {

        th.innerHTML = th.innerHTML.replace(/ ▲| ▼/g, "");

        if (colunas[i] === ordemColuna) {
            th.innerHTML += ordemAsc ? " ▲" : " ▼";
        }
    });
}

// ======================================================
function renderizarPaginacao(total) {
    const paginas = Math.ceil(total / itensPorPagina);

    document.getElementById("paginacao").innerHTML =
        Array.from({ length: paginas }, (_, i) => `
        <li class="page-item ${i + 1 === paginaAtual ? "active" : ""}">
            <button class="page-link" onclick="paginaAtual=${i + 1}; renderizarTabela()">
                ${i + 1}
            </button></li>`).join("");
}

// ======================================================
let deleteId = null;

function excluir(id) {
    deleteId = id;
    bootstrap.Modal.getOrCreateInstance(
        document.getElementById("modalConfirmDelete")
    ).show();
}


function editar(id) {
    location.href = `editar_caminhao.html?id=${id}`;
}

// ======================================================
function badgeStatus(s) {
    s = s?.toLowerCase();

    if (s === "ativo")
        return `<span class="badge-status ativo"><i class="bi bi-check-circle"></i> Ativo</span>`;

    if (s === "inativo")
        return `<span class="badge-status inativo"><i class="bi bi-x-circle"></i> Inativo</span>`;

    return `<span class="badge-status manutencao"><i class="bi bi-tools"></i> Manutenção</span>`;
}

function formatar(d) {
    return d ? new Date(d).toLocaleDateString("pt-BR") : "-";
}

function formatarPlaca(placa) {
    if (!placa) return "";
    placa = placa.replace(/[^a-zA-Z0-9]/g, "").toUpperCase();

    if (placa.length > 3)
        return placa.slice(0, 3) + "-" + placa.slice(3);

    return placa;
}
function mostrarToast(msg, cor = "success") {
    const toastEl = document.getElementById("toastMsgBox");
    const msgEl = document.getElementById("toastMsg");

    toastEl.className = `toast text-bg-${cor} border-0 shadow`;
    msgEl.innerHTML = msg;

    bootstrap.Toast.getOrCreateInstance(toastEl).show();
}
document.getElementById("btnDeleteConfirm").addEventListener("click", async () => {

    if (!deleteId) return;

    await fetch(`${API_URL}/${deleteId}`, { method: "DELETE" });

    bootstrap.Modal.getInstance(
        document.getElementById("modalConfirmDelete")
    ).hide();

    mostrarToast("🗑 Veículo removido com sucesso!", "danger");

    carregarCaminhoes();
});


// ======================================================
// 🚀 Inicializa tudo
// ======================================================
carregarCaminhoes();

