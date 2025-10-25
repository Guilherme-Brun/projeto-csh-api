using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManutencaoAtivos.Models{
    /*Classe Ordem serviço: Id, CaminhaoId, Descricao, Tipo Manutencao,
     Data Abertura, Data Conclusao, Status e Custo*/
    public class OrdemServico
    {
        public Guid Id { get; set; }

        public string CaminhaoId { get; set; }

        public string Descricao { get; set; }

        public string TipoManutencao { get; set; }

        public DateTime DataAbertura { get; set; }

        public DateTime? DataConclusao { get; set; }

        public string Status { get; set; } = "Aberta";  /*Atribui valor*/

        public decimal Custo { get; set; }

        public OrdemServico(Guid id, String caminhaoId, String descricao, String tipoManutencao, decimal custo)
        {
            Id = id;
            CaminhaoId = caminhaoId;
            Descricao = descricao;
            TipoManutencao = tipoManutencao;
            DataAbertura = DateTime.Now;
            DataConclusao = null;
            Status = "Aberta";
            Custo = custo;
        }
    }
}