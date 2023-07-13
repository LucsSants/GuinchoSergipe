using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuinchoSergipe.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class criandoSolicitacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VeiculoModelId",
                table: "Veiculos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserClienteId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserGuinchoId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoliitacaoHora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SolicitacaoStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lat = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Long = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_AspNetUsers_UserClienteId",
                        column: x => x.UserClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_AspNetUsers_UserGuinchoId",
                        column: x => x.UserGuinchoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_VeiculoModelId",
                table: "Veiculos",
                column: "VeiculoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_UserClienteId",
                table: "Solicitacoes",
                column: "UserClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_UserGuinchoId",
                table: "Solicitacoes",
                column: "UserGuinchoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_VeiculoId",
                table: "Solicitacoes",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Veiculos_VeiculoModelId",
                table: "Veiculos",
                column: "VeiculoModelId",
                principalTable: "Veiculos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Veiculos_VeiculoModelId",
                table: "Veiculos");

            migrationBuilder.DropTable(
                name: "Solicitacoes");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_VeiculoModelId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "VeiculoModelId",
                table: "Veiculos");
        }
    }
}
