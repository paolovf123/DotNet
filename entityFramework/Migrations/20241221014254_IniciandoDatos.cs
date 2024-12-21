using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace entityFramework.Migrations
{
    /// <inheritdoc />
    public partial class IniciandoDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TareaDescripcion",
                table: "Tarea",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaDescipcion",
                table: "Categoria",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "CategoriaDescipcion", "CategoriaNombre", "PesoCategoria" },
                values: new object[,]
                {
                    { new Guid("947f788f-c28b-4267-8b6c-f190fb513c02"), null, "Actividades Personales", 50 },
                    { new Guid("947f788f-c28b-4267-8b6c-f190fb513ca7"), null, "Actividades Pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "FechaCreacion", "TareaDescripcion", "TareaGosu", "TareaPrioridad", "TareaTitulo" },
                values: new object[,]
                {
                    { new Guid("947f788f-c28b-4267-8b6c-f190fb513c10"), new Guid("947f788f-c28b-4267-8b6c-f190fb513ca7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, "Pago de la U" },
                    { new Guid("947f788f-c28b-4267-8b6c-f190fb513c11"), new Guid("947f788f-c28b-4267-8b6c-f190fb513c02"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, "Pago del cuarto" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("947f788f-c28b-4267-8b6c-f190fb513c10"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("947f788f-c28b-4267-8b6c-f190fb513c11"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("947f788f-c28b-4267-8b6c-f190fb513c02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("947f788f-c28b-4267-8b6c-f190fb513ca7"));

            migrationBuilder.AlterColumn<string>(
                name: "TareaDescripcion",
                table: "Tarea",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaDescipcion",
                table: "Categoria",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
