using System;
using System.ComponentModel.DataAnnotations;

namespace ManutencaoAtivos.Models
{
/*Classe caminhão: id, placa, modelo, ano, kmatual, status, ultima revisao e proxima revisao*/
    public class Caminhao
    {
        public Guid Id { get; set; }

        public string Placa { get; set; } = string.Empty; /*Atribuir um valor padrão*/

        public string Modelo { get; set; } = string.Empty; /*Atribuir um valor padrão*/

        public int Ano { get; set; }

        public double Km { get; set; }

        public string Status { get; set; }

        public DateTime DataUltimaRevisao { get; set; }

        public DateTime ProximaRevisao { get; set; }
        public Caminhao(Guid id, String placa, String modelo, int ano)
        {
            Id = id;
            Placa = placa;
            Modelo = modelo;
            Ano = ano;
            Km = 0;
            Status = "Em operação";
            DataUltimaRevisao = DateTime.Today;
            ProximaRevisao = DataUltimaRevisao.AddMonths(1);
        }

    }
    
}