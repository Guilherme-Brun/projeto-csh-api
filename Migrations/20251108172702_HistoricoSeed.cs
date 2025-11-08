using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManutencaoAtivos.Migrations
{
    /// <inheritdoc />
    public partial class HistoricoSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HistoricoManutencao",
                columns: new[] { "Id", "CaminhaoId", "Custo", "DataServico", "DescricaoServico", "Responsavel" },
                values: new object[,]
                {
                    { 1, 1, 350.00m, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de óleo e filtro", "João Silva" },
                    { 2, 2, 1200.00m, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Substituição de pastilhas de freio", "Maria Oliveira" },
                    { 3, 3, 900.00m, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de correia dentada", "Carlos Mendes" },
                    { 4, 5, 2500.00m, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Revisão completa", "Lucas Pereira" },
                    { 5, 8, 700.00m, new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Substituição de bateria", "Fernanda Lima" },
                    { 6, 10, 4800.00m, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de pneus", "André Santos" },
                    { 7, 12, 1900.00m, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de amortecedores", "João Silva" },
                    { 8, 15, 300.00m, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alinhamento e balanceamento", "Marcos Rocha" },
                    { 9, 20, 950.00m, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reparo no sistema de freio", "Cláudia Souza" },
                    { 10, 25, 2200.00m, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de embreagem", "João Silva" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HistoricoManutencao",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HistoricoManutencao",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HistoricoManutencao",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HistoricoManutencao",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HistoricoManutencao",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HistoricoManutencao",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HistoricoManutencao",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HistoricoManutencao",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HistoricoManutencao",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HistoricoManutencao",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
