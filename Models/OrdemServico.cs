using System;

namespace ManutencaoAtivos.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }                 // PK int
        public int CaminhaoId { get; set; }        // FK para Caminhao.Id
        public string Descricao { get; set; } = string.Empty;
        public string TipoManutencao { get; set; } = string.Empty; // Ex: "Preventiva","Corretiva","Preditiva"
        public decimal Custo { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string Status { get; set; } = "Aberta";
    }
}

