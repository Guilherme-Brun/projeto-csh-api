using System;
using System.ComponentModel.DataAnnotations;

namespace ManutencaoAtivos.ComponentModel
{
/*Classe caminhão: id, placa, modelo, ano, kmatual, status, ultima revisao e proxima revisao*/
    public class Caminhao
    {
        public int Id { get; set; }

        public string Placa { get; set; } = string.Empty; /*Atribuir um valor padrão*/

        public string Modelo { get; set; } = string.Empty; /*Atribuir um valor padrão*/

        public int ano { get; set; }

        public double Km { get; set; }

        public string Status { get; set; } = "Em operação"; /*Atribui valor*/

        public DateTime DataUltimaRevisao { get; set; }

        public DateTime ProximaRevisao { get; set; }

    }
    
}