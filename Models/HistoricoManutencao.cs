using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManutencaoAtivos.Models{
/*Classe Hist. Manutencao: Id, CaminhoaId,
 Descricao Serviso, Data servico, Custo e responsavel*/
    public class HistoricoManutencao
    {
        public int Id { get; set; }

        public int CaminhaoId { get; set; }

        public required string DescricaoServico { get; set; }

        public DateTime DataServico { get; set; }

        public decimal Custo { get; set; }

        public required string Responsavel { get; set; }
    
    }
}
