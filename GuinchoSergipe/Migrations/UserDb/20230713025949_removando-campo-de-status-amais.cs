using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuinchoSergipe.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class removandocampodestatusamais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SolicitacaoStatus",
                table: "Solicitacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SolicitacaoStatus",
                table: "Solicitacoes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
