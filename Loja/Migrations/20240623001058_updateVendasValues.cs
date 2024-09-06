using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loja.Migrations
{
    /// <inheritdoc />
    public partial class updateVendasValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorVenda",
                table: "Vendas",
                newName: "valorVenda");

            migrationBuilder.RenameColumn(
                name: "DataVenda",
                table: "Vendas",
                newName: "dataVenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valorVenda",
                table: "Vendas",
                newName: "ValorVenda");

            migrationBuilder.RenameColumn(
                name: "dataVenda",
                table: "Vendas",
                newName: "DataVenda");
        }
    }
}
