const API = "http://localhost:5024";
const params = new URLSearchParams(location.search);
const id = params.get("id");

// -------------------------------------------------
// 🟡 CAMPOS DO FORMULÁRIO
// -------------------------------------------------
const idField = document.getElementById("id");
const caminhaoId = document.getElementById("caminhaoId");
const descricao = document.getElementById("descricao");
const tipo = document.getElementById("tipo");
const status = document.getElementById("status");
const custo = document.getElementById("custo");
const abertura = document.getElementById("abertura");
const conclusao = document.getElementById("conclusao");
const formEdicao = document.getElementById("formEdicao");

// -------------------------------------------------
// 🟡 CARREGAR PLACAS
// -------------------------------------------------
async function carregarPlacas() {
  const resp = await fetch(`${API}/caminhoes`);
  const lista = await resp.json();

  caminhaoId.innerHTML = lista
    .map(c => `<option value="${c.id}">${c.placa}</option>`)
    .join("");
}

// -------------------------------------------------
// 🟡 CARREGAR ORDEM
// -------------------------------------------------
async function carregarOrdem() {
  const resp = await fetch(`${API}/ordens/${id}`);

  if (!resp.ok)
    return mostrarToast("❌ Ordem não encontrada!", "danger");

  const o = await resp.json();

  idField.value = o.id;
  caminhaoId.value = o.caminhaoId;
  descricao.value = o.descricao;
  tipo.value = o.tipoManutencao;
  status.value = o.status;
  custo.value = o.custo?.toString().replace(".", ",");

  abertura.value = formatarDDMM(o.dataAbertura);
  conclusao.value = formatarDDMM(o.dataConclusao);
}

// -------------------------------------------------
// 📆 FORMATAR DATA (ISO → DD/MM/YYYY)
// -------------------------------------------------
function formatarDDMM(data) {
  return data ? new Date(data).toLocaleDateString("pt-BR") : "";
}

// -------------------------------------------------
// 💾 SALVAR ATUALIZAÇÃO
// -------------------------------------------------
formEdicao.addEventListener("submit", async e => {
  e.preventDefault();

  if (conclusao.value) {
    const A = new Date(abertura.value.split("/").reverse());
    const C = new Date(conclusao.value.split("/").reverse());

    if (C < A)
      return mostrarToast("⚠ Conclusão não pode ser antes da abertura!", "warning");
  }

  const body = {
    id: Number(id),
    caminhaoId: Number(caminhaoId.value),
    descricao: descricao.value.trim(),
    tipoManutencao: tipo.value,
    status: status.value,
    custo: custo.value ? Number(custo.value.replace(",", ".")) : 0,
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

  if (!resp.ok)
    return mostrarToast("❌ Erro ao salvar!", "danger");

  mostrarToast("🟢 Ordem atualizada!");
  setTimeout(() => location.href = "ordens.html", 1000);
});

// -------------------------------------------------
// 🔔 TOAST BOOTSTRAP
// -------------------------------------------------
function mostrarToast(msg, cor = "success") {
  const box = document.getElementById("toastMsgBox");
  document.getElementById("toastMsg").innerHTML = msg;
  box.className = `toast text-bg-${cor} border-0 shadow-lg`;
  bootstrap.Toast.getOrCreateInstance(box).show();
}

// -------------------------------------------------
// 🧹 MÁSCARA DE DATA
// -------------------------------------------------
function maskData(input) {
  input.addEventListener("input", e => {
    let v = e.target.value.replace(/\D/g, "").slice(0, 8);
    if (v.length >= 5) v = v.replace(/(\d{2})(\d{2})(\d{1,4})/, "$1/$2/$3");
    else if (v.length >= 3) v = v.replace(/(\d{2})(\d{1,2})/, "$1/$2");
    input.value = v;
  });
}

maskData(abertura);
maskData(conclusao);

// -------------------------------------------------
// 🚀 START
// -------------------------------------------------
document.addEventListener("DOMContentLoaded", async () => {
  await carregarPlacas();
  await carregarOrdem();
});








