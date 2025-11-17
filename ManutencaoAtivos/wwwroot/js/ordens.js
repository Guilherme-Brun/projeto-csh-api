const API = "http://localhost:5024/ordens";

let listaOrdens = [];
let mapaPlacas = {};       

// 🔹 Controle de Ordenação
let ordemColuna = null;
let ordemAsc = true;

// ======================================================
// 🟡 CARREGAR PLACAS
// ======================================================
async function carregarPlacas() {
    const resp = await fetch("http://localhost:5024/caminhoes");
    const lista = await resp.json();
    mapaPlacas = Object.fromEntries(lista.map(c => [c.id, c.placa]));
}

// ======================================================
// 🟡 CARREGAR ORDENS
// ======================================================
async function carregarOrdens() {
    await carregarPlacas();
    const resp = await fetch(API);
    listaOrdens = await resp.json();
    renderizarTabela();
}

// ======================================================
// 🔹 FORMATADORES
// ======================================================
const fmtData = d => d ? new Date(d).toLocaleDateString("pt-BR") : "-";
const fmtCusto = v => v?.toLocaleString("pt-BR", { style: "currency", currency: "BRL" });

function formatarPlaca(p) {
    if (!p) return "";
    let v = p.toUpperCase().replace(/[^A-Z0-9]/g, "");
    if (/^[A-Z]{3}\d{4}$/.test(v))
        return v.replace(/^([A-Z]{3})(\d)/, "$1-$2");
    return v;
}

// ======================================================
// 🔹 STATUS BADGE
// ======================================================
function badgeStatus(s) {
    s = s?.toLowerCase();

    if (s === "concluída")
        return `<span class="badge-status concluida"><i class="bi bi-check-circle"></i> Concluída</span>`;

    if (s === "em andamento")
        return `<span class="badge-status andamento"><i class="bi bi-hourglass-split"></i> Em andamento</span>`;

    if (s === "cancelada")
        return `<span class="badge-status cancelada"><i class="bi bi-x-circle"></i> Cancelada</span>`;

    return `<span class="badge-status aberta"><i class="bi bi-exclamation-circle"></i> Aberta</span>`;
}

// ======================================================
// 🔹 RENDERIZAR TABELA (COM ORDENACÃO)
// ======================================================
function renderizarTabela() {
    let lista = [...listaOrdens];

    // 🔻 APLICA ORDENACÃO SE EXISTIR
    if (ordemColuna) {
        lista.sort((a, b) => {
            let x = a[ordemColuna], y = b[ordemColuna];

            if (typeof x === "string") x = x.toLowerCase();
            if (typeof y === "string") y = y.toLowerCase();

            return ordemAsc ? (x > y ? 1 : -1) : (x < y ? 1 : -1);
        });
    }

    // 🔻 PREENCHE TABELA
    document.querySelector("#tabelaOrdens tbody").innerHTML =
    lista.map(o => `
        <tr>
            <td>${o.id}</td>
            <td>🚚 ${formatarPlaca(mapaPlacas[o.caminhaoId]) ?? "?"}</td>
            <td>${o.tipoManutencao}</td>
            <td>${o.descricao}</td>
            <td>${fmtCusto(o.custo)}</td>
            <td>${badgeStatus(o.status)}</td>
            <td>${fmtData(o.dataAbertura)}</td>
            <td>${fmtData(o.dataConclusao)}</td>

            <td class="text-center">
                <button class="btn btn-sm btn-outline-primary" onclick="editarOS(${o.id})">
                    <i class="bi bi-pencil-square"></i>
                </button>

                <button class="btn btn-sm btn-outline-danger" onclick="excluirOS(${o.id})">
                    <i class="bi bi-trash3"></i>
                </button>
            </td>
        </tr>
    `).join("");

    atualizarIconesOrdenacao();
}

// ======================================================
// 🔹 SETAS ▲ ▼ NO CABEÇALHO
// ======================================================
const colunasTabela = ["id", "placa", "tipoManutencao", "descricao", "custo", "status", "dataAbertura", "dataConclusao"];

document.querySelectorAll("#tabelaOrdens thead th").forEach((th, i) => {
    th.style.cursor = "pointer";

    th.onclick = () => {
        if (!colunasTabela[i]) return;

        ordemAsc = ordemColuna === colunasTabela[i] ? !ordemAsc : true;
        ordemColuna = colunasTabela[i];

        renderizarTabela();
    };
});

function atualizarIconesOrdenacao() {
    const ths = document.querySelectorAll("#tabelaOrdens thead th");

    ths.forEach((th, i) => {
        th.innerHTML = th.innerHTML.replace(/ ▲| ▼/g, "");

        if (ordemColuna === colunasTabela[i]) {
            th.innerHTML += ordemAsc ? " ▲" : " ▼";
        }
    });
}

// ======================================================
// 🗑 EDITAR / EXCLUIR
// ======================================================
function editarOS(id) {
    location.href = `editar_ordem.html?id=${id}`;
}

async function excluirOS(id) {
    if (!confirm("⚠ Deseja remover esta ordem?")) return;
    await fetch(`${API}/${id}`, { method: "DELETE" });
    mostrarToast("🗑 Ordem removida!", "danger");
    carregarOrdens();
}

// ======================================================
// 🔔 TOAST
// ======================================================
function mostrarToast(msg, cor="success") {
    const box = document.getElementById("toastMsgBox");
    document.getElementById("toastMsg").innerHTML = msg;
    box.className = `toast text-bg-${cor}`;
    bootstrap.Toast.getOrCreateInstance(box).show();
}

// 🚀 INICIAR
carregarOrdens();



