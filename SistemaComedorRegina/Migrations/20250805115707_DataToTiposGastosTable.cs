using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaComedorRegina.Migrations
{
    /// <inheritdoc />
    public partial class DataToTiposGastosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TipoGastos",
                columns: new[] { "TipoGastoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Diarios" },
                    { 2, "Administrativos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoGastos",
                keyColumn: "TipoGastoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoGastos",
                keyColumn: "TipoGastoId",
                keyValue: 2);
        }
    }
}
