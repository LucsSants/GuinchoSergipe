using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuinchoSergipe.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class criandoSolicitacaoStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Solicitacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SolicitacaoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoStatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_StatusId",
                table: "Solicitacoes",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacoes_SolicitacaoStatus_StatusId",
                table: "Solicitacoes",
                column: "StatusId",
                principalTable: "SolicitacaoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacoes_SolicitacaoStatus_StatusId",
                table: "Solicitacoes");

            migrationBuilder.DropTable(
                name: "SolicitacaoStatus");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacoes_StatusId",
                table: "Solicitacoes");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Solicitacoes");
        }
    }
}
