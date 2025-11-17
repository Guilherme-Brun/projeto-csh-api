const API = "http://localhost:5024/caminhoes";

// 🎯 Referências explícitas dos inputs
const form          = document.getElementById("formCadastro");
const inputPlaca    = document.getElementById("placa");
const inputModelo   = document.getElementById("modelo");
const inputAno      = document.getElementById("ano");
const inputKm       = document.getElementById("km");
const inputStatus   = document.getElementById("status");
const inputUltima   = document.getElementById("ultima");
const inputProxima  = document.getElementById("proxima");

// ==========================
// 🟦 MÁSCARA PLACA (AAA-1234)
// ==========================
function aplicarMascaraPlaca(input) {
    if (!input) return;

    input.addEventListener("input", e => {
        let v = e.target.value.toUpperCase();

        // remove tudo que não for letra ou número
        v = v.replace(/[^A-Z0-9]/g, "");

        // limita em 7 caracteres
        if (v.length > 7) v = v.slice(0, 7);

        // coloca hífen após as 3 letras
        if (v.length >= 4) {
            v = v.replace(/^([A-Z]{3})(\d+)/, "$1-$2");
        }

        e.target.value = v;
    });
}

// ==========================
// 📅 MÁSCARA DATA (DD/MM/AAAA)
// ==========================
function aplicarMascaraData(input) {
    if (!input) return;

    input.addEventListener("input", e => {
        let v = e.target.value.replace(/\D/g, "").slice(0, 8);

        if (v.length >= 5) {
            v = v.replace(/(\d{2})(\d{2})(\d{1,4})/, "$1/$2/$3");
        } else if (v.length >= 3) {
            v = v.replace(/(\d{2})(\d{1,2})/, "$1/$2");
        }

        e.target.value = v;
    });
}

// aplica as máscaras
aplicarMascaraPlaca(inputPlaca);
aplicarMascaraData(inputUltima);
aplicarMascaraData(inputProxima);

// ==========================
// 🟩 SUBMIT DO FORM
// ==========================
form.addEventListener("submit", async e => {
    e.preventDefault();

    const body = {
        placa:  inputPlaca.value.trim().toUpperCase(),
        modelo: inputModelo.value.trim(),
        ano:    Number(inputAno.value),
        km:     Number(inputKm.value),
        status: inputStatus.value.trim(),

        dataUltimaRevisao: inputUltima.value
            ? inputUltima.value.split("/").reverse().join("-")
            : null,

        proximaRevisao: inputProxima.value
            ? inputProxima.value.split("/").reverse().join("-")
            : null
    };

    console.log("📤 ENVIANDO:", body);

    try {
        const resp = await fetch(API, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(body)
        });

        if (!resp.ok) {
            console.error(await resp.text());
            mostrarToast("❌ Erro ao cadastrar veículo!", "danger");
            return;
        }

        mostrarToast("🚛 Veículo cadastrado com sucesso!", "success");

        setTimeout(() => {
            window.location.href = "caminhoes.html";
        }, 1500);

    } catch (err) {
        console.error(err);
        mostrarToast("❌ Falha de comunicação com o servidor!", "danger");
    }
});

// ✅ Toast reutilizável
function mostrarToast(msg, cor = "success") {
    const toastEl = document.getElementById("toastMsgBox");
    const msgEl = document.getElementById("toastMsg");

    toastEl.className = `toast text-bg-${cor} border-0 shadow`;
    msgEl.innerHTML = msg;

    bootstrap.Toast.getOrCreateInstance(toastEl).show();
}

document.getElementById("formCadastro").addEventListener("submit", async e => {
    e.preventDefault();

    const body = {
        placa: placa.value,
        modelo: modelo.value,
        ano: Number(ano.value),
        km: Number(km.value),
        status: status.value.trim(),
        dataUltimaRevisao: ultima.value ? ultima.value.split("/").reverse().join("-") : null,
        proximaRevisao: proxima.value ? proxima.value.split("/").reverse().join("-") : null
    };

    const resp = await fetch(API, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(body)
    });

    if (!resp.ok) {
        mostrarToast("❌ Erro ao cadastrar!", "danger");
        return;
    }

        mostrarToast("🚛 Veículo cadastrado com sucesso!", "success");


    setTimeout(() => window.location.href = "caminhoes.html", 1300);
});





