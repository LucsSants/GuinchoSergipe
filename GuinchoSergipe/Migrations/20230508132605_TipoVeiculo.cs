using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuinchoSergipe.Migrations
{
    /// <inheritdoc />
    public partial class TipoVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoVeiculoId",
                table: "Veiculos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TiposVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoNome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVeiculo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_TipoVeiculoId",
                table: "Veiculos",
                column: "TipoVeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_TiposVeiculo_TipoVeiculoId",
                table: "Veiculos",
                column: "TipoVeiculoId",
                principalTable: "TiposVeiculo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_TiposVeiculo_TipoVeiculoId",
                table: "Veiculos");

            migrationBuilder.DropTable(
                name: "TiposVeiculo");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_TipoVeiculoId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "TipoVeiculoId",
                table: "Veiculos");
        }
    }
}
