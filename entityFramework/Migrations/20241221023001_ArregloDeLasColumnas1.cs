using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ArregloDeLasColumnas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Tarea_CategoriaId",
                table: "Tarea");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Tarea_CategoriaId",
                table: "Tarea",
                column: "CategoriaId");
        }
    }
}
