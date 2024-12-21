﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ColumnPesoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PesoCategoria",
                table: "Categoria",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PesoCategoria",
                table: "Categoria");
        }
    }
}
