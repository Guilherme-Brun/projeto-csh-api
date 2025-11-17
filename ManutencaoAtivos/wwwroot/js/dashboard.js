async function carregarDashboard() {

    // 🔹 Caminhões
    const respC = await fetch("http://localhost:5024/caminhoes");
    const caminhões = await respC.json();

    const ativos = caminhões.filter(c => c.status === "Ativo").length;
    const revisoesAtrasadas = caminhões.filter(c => {
        if (!c.proximaRevisao) return false;
        return new Date(c.proximaRevisao) < new Date();
    }).length;

    document.getElementById("cardAtivos").innerText = ativos;
    document.getElementById("cardRevisoes").innerText = revisoesAtrasadas;

    // 🔹 Ordens
    const respO = await fetch("http://localhost:5024/ordens");
    const ordens = await respO.json();

    const abertas = ordens.filter(o => o.status !== "Finalizada").length;
    document.getElementById("cardOrdens").innerText = abertas;
}

carregarDashboard();
