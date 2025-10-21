using Microsoft.EntityFrameworkCore;
using ManutencaoAtivos.Models;

namespace ManutencaoAtivos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

//lista tabelas do models que inclui o banco(colocar tudo que tem em models no mesmo padrao)
        public DbSet<Caminhao> Caminhao { get; set; }
        public DbSet<HistoricoManutencao> HistoricoManutencao { get; set; }
        public DbSet<OrdemServiso> OrdemServiso { get; set; }

    }

}