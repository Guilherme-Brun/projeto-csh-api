const API = "http://localhost:5024";

const params = new URLSearchParams(location.search);
const id = params.get("id");

const idField     = document.getElementById("id");
const caminhaoId  = document.getElementById("caminhaoId");
const descricao   = document.getElementById("descricao");
const tipo        = document.getElementById("tipo");
const status      = document.getElementById("status");
const custo       = document.getElementById("custo");
const abertura    = document.getElementById("abertura");
const conclusao   = document.getElementById("conclusao");
const formEdicao  = document.getElementById("formEdicao");

// ----------------------------------
// FORMATADORES
// ----------------------------------
function formatarDDMM(data) {
    return data ? new Date(data).toLocaleDateString("pt-BR") : "";
}

function maskData(input) {
    input.addEventListener("input", e => {
        let v = e.target.value.replace(/\D/g, "").slice(0, 8);
        if (v.length >= 5) v = v.replace(/(\d{2})(\d{2})(\d+)/, "$1/$2/$3");
        else if (v.length >= 3) v = v.replace(/(\d{2})(\d+)/, "$1/$2");
        input.value = v;
    });
}

// ----------------------------------
// 🔹 MÁSCARA DE CUSTO R$
// ----------------------------------
function maskCusto(input) {
    input.addEventListener("input", e => {
        let v = e.target.value.replace(/\D/g, "");

        if (v === "") {
            input.value = "";
            return;
        }

        v = (Number(v) / 100).toLocaleString("pt-BR", {
            style: "currency",
            currency: "BRL"
        });

        input.value = v;
    });
}

// ----------------------------------
// 🔹 FORMATA PLACA
// ----------------------------------
function formatarPlaca(p) {
    if (!p) return "";

    let v = p.toUpperCase().replace(/[^A-Z0-9]/g, "");

    if (/^[A-Z]{3}\d{4}$/.test(v))
        return v.replace(/^([A-Z]{3})(\d)/, "$1-$2");

    return v;
}

function maskPlacaInput(select) {
    select.addEventListener("change", () => {
        let opt = select.options[select.selectedIndex];
        opt.text = formatarPlaca(opt.text);
    });
}

// ----------------------------------
// TOAST
// ----------------------------------
function mostrarToast(msg, cor = "success") {
    const box = document.getElementById("toastMsgBox");
    document.getElementById("toastMsg").innerHTML = msg;
    box.className = `toast text-bg-${cor}`;
    bootstrap.Toast.getOrCreateInstance(box).show();
}

// ----------------------------------
// CARREGAR PLACAS
// ----------------------------------
async function carregarPlacas() {
    const resp = await fetch(`${API}/caminhoes`);
    const lista = await resp.json();

    caminhaoId.innerHTML = lista
        .map(c => `<option value="${c.id}">${formatarPlaca(c.placa)}</option>`)
        .join("");
}

// ----------------------------------
// CARREGAR ORDEM
// ----------------------------------
async function carregarOrdem() {
    const resp = await fetch(`${API}/ordens/${id}`);
    const o = await resp.json();

    idField.value     = o.id;
    caminhaoId.value  = o.caminhaoId;
    descricao.value   = o.descricao;
    tipo.value        = o.tipoManutencao;
    status.value      = o.status;

    custo.value = o.custo?.toLocaleString("pt-BR", {
        style: "currency",
        currency: "BRL"
    });

    abertura.value  = formatarDDMM(o.dataAbertura);
    conclusao.value = formatarDDMM(o.dataConclusao);
}

// ----------------------------------
// SALVAR ALTERAÇÕES
// ----------------------------------
formEdicao.addEventListener("submit", async e => {
    e.preventDefault();

    if (conclusao.value) {
        const A = new Date(abertura.value.split("/").reverse());
        const C = new Date(conclusao.value.split("/").reverse());
        if (C < A)
            return mostrarToast("⚠ Conclusão antes da abertura!", "warning");
    }

    const custoNumerico = custo.value
        ? Number(custo.value.replace(/\D/g, "")) / 100
        : 0;

    const body = {
        id: Number(id),
        caminhaoId: Number(caminhaoId.value),
        descricao: descricao.value.trim(),
        tipoManutencao: tipo.value,
        status: status.value,
        custo: custoNumerico,
        dataAbertura: abertura.value.split("/").reverse().join("-") + "T00:00:00",
        dataConclusao: conclusao.value
            ? conclusao.value.split("/").reverse().join("-") + "T00:00:00"
            : null
    };

    const resp = await fetch(`${API}/ordens/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(body)
    });

    if (!resp.ok) return mostrarToast("❌ Erro ao salvar!", "danger");

    mostrarToast("🟢 Ordem atualizada!");

    setTimeout(() => location.href = "ordens.html", 1200);
});

// ----------------------------------
// INIT
// ----------------------------------
document.addEventListener("DOMContentLoaded", async () => {
    maskData(abertura);
    maskData(conclusao);
    maskCusto(custo);

    await carregarPlacas();

    maskPlacaInput(caminhaoId);

    await carregarOrdem();
});

