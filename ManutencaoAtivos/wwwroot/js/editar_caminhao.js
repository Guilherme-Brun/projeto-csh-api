const API = "http://localhost:5024/caminhoes";
const params = new URLSearchParams(location.search);
const id = params.get("id");
console.log(id);

// -----------------------------
// CAMPOS DO FORMULÁRIO
// -----------------------------
const idField = document.getElementById("id");
const placa = document.getElementById("placa");
const modelo = document.getElementById("modelo");
const ano = document.getElementById("ano");
const km = document.getElementById("km");
const status = document.getElementById("status");
const ultimaRev = document.getElementById("ultimaRev");
const proximaRev = document.getElementById("proximaRev");
const formEdicao = document.getElementById("formEdicao");

// -----------------------------
// 🔹 MÁSCARA DE PLACA
// -----------------------------
placa.addEventListener("input", e => {
  let v = e.target.value.toUpperCase().replace(/[^A-Z0-9]/g, "");
  if (v.length > 3) v = v.replace(/^([A-Z]{3})(\w+)/, "$1-$2");
  e.target.value = v;
});

// -----------------------------
// 🔹 MÁSCARA DE DATA
// -----------------------------
function maskDate(input) {
  input.addEventListener("input", e => {
    let v = e.target.value.replace(/\D/g, "").slice(0, 8);
    if (v.length >= 5) v = v.replace(/(\d{2})(\d{2})(\d+)/, "$1/$2/$3");
    else if (v.length >= 3) v = v.replace(/(\d{2})(\d+)/, "$1/$2");
    input.value = v;
  });
}
maskDate(ultimaRev);
maskDate(proximaRev);

// -----------------------------
// 🔹 CONVERTERS DE DATA
// -----------------------------
const fmtBR = d => d ? new Date(d).toLocaleDateString("pt-BR") : "";
const fmtISO = d => d ? d.split("/").reverse().join("-") + "T00:00:00" : null;

// -----------------------------
// 🔹 TOAST
// -----------------------------
function toast(msg, cor = "success") {
  const box = document.getElementById("toastMsgBox");
  document.getElementById("toastMsg").innerHTML = msg;
  box.className = `toast text-bg-${cor} border-0 shadow-lg`;
  bootstrap.Toast.getOrCreateInstance(box).show();
}

// -----------------------------
// 🔹 CARREGAR VEÍCULO
// -----------------------------
async function carregarCaminhao() {
  const resp = await fetch(`${API}/${id}`);
  console.log(resp);
  if (!resp.ok) return toast("❌ Veículo não encontrado!", "danger");

  const c = await resp.json();
  console.log(c);

  idField.value = c.id;
  placa.value = c.placa;
  modelo.value = c.modelo;
  ano.value = c.ano;
  km.value = c.km;
  status.value = c.status;

  ultimaRev.value = fmtBR(c.dataUltimaRevisao);
  proximaRev.value = fmtBR(c.proximaRevisao);
}

// -----------------------------
// 🔹 SALVAR ALTERAÇÕES
// -----------------------------
formEdicao.addEventListener("submit", async e => {
  e.preventDefault();

  if (proximaRev.value && ultimaRev.value) {
    if (new Date(proximaRev.value.split("/").reverse()) <
        new Date(ultimaRev.value.split("/").reverse()))
      return toast("⚠ Próxima revisão não pode ser antes da última!", "warning");
  }

  const body = {
    id: Number(id),
    placa: placa.value.trim(),
    modelo: modelo.value.trim(),
    ano: Number(ano.value),
    km: Number(km.value),
    status: status.value,
    dataUltimaRevisao: fmtISO(ultimaRev.value),
    proximaRevisao: fmtISO(proximaRev.value)
  };

  const resp = await fetch(`${API}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(body)
  });

  if (!resp.ok) return toast("❌ Erro ao salvar!", "danger");

  toast("🟢 Veículo atualizado!");
  setTimeout(() => location.href = "caminhoes.html", 1000);
});

// -----------------------------
// 🚀 START
// -----------------------------
document.addEventListener("DOMContentLoaded", function()
{
  carregarCaminhao();
});
