using Microsoft.EntityFrameworkCore;
using ManutencaoAtivos.Models;
using System;

namespace ManutencaoAtivos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Caminhao> Caminhao { get; set; }
        public DbSet<HistoricoManutencao> HistoricoManutencao { get; set; }
        public DbSet<OrdemServico> OrdemServico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Caminhao>().HasData(
                new Caminhao { Id = 1, Placa = "PUU8869", Modelo = "Scania", Ano = 2014, Km = 120000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 1, 10), ProximaRevisao = new DateTime(2025, 1, 10) },
                new Caminhao { Id = 2, Placa = "AAA1234", Modelo = "Volvo", Ano = 2016, Km = 95000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 15), ProximaRevisao = new DateTime(2025, 2, 15) },
                new Caminhao { Id = 3, Placa = "BBB5678", Modelo = "Mercedes-Benz", Ano = 2018, Km = 87000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 3, 10), ProximaRevisao = new DateTime(2025, 3, 10) },
                new Caminhao { Id = 4, Placa = "CCC9012", Modelo = "Iveco", Ano = 2020, Km = 64000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 4, 12), ProximaRevisao = new DateTime(2025, 4, 12) },
                new Caminhao { Id = 5, Placa = "DDD3456", Modelo = "DAF", Ano = 2017, Km = 110000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 1, 20), ProximaRevisao = new DateTime(2025, 1, 20) },
                new Caminhao { Id = 6, Placa = "EEE7890", Modelo = "Scania", Ano = 2019, Km = 78000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 3, 5), ProximaRevisao = new DateTime(2025, 3, 5) },
                new Caminhao { Id = 7, Placa = "FFF2345", Modelo = "Volvo", Ano = 2013, Km = 210000, Status = "Ativo", DataUltimaRevisao = new DateTime(2023, 12, 11), ProximaRevisao = new DateTime(2024, 12, 11) },
                new Caminhao { Id = 8, Placa = "GGG6789", Modelo = "MAN", Ano = 2015, Km = 156000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 7), ProximaRevisao = new DateTime(2025, 2, 7) },
                new Caminhao { Id = 9, Placa = "HHH0123", Modelo = "Mercedes-Benz", Ano = 2021, Km = 52000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 5, 9), ProximaRevisao = new DateTime(2025, 5, 9) },
                new Caminhao { Id = 10, Placa = "III4567", Modelo = "Iveco", Ano = 2012, Km = 280000, Status = "Ativo", DataUltimaRevisao = new DateTime(2023, 10, 22), ProximaRevisao = new DateTime(2024, 10, 22) },
                new Caminhao { Id = 11, Placa = "JJJ8901", Modelo = "Scania", Ano = 2016, Km = 143000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 1, 31), ProximaRevisao = new DateTime(2025, 1, 31) },
                new Caminhao { Id = 12, Placa = "KKK1357", Modelo = "DAF", Ano = 2018, Km = 89000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 28), ProximaRevisao = new DateTime(2025, 2, 28) },
                new Caminhao { Id = 13, Placa = "LLL2468", Modelo = "Volvo", Ano = 2019, Km = 70000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 4, 3), ProximaRevisao = new DateTime(2025, 4, 3) },
                new Caminhao { Id = 14, Placa = "MMM3691", Modelo = "MAN", Ano = 2014, Km = 198000, Status = "Ativo", DataUltimaRevisao = new DateTime(2023, 12, 19), ProximaRevisao = new DateTime(2024, 12, 19) },
                new Caminhao { Id = 15, Placa = "NNN4826", Modelo = "Mercedes-Benz", Ano = 2017, Km = 124000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 15), ProximaRevisao = new DateTime(2025, 2, 15) },
                new Caminhao { Id = 16, Placa = "OOO5937", Modelo = "Scania", Ano = 2013, Km = 210000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 1, 8), ProximaRevisao = new DateTime(2025, 1, 8) },
                new Caminhao { Id = 17, Placa = "PPP6048", Modelo = "Iveco", Ano = 2020, Km = 62000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 4, 10), ProximaRevisao = new DateTime(2025, 4, 10) },
                new Caminhao { Id = 18, Placa = "QQQ7159", Modelo = "DAF", Ano = 2015, Km = 154000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 3, 5), ProximaRevisao = new DateTime(2025, 3, 5) },
                new Caminhao { Id = 19, Placa = "RRR8260", Modelo = "Volvo", Ano = 2018, Km = 94000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 22), ProximaRevisao = new DateTime(2025, 2, 22) },
                new Caminhao { Id = 20, Placa = "SSS9371", Modelo = "Scania", Ano = 2016, Km = 132000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 3, 20), ProximaRevisao = new DateTime(2025, 3, 20) },
                new Caminhao { Id = 21, Placa = "TTT0482", Modelo = "Mercedes-Benz", Ano = 2019, Km = 81000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 4, 14), ProximaRevisao = new DateTime(2025, 4, 14) },
                new Caminhao { Id = 22, Placa = "UUU1593", Modelo = "MAN", Ano = 2015, Km = 177000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 1), ProximaRevisao = new DateTime(2025, 2, 1) },
                new Caminhao { Id = 23, Placa = "VVV2604", Modelo = "Volvo", Ano = 2017, Km = 120000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 1, 25), ProximaRevisao = new DateTime(2025, 1, 25) },
                new Caminhao { Id = 24, Placa = "WWW3715", Modelo = "Scania", Ano = 2020, Km = 67000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 5, 5), ProximaRevisao = new DateTime(2025, 5, 5) },
                new Caminhao { Id = 25, Placa = "XXX4826", Modelo = "Iveco", Ano = 2021, Km = 54000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 4, 30), ProximaRevisao = new DateTime(2025, 4, 30) },
                new Caminhao { Id = 26, Placa = "YYY5937", Modelo = "DAF", Ano = 2019, Km = 90000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 3, 10), ProximaRevisao = new DateTime(2025, 3, 10) },
                new Caminhao { Id = 27, Placa = "ZZZ6048", Modelo = "Volvo", Ano = 2016, Km = 130000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 5), ProximaRevisao = new DateTime(2025, 2, 5) },
                new Caminhao { Id = 28, Placa = "ABC7159", Modelo = "Scania", Ano = 2018, Km = 95000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 3, 2), ProximaRevisao = new DateTime(2025, 3, 2) },
                new Caminhao { Id = 29, Placa = "DEF8260", Modelo = "MAN", Ano = 2014, Km = 205000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 1, 12), ProximaRevisao = new DateTime(2025, 1, 12) },
                new Caminhao { Id = 30, Placa = "GHI9371", Modelo = "Mercedes-Benz", Ano = 2021, Km = 48000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 5, 2), ProximaRevisao = new DateTime(2025, 5, 2) },
                new Caminhao { Id = 31, Placa = "JKL0482", Modelo = "Volvo", Ano = 2019, Km = 82000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 3, 19), ProximaRevisao = new DateTime(2025, 3, 19) },
                new Caminhao { Id = 32, Placa = "MNO1593", Modelo = "Scania", Ano = 2020, Km = 61000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 4, 17), ProximaRevisao = new DateTime(2025, 4, 17) },
                new Caminhao { Id = 33, Placa = "PQR2604", Modelo = "Iveco", Ano = 2017, Km = 125000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 28), ProximaRevisao = new DateTime(2025, 2, 28) },
                new Caminhao { Id = 34, Placa = "STU3715", Modelo = "DAF", Ano = 2013, Km = 230000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 1, 14), ProximaRevisao = new DateTime(2025, 1, 14) },
                new Caminhao { Id = 35, Placa = "VWX4826", Modelo = "Volvo", Ano = 2015, Km = 175000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 10), ProximaRevisao = new DateTime(2025, 2, 10) },
                new Caminhao { Id = 36, Placa = "YZA5937", Modelo = "Mercedes-Benz", Ano = 2018, Km = 93000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 3, 25), ProximaRevisao = new DateTime(2025, 3, 25) },
                new Caminhao { Id = 37, Placa = "BCD6048", Modelo = "MAN", Ano = 2016, Km = 150000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 3), ProximaRevisao = new DateTime(2025, 2, 3) },
                new Caminhao { Id = 38, Placa = "EFG7159", Modelo = "Scania", Ano = 2019, Km = 78000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 3, 9), ProximaRevisao = new DateTime(2025, 3, 9) },
                new Caminhao { Id = 39, Placa = "HIJ8260", Modelo = "Volvo", Ano = 2021, Km = 40000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 5, 1), ProximaRevisao = new DateTime(2025, 5, 1) },
                new Caminhao { Id = 40, Placa = "KLM9371", Modelo = "DAF", Ano = 2017, Km = 122000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 17), ProximaRevisao = new DateTime(2025, 2, 17) },
                new Caminhao { Id = 41, Placa = "NOP0482", Modelo = "Scania", Ano = 2020, Km = 65000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 4, 11), ProximaRevisao = new DateTime(2025, 4, 11) },
                new Caminhao { Id = 42, Placa = "QRS1593", Modelo = "Volvo", Ano = 2018, Km = 98000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 3, 12), ProximaRevisao = new DateTime(2025, 3, 12) },
                new Caminhao { Id = 43, Placa = "TUV2604", Modelo = "Mercedes-Benz", Ano = 2015, Km = 162000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 6), ProximaRevisao = new DateTime(2025, 2, 6) },
                new Caminhao { Id = 44, Placa = "WXY3715", Modelo = "MAN", Ano = 2014, Km = 208000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 1, 9), ProximaRevisao = new DateTime(2025, 1, 9) },
                new Caminhao { Id = 45, Placa = "ZAB4826", Modelo = "DAF", Ano = 2022, Km = 30000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 6, 1), ProximaRevisao = new DateTime(2025, 6, 1) },
                new Caminhao { Id = 46, Placa = "CDE5937", Modelo = "Scania", Ano = 2023, Km = 18000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 6, 3), ProximaRevisao = new DateTime(2025, 6, 3) },
                new Caminhao { Id = 47, Placa = "FGH6048", Modelo = "Volvo", Ano = 2019, Km = 85000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 3, 22), ProximaRevisao = new DateTime(2025, 3, 22) },
                new Caminhao { Id = 48, Placa = "IJK7159", Modelo = "Mercedes-Benz", Ano = 2017, Km = 118000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 9), ProximaRevisao = new DateTime(2025, 2, 9) },
                new Caminhao { Id = 49, Placa = "LMN8260", Modelo = "MAN", Ano = 2020, Km = 60000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 4, 20), ProximaRevisao = new DateTime(2025, 4, 20) },
                new Caminhao { Id = 50, Placa = "OPQ9371", Modelo = "Volvo", Ano = 2016, Km = 134000, Status = "Ativo", DataUltimaRevisao = new DateTime(2024, 2, 12), ProximaRevisao = new DateTime(2025, 2, 12) }
            );

            // seed de ordens (exemplo: 15 ordens distribuídas entre caminhões 1..50)
            modelBuilder.Entity<OrdemServico>().HasData(
                new OrdemServico { Id = 1, CaminhaoId = 3, Descricao = "Troca de óleo e filtro", TipoManutencao = "Preventiva", Custo = 350.00m, DataAbertura = new DateTime(2024, 5, 1), Status = "Finalizada", DataConclusao = new DateTime(2024, 5, 2) },
                new OrdemServico { Id = 2, CaminhaoId = 7, Descricao = "Substituição de pastilhas de freio", TipoManutencao = "Corretiva", Custo = 1200.00m, DataAbertura = new DateTime(2024, 4, 10), Status = "Finalizada", DataConclusao = new DateTime(2024, 4, 12) },
                new OrdemServico { Id = 3, CaminhaoId = 10, Descricao = "Revisão elétrica geral", TipoManutencao = "Preditiva", Custo = 800.00m, DataAbertura = new DateTime(2024, 6, 5), Status = "Aberta" },
                new OrdemServico { Id = 4, CaminhaoId = 1, Descricao = "Troca de pneus (conjunto)", TipoManutencao = "Corretiva", Custo = 4000.00m, DataAbertura = new DateTime(2024, 3, 20), Status = "Finalizada", DataConclusao = new DateTime(2024, 3, 25) },
                new OrdemServico { Id = 5, CaminhaoId = 15, Descricao = "Alinhamento e balanceamento", TipoManutencao = "Preventiva", Custo = 300.00m, DataAbertura = new DateTime(2024, 2, 28), Status = "Finalizada", DataConclusao = new DateTime(2024, 3, 1) },
                new OrdemServico { Id = 6, CaminhaoId = 22, Descricao = "Verificação do sistema de ar", TipoManutencao = "Preventiva", Custo = 150.00m, DataAbertura = new DateTime(2024, 5, 15), Status = "Em andamento" },
                new OrdemServico { Id = 7, CaminhaoId = 30, Descricao = "Conserto da caixa de câmbio", TipoManutencao = "Corretiva", Custo = 5200.00m, DataAbertura = new DateTime(2024, 1, 8), Status = "Finalizada", DataConclusao = new DateTime(2024, 1, 20) },
                new OrdemServico { Id = 8, CaminhaoId = 40, Descricao = "Lubrificação geral e verificação", TipoManutencao = "Preventiva", Custo = 220.00m, DataAbertura = new DateTime(2024, 6, 1), Status = "Aberta" },
                new OrdemServico { Id = 9, CaminhaoId = 50, Descricao = "Substituição de radiador", TipoManutencao = "Corretiva", Custo = 980.00m, DataAbertura = new DateTime(2024, 4, 2), Status = "Finalizada", DataConclusao = new DateTime(2024, 4, 8) },
                new OrdemServico { Id = 10, CaminhaoId = 5, Descricao = "Check-up pré-viagem", TipoManutencao = "Preventiva", Custo = 120.00m, DataAbertura = new DateTime(2024, 5, 20), Status = "Aberta" }
            );
