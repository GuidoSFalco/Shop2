using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop2.Shared.Migrations
{
    public partial class CompletaTablaCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UQ_Compra_IdCompra",
                table: "Compras",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Compra_IdCompra",
                table: "Compras");
        }
    }
}
