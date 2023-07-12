using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuinchoSergipe.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class Recriando3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserUserId",
                table: "VeiculoModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserUserId",
                table: "VeiculoModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
