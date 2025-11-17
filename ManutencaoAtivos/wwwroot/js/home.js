const API_URL = "http://localhost:5024/api";

async function carregarRotas() {
    const resp = await fetch(API_URL);
    const dados = await resp.json();

    const container = document.getElementById("rotaContainer");

    dados.rotas_disponiveis.forEach(rot => {
        const card = document.createElement("div");
        card.className = "card";

        if (rot === "caminhoes") {
            card.innerText = "CADASTRO DE VEÍCULOS";
            card.onclick = () => location.href = "caminhoes.html";
        }

        if (rot === "ordens") {
            card.innerText = "ORDENS DE SERVIÇO";
            card.onclick = () => location.href = "ordens.html";
        }

        if (rot === "historico") {
            card.innerText = "HISTÓRICO DE ORDENS";
            card.onclick = () => location.href = "historico.html";
        }

        container.appendChild(card);
    });
}

carregarRotas();

