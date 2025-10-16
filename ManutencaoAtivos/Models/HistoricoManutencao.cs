using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManutencaoAtivos.Model{
/*Classe Hist. Manutencao: Id, CaminhoaId,
 Descricao Serviso, Data servico, Custo e responsavel*/
    public class HistoricoAtivos
    {
        public int Id { get; set; }

        public int CaminhaoId { get; set; }

        public string DescricaoServico { get; set; }

        public DateTime DataServiso { get; set; }

        public decimal Custo { get; set; }

        public string Responsavel { get; set; }
    
    }
}