// Dados iniciais de histórico de manutenção
modelBuilder.Entity<HistoricoManutencao>().HasData(
    new HistoricoManutencao { Id = 1, CaminhaoId = 1, DescricaoServico = "Troca de óleo e filtro", DataServico = new DateTime(2024, 1, 15), Custo = 350.00m, Responsavel = "João Silva" },
    new HistoricoManutencao { Id = 2, CaminhaoId = 2, DescricaoServico = "Substituição de pastilhas de freio", DataServico = new DateTime(2024, 2, 20), Custo = 1200.00m, Responsavel = "Maria Oliveira" },
    new HistoricoManutencao { Id = 3, CaminhaoId = 3, DescricaoServico = "Troca de correia dentada", DataServico = new DateTime(2024, 3, 10), Custo = 900.00m, Responsavel = "Carlos Mendes" },
    new HistoricoManutencao { Id = 4, CaminhaoId = 5, DescricaoServico = "Revisão completa", DataServico = new DateTime(2024, 4, 5), Custo = 2500.00m, Responsavel = "Lucas Pereira" },
    new HistoricoManutencao { Id = 5, CaminhaoId = 8, DescricaoServico = "Substituição de bateria", DataServico = new DateTime(2024, 2, 8), Custo = 700.00m, Responsavel = "Fernanda Lima" },
    new HistoricoManutencao { Id = 6, CaminhaoId = 10, DescricaoServico = "Troca de pneus", DataServico = new DateTime(2024, 1, 25), Custo = 4800.00m, Responsavel = "André Santos" },
    new HistoricoManutencao { Id = 7, CaminhaoId = 12, DescricaoServico = "Troca de amortecedores", DataServico = new DateTime(2024, 3, 1), Custo = 1900.00m, Responsavel = "João Silva" },
    new HistoricoManutencao { Id = 8, CaminhaoId = 15, DescricaoServico = "Alinhamento e balanceamento", DataServico = new DateTime(2024, 2, 18), Custo = 300.00m, Responsavel = "Marcos Rocha" },
    new HistoricoManutencao { Id = 9, CaminhaoId = 20, DescricaoServico = "Reparo no sistema de freio", DataServico = new DateTime(2024, 4, 11), Custo = 950.00m, Responsavel = "Cláudia Souza" },
    new HistoricoManutencao { Id = 10, CaminhaoId = 25, DescricaoServico = "Troca de embreagem", DataServico = new DateTime(2024, 3, 15), Custo = 2200.00m, Responsavel = "João Silva" }
);

        }
        
    }
}
