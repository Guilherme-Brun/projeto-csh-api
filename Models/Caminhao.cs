using System;

namespace ManutencaoAtivos.Models
{
    public class Caminhao
    {
        // Agora Id é inteiro (PK) — 1..50
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public int Km { get; set; }
        public string Status { get; set; } = "Ativo";
        public DateTime? DataUltimaRevisao { get; set; }
        public DateTime? ProximaRevisao { get; set; }

        // Construtor sem parâmetros
        public Caminhao() { }
    }
}

