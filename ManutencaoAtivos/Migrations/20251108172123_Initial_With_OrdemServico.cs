using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManutencaoAtivos.Migrations
{
    /// <inheritdoc />
    public partial class Initial_With_OrdemServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CaminhaoId",
                table: "OrdemServico",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OrdemServico",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "OrdemServico",
                columns: new[] { "Id", "CaminhaoId", "Custo", "DataAbertura", "DataConclusao", "Descricao", "Status", "TipoManutencao" },
                values: new object[,]
                {
                    { 1, 3, 350.00m, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de óleo e filtro", "Finalizada", "Preventiva" },
                    { 2, 7, 1200.00m, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Substituição de pastilhas de freio", "Finalizada", "Corretiva" },
                    { 3, 10, 800.00m, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Revisão elétrica geral", "Aberta", "Preditiva" },
                    { 4, 1, 4000.00m, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troca de pneus (conjunto)", "Finalizada", "Corretiva" },
                    { 5, 15, 300.00m, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alinhamento e balanceamento", "Finalizada", "Preventiva" },
                    { 6, 22, 150.00m, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Verificação do sistema de ar", "Em andamento", "Preventiva" },
                    { 7, 30, 5200.00m, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conserto da caixa de câmbio", "Finalizada", "Corretiva" },
                    { 8, 40, 220.00m, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lubrificação geral e verificação", "Aberta", "Preventiva" },
                    { 9, 50, 980.00m, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Substituição de radiador", "Finalizada", "Corretiva" },
                    { 10, 5, 120.00m, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Check-up pré-viagem", "Aberta", "Preventiva" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrdemServico",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrdemServico",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrdemServico",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrdemServico",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrdemServico",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrdemServico",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrdemServico",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrdemServico",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrdemServico",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrdemServico",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "CaminhaoId",
                table: "OrdemServico",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrdemServico",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }
    }
}
