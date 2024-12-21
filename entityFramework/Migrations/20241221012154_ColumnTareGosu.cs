using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ColumnTareGosu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TareaGosu",
                table: "Tarea",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TareaGosu",
                table: "Tarea");
        }
    }
}
