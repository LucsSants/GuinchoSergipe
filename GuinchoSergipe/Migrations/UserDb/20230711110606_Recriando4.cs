using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuinchoSergipe.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class Recriando4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EnderecoModel_EnderecoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoModel_AspNetUsers_UserId",
                table: "VeiculoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoModel_TipoVeiculoModel_TipoVeiculoId",
                table: "VeiculoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VeiculoModel",
                table: "VeiculoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoVeiculoModel",
                table: "TipoVeiculoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoModel",
                table: "EnderecoModel");

            migrationBuilder.RenameTable(
                name: "VeiculoModel",
                newName: "Veiculos");

            migrationBuilder.RenameTable(
                name: "TipoVeiculoModel",
                newName: "TiposVeiculo");

            migrationBuilder.RenameTable(
                name: "EnderecoModel",
                newName: "Enderecos");

            migrationBuilder.RenameIndex(
                name: "IX_VeiculoModel_UserId",
                table: "Veiculos",
                newName: "IX_Veiculos_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_VeiculoModel_TipoVeiculoId",
                table: "Veiculos",
                newName: "IX_Veiculos_TipoVeiculoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposVeiculo",
                table: "TiposVeiculo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Enderecos_EnderecoId",
                table: "AspNetUsers",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_AspNetUsers_UserId",
                table: "Veiculos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_AspNetUsers_Enderecos_EnderecoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_AspNetUsers_UserId",
                table: "Veiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_TiposVeiculo_TipoVeiculoId",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposVeiculo",
                table: "TiposVeiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Veiculos",
                newName: "VeiculoModel");

            migrationBuilder.RenameTable(
                name: "TiposVeiculo",
                newName: "TipoVeiculoModel");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "EnderecoModel");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculos_UserId",
                table: "VeiculoModel",
                newName: "IX_VeiculoModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculos_TipoVeiculoId",
                table: "VeiculoModel",
                newName: "IX_VeiculoModel_TipoVeiculoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VeiculoModel",
                table: "VeiculoModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoVeiculoModel",
                table: "TipoVeiculoModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoModel",
                table: "EnderecoModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EnderecoModel_EnderecoId",
                table: "AspNetUsers",
                column: "EnderecoId",
                principalTable: "EnderecoModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VeiculoModel_AspNetUsers_UserId",
                table: "VeiculoModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VeiculoModel_TipoVeiculoModel_TipoVeiculoId",
                table: "VeiculoModel",
                column: "TipoVeiculoId",
                principalTable: "TipoVeiculoModel",
                principalColumn: "Id");
        }
    }
}
