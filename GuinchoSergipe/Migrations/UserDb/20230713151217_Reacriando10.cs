using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuinchoSergipe.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class Reacriando10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "6a56e7fb-6459-41dd-8ed6-b993c63c946e", "CLIENTE", "CLIENTE" },
                    { "2", "00345e34-3a2f-4c83-b8ac-a941a02cc082", "GUINCHO", "GUINCHO" },
                    { "3", "a4bb59d3-99df-471f-96de-5a92e9a51385", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "SolicitacaoStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "PENDENTE" },
                    { 2, "EM_ANDAMENTO" },
                    { 3, "RECUSADO" },
                    { 4, "SEM_RESPOSTA" },
                    { 5, "CONCLUIDO" }
                });

            migrationBuilder.InsertData(
                table: "TiposVeiculo",
                columns: new[] { "Id", "TipoNome" },
                values: new object[,]
                {
                    { 1, "Motocicleta" },
                    { 2, "Carro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "SolicitacaoStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SolicitacaoStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SolicitacaoStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SolicitacaoStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SolicitacaoStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
