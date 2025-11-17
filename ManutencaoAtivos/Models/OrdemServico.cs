using System;

namespace ManutencaoAtivos.Models
{
   public class OrdemServico
{
    public int Id { get; set; }
    public int CaminhaoId { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string TipoManutencao { get; set; } = string.Empty;
    public decimal Custo { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime? DataConclusao { get; set; }

    public string Status { get; set; } = "Aberta";  // 🔹 Apenas dois estados válidos
}

}

