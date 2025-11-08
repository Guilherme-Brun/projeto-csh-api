using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManutencaoAtivos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_IntId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caminhao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Placa = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Km = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    DataUltimaRevisao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProximaRevisao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caminhao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoManutencao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaminhaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DescricaoServico = table.Column<string>(type: "TEXT", nullable: false),
                    DataServico = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Custo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Responsavel = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoManutencao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CaminhaoId = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    TipoManutencao = table.Column<string>(type: "TEXT", nullable: false),
                    Custo = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServico", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Caminhao",
                columns: new[] { "Id", "Ano", "DataUltimaRevisao", "Km", "Modelo", "Placa", "ProximaRevisao", "Status" },
                values: new object[,]
                {
                    { 1, 2014, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 120000, "Scania", "PUU8869", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 2, 2016, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 95000, "Volvo", "AAA1234", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 3, 2018, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 87000, "Mercedes-Benz", "BBB5678", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 4, 2020, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 64000, "Iveco", "CCC9012", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 5, 2017, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 110000, "DAF", "DDD3456", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 6, 2019, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 78000, "Scania", "EEE7890", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 7, 2013, new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 210000, "Volvo", "FFF2345", new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 8, 2015, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 156000, "MAN", "GGG6789", new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 9, 2021, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 52000, "Mercedes-Benz", "HHH0123", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 10, 2012, new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 280000, "Iveco", "III4567", new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 11, 2016, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 143000, "Scania", "JJJ8901", new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 12, 2018, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 89000, "DAF", "KKK1357", new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 13, 2019, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 70000, "Volvo", "LLL2468", new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 14, 2014, new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 198000, "MAN", "MMM3691", new DateTime(2024, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 15, 2017, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 124000, "Mercedes-Benz", "NNN4826", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 16, 2013, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 210000, "Scania", "OOO5937", new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 17, 2020, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 62000, "Iveco", "PPP6048", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 18, 2015, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 154000, "DAF", "QQQ7159", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 19, 2018, new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 94000, "Volvo", "RRR8260", new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 20, 2016, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 132000, "Scania", "SSS9371", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 21, 2019, new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 81000, "Mercedes-Benz", "TTT0482", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 22, 2015, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 177000, "MAN", "UUU1593", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 23, 2017, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 120000, "Volvo", "VVV2604", new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 24, 2020, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 67000, "Scania", "WWW3715", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 25, 2021, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 54000, "Iveco", "XXX4826", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 26, 2019, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 90000, "DAF", "YYY5937", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 27, 2016, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 130000, "Volvo", "ZZZ6048", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 28, 2018, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 95000, "Scania", "ABC7159", new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 29, 2014, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 205000, "MAN", "DEF8260", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 30, 2021, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 48000, "Mercedes-Benz", "GHI9371", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 31, 2019, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 82000, "Volvo", "JKL0482", new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 32, 2020, new DateTime(2024, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 61000, "Scania", "MNO1593", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 33, 2017, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 125000, "Iveco", "PQR2604", new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 34, 2013, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 230000, "DAF", "STU3715", new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 35, 2015, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 175000, "Volvo", "VWX4826", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 36, 2018, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 93000, "Mercedes-Benz", "YZA5937", new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 37, 2016, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 150000, "MAN", "BCD6048", new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 38, 2019, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 78000, "Scania", "EFG7159", new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 39, 2021, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40000, "Volvo", "HIJ8260", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 40, 2017, new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 122000, "DAF", "KLM9371", new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 41, 2020, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 65000, "Scania", "NOP0482", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 42, 2018, new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 98000, "Volvo", "QRS1593", new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 43, 2015, new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 162000, "Mercedes-Benz", "TUV2604", new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 44, 2014, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 208000, "MAN", "WXY3715", new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 45, 2022, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000, "DAF", "ZAB4826", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 46, 2023, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 18000, "Scania", "CDE5937", new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 47, 2019, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 85000, "Volvo", "FGH6048", new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 48, 2017, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 118000, "Mercedes-Benz", "IJK7159", new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 49, 2020, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 60000, "MAN", "LMN8260", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" },
                    { 50, 2016, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 134000, "Volvo", "OPQ9371", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ativo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caminhao");

            migrationBuilder.DropTable(
                name: "HistoricoManutencao");

            migrationBuilder.DropTable(
                name: "OrdemServico");
        }
    }
}
