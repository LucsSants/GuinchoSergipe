using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuinchoSergipe.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoCidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoModel_Usuarios_UsuarioId",
                table: "VeiculoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VeiculoModel",
                table: "VeiculoModel");

            migrationBuilder.RenameTable(
                name: "VeiculoModel",
                newName: "Veiculos");

            migrationBuilder.RenameIndex(
                name: "IX_VeiculoModel_UsuarioId",
                table: "Veiculos",
                newName: "IX_Veiculos_UsuarioId");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Enderecos",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Usuarios_UsuarioId",
                table: "Veiculos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Usuarios_UsuarioId",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Veiculos",
                newName: "VeiculoModel");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculos_UsuarioId",
                table: "VeiculoModel",
                newName: "IX_VeiculoModel_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VeiculoModel",
                table: "VeiculoModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VeiculoModel_Usuarios_UsuarioId",
                table: "VeiculoModel",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
