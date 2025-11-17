const API = "http://localhost:5024";

// ==========================================
// 🚚 Carregar placas no <select>
// ==========================================
async function carregarPlacas() {
    const resp = await fetch(`${API}/caminhoes`);
    const lista = await resp.json();

    caminhaoId.innerHTML =
        `<option value="">Selecione...</option>` +
        lista.map(c => `<option value="${c.id}">${c.placa}</option>`).join("");
}

// ==========================================
// 💰 Máscara de custo (R$ 0,00)
// ==========================================
custo.addEventListener("input", () => {
    let v = custo.value.replace(/\D/g, "");
    v = (v / 100).toFixed(2) + "";
    v = v.replace(".", ",");
    custo.value = `R$ ${v}`;
});

// ==========================================
// 💾 Salvar nova ordem
// ==========================================
formOS.addEventListener("submit", async e => {
    e.preventDefault();

    if (!caminhaoId.value)
        return mostrarToast("⚠ Selecione um veículo!", "warning");

    const body = {
        caminhaoId: Number(caminhaoId.value),
        descricao: descricao.value.trim(),
        tipoManutencao: tipo.value,
        status: "Aberta",
        custo: Number(custo.value.replace("R$","").replace(".","").replace(",", ".")),
        dataAbertura: new Date().toISOString()
    };

    const resp = await fetch(`${API}/ordens`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(body)
    });

    if (!resp.ok)
        return mostrarToast("❌ Erro ao salvar!", "danger");

    mostrarToast("🟢 Ordem cadastrada com sucesso!");

    setTimeout(() => location.href = "ordens.html", 1200);
});

// ==========================================
// 🔔 Toast
// ==========================================
function mostrarToast(msg, cor = "success") {
    const box = document.getElementById("toastMsgBox");
    document.getElementById("toastMsg").innerHTML = msg;
    box.className = `toast text-bg-${cor} border-0 shadow-lg`;
    bootstrap.Toast.getOrCreateInstance(box).show();
}

// 🚀 START
carregarPlacas();
