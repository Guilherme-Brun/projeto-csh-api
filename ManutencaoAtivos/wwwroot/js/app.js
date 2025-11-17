const API_URL = "http://localhost:5024/caminhoes";

async function carregarCaminhoes() {
    const resp = await fetch(API_URL);
    const dados = await resp.json();

    const tbody = document.querySelector("#tabelaCaminhoes tbody");
    tbody.innerHTML = "";

    dados.forEach(c => {
        const linha = document.createElement("tr");

        linha.innerHTML = `
            <td>${c.id}</td>
            <td>${c.placa}</td>
            <td>${c.modelo}</td>
            <td>${c.ano}</td>
            <td>${c.km}</td>
            <td>${c.status}</td>
            <td>${formatarData(c.dataUltimaRevisao)}</td>
            <td>${formatarData(c.proximaRevisao)}</td>
            <td><button class="delete-btn" onclick="excluir(${c.id})">Excluir</button></td>
        `;

        tbody.appendChild(linha);
    });
}

async function excluir(id) {
    if (!confirm("Tem certeza que deseja excluir?")) return;

    await fetch(`${API_URL}/${id}`, { method: "DELETE" });
    carregarCaminhoes();
}

function formatarData(data) {
    if (!data) return "-";
    return new Date(data).toLocaleDateString("pt-BR");
}

carregarCaminhoes();
