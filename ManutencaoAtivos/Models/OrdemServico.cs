using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManutencaoAtivos.Models{
    /*Classe Ordem serviço: Id, CaminhaoId, Descricao, Tipo Manutencao,
     Data Abertura, Data Conclusao, Status e Custo*/
    public class OrdemServico
    {
        public int Id { get; set; }

        public int CaminhaoId { get; set; }

        public required string Descricao { get; set; }

        public required string TipoManutencao { get; set; }

        public DateTime DataAbertura { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Aberta";  /*Atribui valor*/

        public decimal Custo { get; set; }

    }
}